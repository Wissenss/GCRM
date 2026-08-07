using System.Data;
using System.Data.Common;

namespace GCRM.Domain
{
	public class TDuplicateMatch
	{
		public int Entity1Id;
		public string Entity1Name = "";
		public bool Entity1AttentionRequired;
		public string Entity1AttentionRequiredReason = "";
		public int Entity2Id;
		public string Entity2Name = "";
		public bool Entity2AttentionRequired;
		public string Entity2AttentionRequiredReason = "";
		public int Distance;

		public void FillFromReader(DbDataReader reader)
		{
			Entity1Id = reader.GetInt32("id1");
			Entity1Name = reader.GetString("name1");
			Entity1AttentionRequired = reader.GetBoolean("attention_required1");
			Entity1AttentionRequiredReason = reader.GetString("attention_required_reason1");
			Entity2Id = reader.GetInt32("id2");
			Entity2Name = reader.GetString("name2");
			Entity2AttentionRequired = reader.GetBoolean("attention_required2");
			Entity2AttentionRequiredReason = reader.GetString("attention_required_reason2");
			Distance = reader.GetInt32("distance");
		}
	}
}
