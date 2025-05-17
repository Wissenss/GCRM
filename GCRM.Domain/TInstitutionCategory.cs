using System.Data.Common;

namespace GCRM.Domain
{
	public class TInstitutionCategory
	{
		public int Id;
		public string Name = "";
		public string Description = "";

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			Description = reader.GetString(2);
		}

		public void PropertiesToUpper()
		{
			Name = Name.ToUpper();
			Description = Description.ToUpper();
		}
	}
}
