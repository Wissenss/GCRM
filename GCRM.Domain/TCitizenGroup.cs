using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TCitizenGroup
	{
		public int Id;
		public string Name;
		public string Description;
		public List<TCitizen> Members;

		public TCitizenGroup() { }
	}
}
