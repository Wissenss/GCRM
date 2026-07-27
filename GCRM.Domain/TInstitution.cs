using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRM.Domain.Enums;

namespace GCRM.Domain
{
	public class TInstitution : TEntity
	{
		public int Id;
		public string Name = "";
		public string Description = "";
		public TSocietySector Sector;
		public TInstitutionCategory Category = new TInstitutionCategory();
		public List<TInstitutionRole> Roles;
		public TInstitution ParentInstitution;
		public TUser Author = new TUser();
		public DateTime CreatedDate;
		public TUser LastEditor = new TUser();
		public DateTime EditDate;
		public string Acronym = "";
		public bool AttentionRequired;
		public TInstitutionTemplate Template = new TInstitutionTemplate();
		public TAddress Address = new TAddress();

        public string NameWithFirstCapital
		{
			get
			{
				if (Name.Length == 0)
					return "";

				string formated_name = Name.ToLower();

				formated_name = formated_name.First().ToString().ToUpper() + formated_name.Substring(1);

				return formated_name;
			}
		}

		public void FillFromReader(DbDataReader reader)
		{
			ParentInstitution = new TInstitution();

			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			Sector = (TSocietySector)reader.GetInt32(2);
			Category.Id = reader.GetInt32(3);
			Description = reader.GetString(4);
			ParentInstitution.Id = reader.GetInt32(5);
			Author.Id = reader.GetInt32(6);
			CreatedDate = reader.GetDateTime(7);
			LastEditor.Id = reader.GetInt32(8);
			EditDate = reader.GetDateTime(9);
			Acronym = reader.GetString(10);
			AttentionRequired = reader.GetBoolean(11);
			Template.Id = reader.GetInt32(12);
			Address.Id = reader.IsDBNull(13) ? 0 : reader.GetInt32(13);
		}

		public void PropertiesToUpper()
		{
			Name = Name.ToUpper();
			Description = Description.ToUpper();
			Category.PropertiesToUpper();
			Acronym.ToUpper();
		}

		public override string GetAsLogString()
		{
			StringBuilder log_string = new StringBuilder();

			log_string.AppendLine($"Id:                  \t{Id}");
			log_string.AppendLine($"Name:                \t{Name}");
			log_string.AppendLine($"Description:         \t{Description}");
			log_string.AppendLine($"Sector:              \t{Sector}");
			log_string.AppendLine($"Category:            \t{Category.Id}");
			log_string.AppendLine($"Roles:               \t{Roles.Count}");
			log_string.AppendLine($"ParentInstitutionId: \t{ParentInstitution.Id}");
			log_string.AppendLine($"Author:              \t{Author.Id}");
			log_string.AppendLine($"CreatedDate:         \t{CreatedDate}");
			log_string.AppendLine($"LastEditor:          \t{LastEditor.Id}");
			log_string.AppendLine($"EditDate:            \t{EditDate}");
			log_string.AppendLine($"Acronym:             \t{Acronym}");
			log_string.AppendLine($"AttentionRequired:   \t{AttentionRequired}");
			log_string.AppendLine($"Template:            \t{Template.Id}");
			log_string.AppendLine($"Address:             \t{Address.GetFullAddress()}");
			log_string.AppendLine($"AddressState:        \t{Address.State}");
			log_string.AppendLine($"AddressCity:         \t{Address.City}");
			log_string.AppendLine($"AddressPostalCode:   \t{Address.PostalCode}");
			log_string.AppendLine($"AddressCountry:      \t{Address.Country}");

			return log_string.ToString();
		}
	}
}
