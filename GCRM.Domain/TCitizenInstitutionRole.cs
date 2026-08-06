namespace GCRM.Domain
{
	public class TCitizenInstitutionRole
	{
		public int Id;
		public int CitizenId;
		public int Position;
		public TInstitution Institution = new TInstitution();
		public TInstitutionRole Role = new TInstitutionRole();
		public TInstitutionRoleVariation Variation = new TInstitutionRoleVariation();
		public bool IsActive = true;
		public bool IsStartDefined;
		public DateTime StartedAt;
		public bool IsEndDefined;
		public DateTime EndedAt;

		// the variation is a superficial relabeling of the role (e.g. "Mesero" -> "Mesero de banquetes"),
		// so it supersedes the role name wherever the assignment is displayed
		public string DisplayName
		{
			get
			{
				return Variation.Id != 0 ? Variation.Name : Role.Name;
			}
		}

		public void PropertiesToUpper()
		{
			Institution.PropertiesToUpper();
			Role.PropertiesToUpper();
			Variation.PropertiesToUpper();
		}
	}
}
