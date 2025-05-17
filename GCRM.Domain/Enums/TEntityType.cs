using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain.Enums
{
	public enum TEntityType
	{
		unknown = 0,

		user = 1,

		citizen = 1001,
		citizen_category = 1002,

		institution = 2001,
		institution_category = 2002,
	}
}
