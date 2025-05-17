using System.Data.Common;
using System.Text;
using System.Data;

namespace GCRM.Domain
{
	public class TCitizenRelationshipRole
	{
		public int Id;
		public string Name;

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32("id");
			Name = reader.GetString("name");
		}
	}
}
