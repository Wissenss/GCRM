using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporter
{
	public class R001 : RCustom
	{
		public int InstitutionId;
		public int InstitutionCategoryId;
		public TCitizenTitle? CitizenTitle;
		public TSex? Sex;
		public TPoliticalParty? PoliticalParty;
		public TSocietySector? SocietySector;
		public int? BirthdayYear;
		public int? BirthdayMonth;
		public int? BirthdayDay;
		public TR001Order Order;

		R001DocumentModel Model;

		public R001() 
		{
			RDocument = null;
		}

		public override Error PrepareReport()
		{
			Model = new R001DocumentModel();

			RDocument = new R001Document(Model);

			if (InstitutionId != 0)
			{
				Error error = InstitutionsHandler.GetInstitutionById(InstitutionId, out Model.Institution);

				if (error != 0)
					return error;
			}

			if (InstitutionCategoryId != 0)
			{
				Error error = InstitutionsHandler.GetInstitutionCategoryById(InstitutionCategoryId, out Model.InstitutionCategory);

				if (error != 0)
					return error;
			}

			Model.CitizenTitle = CitizenTitle;
			Model.PoliticalParty = PoliticalParty;
			Model.Sex = Sex;
			Model.SocietySector = SocietySector;
			Model.BirthdayYear = BirthdayYear;
			Model.BirthdayMonth = BirthdayMonth;
			Model.BirthdayDay = BirthdayDay;
			Model.Order = Order;

			// filter the citizen list, probably could be done directley with a query...
			Model.CitizenList = new List<TCitizen>();

			List<TCitizen> full_citizen_list;

			Error erro = CitizensHandler.GetCitizens(out full_citizen_list);

			foreach (TCitizen citizen in full_citizen_list)
			{
				if (
					InstitutionId != 0 && citizen.Institution.Id != InstitutionId ||
					InstitutionCategoryId != 0 && citizen.Institution.Category.Id != InstitutionCategoryId ||
					CitizenTitle != null && citizen.Title != CitizenTitle ||
					Sex != null && citizen.Sex != Sex ||
					PoliticalParty != null && citizen.PoliticalParty != PoliticalParty ||
					SocietySector != null && citizen.Institution.Sector != SocietySector ||
					BirthdayYear != null && citizen.Birthday.Year != BirthdayYear ||
					BirthdayMonth != null && citizen.Birthday.Month != BirthdayMonth ||
					BirthdayDay != null && citizen.Birthday.Day != BirthdayDay
					)
				{
					continue;
				}
				else
				{
					Model.CitizenList.Add(citizen);
				}
			}

			return 0;
		}
	}
}
