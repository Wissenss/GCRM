using System.Data.Common;
using System.Text;

namespace GCRM.Domain
{
	public class TInstitutionCategory : TEntity
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

		public override string GetAsLogString()
		{
			StringBuilder log_string = new StringBuilder();

			log_string.AppendLine($"Id:              \t{Id}");
			log_string.AppendLine($"Name:            \t{Name}");
			log_string.AppendLine($"Description:     \t{Description}");

			return log_string.ToString();
		}
	}
}
