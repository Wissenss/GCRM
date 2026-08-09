using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
    public class TCitizenNetworkMember
    {
        public int Id;
        public int CitizenNetworkId;
        public TCitizen Citizen;
        public int ParentMemberId;
        public TCitizenNetworkRole Role;

        public TCitizenNetworkMember()
        {
            Citizen = new TCitizen();
            Role = new TCitizenNetworkRole();
        }

        public void FillFromReader(DbDataReader reader)
        {
            Citizen = new TCitizen();
            Role = new TCitizenNetworkRole();

            Id = reader.GetInt32(0);
            CitizenNetworkId = reader.GetInt32(1);
            Citizen.Id = reader.GetInt32(2);
            Role.Id = reader.GetInt32(3);
            ParentMemberId = reader.GetInt32(4);
        }
    }
}
