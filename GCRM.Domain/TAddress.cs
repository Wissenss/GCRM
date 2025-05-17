using GCRM.Domain.Enums;
using System.Data.Common;

namespace GCRM.Domain
{
	public class TAddress
	{
		public int Id;
		public string Street;
		public string Number;
		public string InteriorNumber;
		public string PostalCode;
		public string State;
		public string City;
		public TCountry Country;
		public string District;

		public string FullAddress
		{
			get
			{
				return GetFullAddress();
			}
		}

		public string GetFullAddress()
		{
			string full_address = "";

			if (Street?.Trim().Length > 0)
				full_address += $" {Street}";

			if (Number?.Trim().Length > 0)
				full_address += $" No. {Number} ";

			if (InteriorNumber?.Trim().Length > 0)
				full_address += $" Int. {InteriorNumber}";

			if (District?.Trim().Length > 0)
				full_address += $" {District}";

			if (State?.Trim().Length > 0)
				full_address += $" {State}";

			if (City?.Trim().Length > 0)
				full_address += $" {City}";

			if (PostalCode?.Trim().Length > 0)
				full_address += $" C.P. {PostalCode}";

			return full_address;
		}

		public void FillFromReader(DbDataReader reader)
		{
			Id = reader.GetInt32(0);
			Street = reader.GetString(1);
			Number = reader.GetString(2);
			InteriorNumber = reader.GetString(3);
			PostalCode = reader.GetString(4);
			State = reader.GetString(5);
			City = reader.GetString(6);
			Country = (TCountry)reader.GetInt32(7);
			District = reader.GetString(8);
		}

		public void PropertiesToUpper()
		{
			Street = Street.ToUpper();
			Number = Number.ToUpper();
			InteriorNumber = InteriorNumber.ToUpper();
			PostalCode = PostalCode.ToUpper();
			State = State.ToUpper();
			City = City.ToUpper();
			District = District.ToUpper();
		}
	}
}
