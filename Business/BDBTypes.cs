using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public enum BDBTypeSettingDatatype
	{
		String,
		Boolean,
		Numeric,
	}

	public class BDBTypes
	{
		public static BDBTypeSettingDatatype GetSettingDataTypeFromString(string _string)
		{
			Dictionary<string, BDBTypeSettingDatatype> mapping = new Dictionary<string, BDBTypeSettingDatatype>()
				{
					{ "string", BDBTypeSettingDatatype.String },
					{ "boolean", BDBTypeSettingDatatype.Boolean },
					{ "numeric", BDBTypeSettingDatatype.Numeric },
				};

			if (mapping.ContainsKey(_string) == false)
			{
				throw new ArgumentException($"no known convertion to SettingDatatype from string: '{_string}'", "_string");
			}

			return mapping[_string];
		}

		public static BDBTypeSettingDatatype GetSettingDataTypeFromType(Type type)
		{
			Dictionary<Type, BDBTypeSettingDatatype> mapping = new Dictionary<Type, BDBTypeSettingDatatype>()
				{
					{ typeof(string),  BDBTypeSettingDatatype.String },

					{ typeof(bool),    BDBTypeSettingDatatype.Boolean },

					{ typeof(int),     BDBTypeSettingDatatype.Numeric },
					{ typeof(decimal), BDBTypeSettingDatatype.Numeric },
					{ typeof(double),  BDBTypeSettingDatatype.Numeric },
					{ typeof(float),   BDBTypeSettingDatatype.Numeric },
					{ typeof(long),    BDBTypeSettingDatatype.Numeric },
				};

			if (mapping.ContainsKey(type) == false)
			{
				throw new ArgumentException($"no known convertion to SettingDatatype from type: '{type.ToString()}'", "type");
			}

			return mapping[type];
		}
	}
}
