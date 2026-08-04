using Business;
using GCRM.Domain;
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
					cir_.ended_at AS role_ended_at
				FROM
					citizen_institution_roles cir_
					JOIN institutions i ON cir_.institution_id = i.id
					JOIN citizens c ON cir_.citizen_id = c.id
					LEFT JOIN institution_template_roles itr ON itr.id = cir_.institution_template_role_id
					LEFT JOIN institution_roles ir ON ir.id = cir_.institution_role_id
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
								Institution = new TInstitution
								{
									Id = reader.GetInt32(reader.GetOrdinal("institution_id")),
									Name = reader.GetString(reader.GetOrdinal("institution_name"))
								},
								Role = new TInstitutionRole
								{
									Name = reader.GetString(reader.GetOrdinal("role_name")),
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
    }
}
