using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain.Enums
{
	public enum TEventLogType
	{
		unknown = 0,

		citizen_add = 1001,
		citizen_edit = 1002,
		citizen_delete = 1003,
		citizen_attention_required = 1004,

		citizen_category_add = 1501,
		citizen_category_edit = 1502,
		citizen_category_delete = 1503,

		institution_add = 2001,
		institution_edit = 2002,
		institution_delete = 2003,
		institution_attention_required = 2004,

		institution_category_add = 2501,
		institution_category_edit = 2502,
		institution_category_delete = 2503,

		user_login = 3010
	}
}
