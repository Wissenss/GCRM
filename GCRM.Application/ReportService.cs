using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Infraestructure;
using Npgsql;
using Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Application
{
    public static class ReportService
    {
        public static Error GetR005DocumentModel(R005DocumentRequest request, out R005DocumentModel model)
        {
            model = new R005DocumentModel();
            model.Request = request;
            model.Citizens = new List<TCitizen>();
            model.Username = Session.User.Name;

            Error error = InstitutionsHandler.GetInstitutionById(request.InstitutionId, out model.Institution);

            if (error != Error.None)
                return error;

            string sql = $@"
                WITH RECURSIVE institution_ids AS (
					SELECT
						i.id,
						TRUE AS is_parent
					FROM
						institutions i
					WHERE
						i.id = @institution_id

					UNION ALL

					SELECT
						i.id,
						FALSE AS is_parent
					FROM 
						institutions i
					INNER JOIN institution_ids ii ON i.parent_institution_id = ii.id
				)

				SELECT
					c.id AS citizen_id,
					c.name AS citizen_name,
					c.paternal_name AS citizen_paternal_name,
					c.maternal_name AS citizen_maternal_name,
					i.id AS institution_id,
					i.name AS institution_name,
					COALESCE(itr.name, ir.name, '') AS role_name,
					cir_.is_active AS role_is_active,
					cir_.is_start_defined AS role_is_start_defined,
					cir_.started_at AS role_started_at,
					cir_.is_end_defined AS role_is_end_defined,
					cir_.ended_at AS role_ended_at,
					COALESCE(irv.id, 0) AS variation_id,
					COALESCE(irv.name, '') AS variation_name
				FROM
					citizen_institution_roles cir_
					JOIN institutions i ON cir_.institution_id = i.id
					JOIN citizens c ON cir_.citizen_id = c.id
					LEFT JOIN institution_template_roles itr ON itr.id = cir_.institution_template_role_id
					LEFT JOIN institution_roles ir ON ir.id = cir_.institution_role_id
					LEFT JOIN institution_role_variations irv ON irv.id = cir_.institution_role_variation_id
				WHERE
					cir_.institution_id IN (SELECT ii.id FROM institution_ids ii) 
				ORDER BY
					cir_.institution_id, c.name
				;
            ";

            using (var uow = new UnitOfWork())
            {
                using (var command = new NpgsqlCommand(sql, uow.connection))
                {
                    command.Parameters.AddWithValue("institution_id", request.InstitutionId);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TCitizen citizen = new TCitizen
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("citizen_id")),
                                Name = reader.GetString(reader.GetOrdinal("citizen_name")),
                                PaternalName = reader.GetString(reader.GetOrdinal("citizen_paternal_name")),
                                MaternalName = reader.GetString(reader.GetOrdinal("citizen_maternal_name")),
                                InstitutionRole = new TCitizenInstitutionRole
                                {
                                    Institution = new TInstitution
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("institution_id")),
                                        Name = reader.GetString(reader.GetOrdinal("institution_name"))
                                    },
                                    Role = new TInstitutionRole
                                    {
                                        Name = reader.GetString(reader.GetOrdinal("role_name"))
                                    },
                                    Variation = new TInstitutionRoleVariation
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("variation_id")),
                                        Name = reader.GetString(reader.GetOrdinal("variation_name"))
                                    },
                                    IsActive = reader.GetBoolean(reader.GetOrdinal("role_is_active")),
                                    IsStartDefined = reader.GetBoolean(reader.GetOrdinal("role_is_start_defined")),
                                    StartedAt = reader.IsDBNull(reader.GetOrdinal("role_started_at")) ? default : reader.GetDateTime(reader.GetOrdinal("role_started_at")),
                                    IsEndDefined = reader.GetBoolean(reader.GetOrdinal("role_is_end_defined")),
                                    EndedAt = reader.IsDBNull(reader.GetOrdinal("role_ended_at")) ? default : reader.GetDateTime(reader.GetOrdinal("role_ended_at"))
                                }
                            };

                            model.Citizens.Add(citizen);
                        }
                    }
                }
            }


            return Error.None;
        }

        public static Error GetR001DocumentModel(R001DocumentRequest request, out R001DocumentModel model)
        {
            model = new R001DocumentModel();
            model.Username = Session.User.Name;

            if (request.InstitutionId != 0)
            {
                Error error = InstitutionsHandler.GetInstitutionById(request.InstitutionId, out model.Institution);

                if (error != 0)
                    return error;
            }

            if (request.InstitutionCategoryId != 0)
            {
                Error error = InstitutionsHandler.GetInstitutionCategoryById(request.InstitutionCategoryId, out model.InstitutionCategory);

                if (error != 0)
                    return error;
            }

            if (request.CitizenCategoryId != 0)
            {
                Error error = CitizensHandler.GetCitizenCategoryById(request.CitizenCategoryId, out model.CitizenCategory);

                if (error != 0)
                    return error;
            }

            // todo: make the request object part of the model, so we dont have to map all properties one by one (again...)

            model.CitizenTitle = request.CitizenTitle;
            model.PoliticalParty = request.PoliticalParty;
            model.Sex = request.Sex;
            model.SocietySector = request.SocietySector;
            model.BirthdayYear = request.BirthdayYear;
            model.BirthdayMonth = request.BirthdayMonth;
            model.BirthdayDay = request.BirthdayDay;
            model.Order = request.Order;

            // filter the citizen list, probably could be done directley with a query (todo)...

            model.CitizenList = new List<TCitizen>();

            List<TCitizen> full_citizen_list;

            Error citizens_error = CitizensHandler.GetCitizens(out full_citizen_list);

            if (citizens_error != Error.None)
                return citizens_error;

            foreach (TCitizen citizen in full_citizen_list)
            {
                if (
                    request.InstitutionId != 0 && citizen.InstitutionRole.Institution.Id != request.InstitutionId ||
                    request.InstitutionCategoryId != 0 && citizen.InstitutionRole.Institution.Category.Id != request.InstitutionCategoryId ||
                    request.CitizenCategoryId != 0 && citizen.Category.Id != request.CitizenCategoryId ||
                    request.CitizenTitle != null && citizen.Title != request.CitizenTitle ||
                    request.Sex != null && citizen.Sex != request.Sex ||
                    request.PoliticalParty != null && citizen.PoliticalParty != request.PoliticalParty ||
                    request.SocietySector != null && citizen.InstitutionRole.Institution.Sector != request.SocietySector ||
                    request.BirthdayYear != null && citizen.Birthday.Year != request.BirthdayYear ||
                    request.BirthdayMonth != null && citizen.Birthday.Month != request.BirthdayMonth ||
                    request.BirthdayDay != null && citizen.Birthday.Day != request.BirthdayDay
                    )
                {
                    continue;
                }
                else
                {
                    model.CitizenList.Add(citizen);
                }
            }

            return Error.None;
        }
    }
}
