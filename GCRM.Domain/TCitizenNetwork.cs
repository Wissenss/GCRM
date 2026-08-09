using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
    public class TCitizenNetwork
    {
        public int Id;
        public TCitizen LeadCitizen;
        public int ParentNetworkId;
        public string Name;
        public string Description;
        public List<TCitizenNetworkMember> Members;
        public List<TCitizenNetworkRole> Roles;

        public TCitizenNetwork()
        {
            LeadCitizen = new TCitizen();
            Members = new List<TCitizenNetworkMember>();
            Roles = new List<TCitizenNetworkRole>();
        }

        public void FillFromReader(DbDataReader reader)
        {
            Id = reader.GetInt32(0);
            LeadCitizen.Id = reader.GetInt32(1);
            ParentNetworkId = reader.GetInt32(2);
            Name = reader.GetString(3);
            Description = reader.GetString(4);
        }
    }
}
