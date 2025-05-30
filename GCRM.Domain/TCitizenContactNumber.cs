using GCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Domain
{
	public class TCitizenContactNumber
	{
		public int Id;
		public string Number = "";
		public string Extension = "";
		public TContactNumberType ContactNumberType = TContactNumberType.work_landline;
		public bool CarddavSync = false;

		public TCitizenContactNumber() { }
		
		public TCitizenContactNumber(TContactNumberType type, bool carddav_sync = false) 
		{ 
			ContactNumberType = type;
			CarddavSync = carddav_sync;
		}


		private string GetNumericString(string raw_string)
		{
			string clean_string = "";

			foreach (char character in raw_string)
			{
				if (Char.IsNumber(character))
				{
					clean_string += character;
				}
			}

			return clean_string;
		}

		public string NumericNumber
		{
			get
			{
				return GetNumericString(Number);
			}
		}

		public string NumericExtension
		{
			get
			{
				return GetNumericString(Extension);
			}
		}

		public string FullNumber
		{
			get
			{
				string number = "";

				if (Number.Length > 0)
				{
					number += Number;

					if (Extension.Length > 0)
					{
						number += $" Ext. {Extension}";
					}
				}

				return number;
			}
		}

		public string FullNumberWithPrefix
		{
			get
			{
				if (FullNumber.Length > 0)
				{
					return "Tel. " + FullNumber;
				}

				return FullNumber;
			}
		}
	}
}