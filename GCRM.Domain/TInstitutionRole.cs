using System.Data.Common;

namespace GCRM.Domain
{
	public class TInstitutionRole
	{
		public int Id;
		public string Name = "";
		public int InstitutionId;
		public int InstitutionTemplateId;
		public int ParentRoleId;
		public string Description = "";
		public int NoCitizensWithThisRole;

		public bool IsActive = true;
		public bool IsStartDefined;
		public DateTime StartedAt;
		public bool IsEndDefined;
		public DateTime EndedAt;

		public string NameWithFirstCapital
		{
			get
			{
				if (Name.Length == 0)
					return "";

				string formated_name = Name.ToLower();

				formated_name = formated_name.First().ToString().ToUpper() + formated_name.Substring(1);

				return formated_name;
			}
		}

		public bool IsTemplateRole
		{
			get
			{
				return InstitutionTemplateId > 0;
			}
		}

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			InstitutionId = reader.GetInt32(2);
			ParentRoleId = reader.GetInt32(3);
			Description = reader.GetString(4);

			InstitutionTemplateId = 0;
		}

		public void FillFromReaderTemplate(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			InstitutionTemplateId = reader.GetInt32(1);
			Name = reader.GetString(2);
			Description = reader.GetString(3);

			ParentRoleId = 0;
			InstitutionId = 0;
		}

		public void PropertiesToUpper()
		{
			Name = Name.ToUpper();
			Description = Description.ToUpper();
		}
	}
}
