using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TCitizenRelationship
	{
		public int Id;
		public TCitizen Citizen;
		public TCitizen RelatedTo;
		public TCitizenRelationshipRole Role = new TCitizenRelationshipRole();
		public double AffinityScore;
		public bool KnownStartDate;
		public bool KnownEndDate;
		public DateTime StartDate;
		public DateTime EndDate;
		public string Notes;
		public bool Enabled;
		public TUser User = new TUser();

		public void FillFromReader(DbDataReader reader)
		{
			Citizen = new TCitizen();
			RelatedTo = new TCitizen();

			Id = reader.GetInt32("id");
			Citizen.Id = reader.GetInt32("citizen_id");
			RelatedTo.Id = reader.GetInt32("related_citizen_id");
			Role.Id = reader.GetInt32("citizen_relationship_role_id");
			AffinityScore = reader.GetDouble("affinity_score");
			KnownStartDate = reader.GetBoolean("known_start_date");
			KnownEndDate = reader.GetBoolean("known_end_date");
			StartDate = reader.GetDateTime("start_date");
			EndDate = reader.GetDateTime("end_date");
			Notes = reader.GetString("notes");
			Enabled = reader.GetBoolean("enabled");
			User.Id = reader.GetInt32("user_id");
		}
	}
}
