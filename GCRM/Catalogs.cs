using Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Business.BConstants;

namespace GCRM
{
	public static class Catalogs
	{
		public static DataSet DSCatalogs;

		public static DataTable DTSocietySector;
		public static DataTable DTCitizenTitles;
		public static DataTable DTCitizenCategories;
		public static DataTable DTCountries;
		public static DataTable DTPoliticalParties;
		public static DataTable DTSex;

		public static DataTable DTInstitutionCategories;
		public static DataTable DTInstitutions;

		static Catalogs()
		{
			DSCatalogs = new DataSet();

			// institution types
			DTSocietySector = new DataTable("DTInstitutionTypes");
			DTSocietySector.Columns.Add("value", typeof(TSocietySector));
			DTSocietySector.Columns.Add("text", typeof(string));
			DSCatalogs.Tables.Add(DTSocietySector);

			// citizen titles
			DTCitizenTitles = new DataTable("DTCitizenTitles");
			DTCitizenTitles.Columns.Add("value", typeof(TCitizenTitle));
			DTCitizenTitles.Columns.Add("text", typeof(string));
			DSCatalogs.Tables.Add(DTCitizenTitles);

			// citizen categories
			DTCitizenCategories = new DataTable("DTCitizenCategories");
			DTCitizenCategories.Columns.Add("id", typeof(int));
			DTCitizenCategories.Columns.Add("name", typeof(string));
			DTCitizenCategories.Columns.Add("description", typeof(string));	
			DSCatalogs.Tables.Add(DTCitizenCategories);

			// countries
			DTCountries = new DataTable("DTCountries");
			DTCountries.Columns.Add("value", typeof(TCountry));
			DTCountries.Columns.Add("text", typeof(string));
			DSCatalogs.Tables.Add(DTCountries);

			// political party
			DTPoliticalParties = new DataTable("DTPoliticalParty");
			DTPoliticalParties.Columns.Add("value", typeof(TCountry));
			DTPoliticalParties.Columns.Add("text", typeof(string));
			DSCatalogs.Tables.Add(DTPoliticalParties);

			// sex
			DTSex = new DataTable("DTSex");
			DTSex.Columns.Add("value", typeof(TSex));
			DTSex.Columns.Add("text", typeof(string));
			DSCatalogs.Tables.Add(DTSex);

			// institution categories
			DTInstitutionCategories = new DataTable("DTInstitutionCategories");
			DTInstitutionCategories.Columns.Add("id", typeof(int));
			DTInstitutionCategories.Columns.Add("name", typeof(string));
			DTInstitutionCategories.Columns.Add("description", typeof(string));
			DSCatalogs.Tables.Add(DTInstitutionCategories);

			// institutions
			DTInstitutions = new DataTable("DTInstitutions");
			DTInstitutions.Columns.Add("id", typeof(int));
			DTInstitutions.Columns.Add("name", typeof(string));
			DTInstitutions.Columns.Add("society_sector", typeof(TSocietySector));
			DTInstitutions.Columns.Add("society_sector_name", typeof(string));
			DTInstitutions.Columns.Add("category_id", typeof(int));
			DTInstitutions.Columns.Add("category_name", typeof(string));
			DTInstitutions.Columns.Add("description", typeof(string));
			DTInstitutions.Columns.Add("parent_institution_id", typeof(int));
			DTInstitutions.Columns.Add("acronym", typeof(string));	
			DSCatalogs.Tables.Add(DTInstitutions);
		}

		public static void LoadAll()
		{
			using (new CursorWait())
			{
				LoadDTSocietySectors();
				LoadDTCitzenTitles();
				LoadDTCountries();
				LoadDTPoliticalParties();
				LoadDTSex();
			}
		}

		private static DataRow AddValueTextToDT<T>(DataTable dt, T value, string text)
		{
			DataRow row = dt.NewRow();

			row["value"] = value;
			row["text"]  = text;

			dt.Rows.Add(row);

			return row;
		}

		public static DataTable LoadDTSocietySectors()
		{
			DTSocietySector.BeginLoadData();
			DTSocietySector.Clear();

			foreach (TSocietySector value in Enum.GetValues(typeof(TSocietySector)))
			{
				AddValueTextToDT(DTSocietySector, value, GetSocietySectorName(value));
			}

			DTSocietySector.EndLoadData();

			return DTSocietySector;
		}

		public static DataTable LoadDTCitzenTitles()
		{
			DTCitizenTitles.BeginLoadData();
			DTCitizenTitles.Clear();

			foreach (TCitizenTitle value in Enum.GetValues(typeof(TCitizenTitle)))
			{
				AddValueTextToDT(DTCitizenTitles, value, GetCitizenBriefTitle(value));
			}

			DTCitizenTitles.EndLoadData();

			return DTCitizenTitles;
		}

		public static DataTable LoadDTCountries()
		{
			DTCountries.BeginLoadData();
			DTCountries.Clear();

			foreach (TCountry value in Enum.GetValues(typeof(TCountry)))
			{
				AddValueTextToDT(DTCountries, value, GetCountryCommonName(value));
			}

			DTCountries.EndLoadData();

			return DTCountries;
		}
	
		public static DataTable LoadDTPoliticalParties()
		{
			DTPoliticalParties.BeginLoadData();
			DTPoliticalParties.Clear();

			foreach (TPoliticalParty value in Enum.GetValues(typeof(TPoliticalParty)))
			{
				AddValueTextToDT(DTPoliticalParties, value, GetPoliticalPartyCommonName(value));
			}

			DTPoliticalParties.EndLoadData();

			return DTPoliticalParties;
		}

		public static DataTable LoadDTSex()
		{
			DTSex.BeginLoadData();
			DTSex.Clear();

			foreach (TSex value in Enum.GetValues(typeof(TSex)))
			{
				AddValueTextToDT(DTSex, value, GetSexName(value));
			}

			DTSex.EndLoadData();

			return DTSex;
		}

		public static void LoadDTInstitutionCategories()
		{
			DTInstitutionCategories.BeginLoadData();
			DTInstitutionCategories.Clear();

			List<TInstitutionCategory> institution_categories_list;

			Error error = InstitutionsHandler.GetInstitutionCategories(out institution_categories_list);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);

				return;
			}

			foreach (TInstitutionCategory institution_category in institution_categories_list)
			{
				DataRow row = DTInstitutionCategories.NewRow();

				row["id"] = institution_category.Id;
				row["name"] = institution_category.Name;
				row["description"] = institution_category.Description;

				DTInstitutionCategories.Rows.Add(row);
			}

			DTInstitutionCategories.EndLoadData();
		}
	
		public static void LoadDTInstitutions()
		{
			DTInstitutions.BeginLoadData();
			DTInstitutions.Clear();

			List<TInstitution> institutions_list;

			Error error = InstitutionsHandler.GetInstitutions(out institutions_list);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;	
			}

			foreach(TInstitution institution in institutions_list)
			{
				DataRow row = DTInstitutions.NewRow();

				row["id"] = institution.Id;
				row["name"] = institution.Name;
				row["society_sector"] = institution.Sector;
				row["society_sector_name"] = BConstants.GetSocietySectorName(institution.Sector);
				row["category_id"] = institution.Category.Id;
				row["category_name"] = institution.Category.Name;
				row["description"] = institution.Description;
				row["parent_institution_id"] = institution.ParentInstitutionId;
				row["acronym"] = institution.Acronym;

				DTInstitutions.Rows.Add(row);	
			}

			DTInstitutions.EndLoadData();
		}
	
		public static void LoadDTCitizenCategories()
		{
			List<TCitizenCategory> categories;

			Error error = CitizensHandler.GetCitizenCategories(out categories);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			DTCitizenCategories.BeginLoadData();
			DTCitizenCategories.Clear();

			foreach (TCitizenCategory category in categories)
			{
				DataRow row = DTCitizenCategories.NewRow();

				row["id"] = category.Id;
				row["name"] = category.Name;
				row["description"] = category.Description;

				DTCitizenCategories.Rows.Add(row);
			}

			DTCitizenCategories.EndLoadData();
		}
	}
}
