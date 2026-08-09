using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
    public class TCitizenNetworkRole
    {
        public int Id;
        public int CitizenNetworkId;
        public string Name;
        public string Description;
        public int Level;

        public void FillFromReader(DbDataReader reader)
        {
            Id = reader.GetInt32(0);
            CitizenNetworkId = reader.GetInt32(1);
            Name = reader.GetString(2);
            Description = reader.GetString(3);
            Level = reader.GetInt32(4);
        }
    }
}
