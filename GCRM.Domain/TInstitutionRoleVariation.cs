using System.Data.Common;

namespace GCRM.Domain
{
    public class TInstitutionRoleVariation
    {
        public int Id;
        public int InstitutionRoleId;
        public string Name = "";

        public void FillFromReader(DbDataReader reader)
        {
            Id = reader.GetInt32(0);
            InstitutionRoleId = reader.GetInt32(1);
            Name = reader.GetString(2);
        }

        public void PropertiesToUpper()
        {
            Name = Name.ToUpper();
        }
    }
}
