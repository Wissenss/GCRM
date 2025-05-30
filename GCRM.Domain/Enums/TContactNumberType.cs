using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain.Enums
{
	public enum TContactNumberType
	{
		unknown = 0,

		personal_mobile = 1,
		personal_landline = 2,
		personal_home = 3,

		work_mobile = 20,
		work_landline = 21,
		work_landline_direct = 22,
	}
}
