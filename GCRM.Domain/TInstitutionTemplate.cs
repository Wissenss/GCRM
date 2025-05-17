using System.Data.Common;

namespace GCRM.Domain
{
	public class TInstitutionTemplate
	{
		public int Id;
		public string Name;
		public string Description;

		public List<TInstitutionRole> Roles = new List<TInstitutionRole>();

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			Description = reader.GetString(2);
		}
	}
}
