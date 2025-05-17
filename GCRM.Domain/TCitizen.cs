using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCRM.Domain.Enums;

namespace GCRM.Domain
{
	public class TCitizen : TEntity
	{
		public int Id;
		public string Name = "";
		public string PaternalName = "";
		public string MaternalName = "";
		public TCitizenTitle Title;
		public string CURP;
		public DateTime Birthday;
		public string Observations;
		public TSex Sex;
		public TAddress Address = new TAddress();
		public TCitizen Assistant;
		public TCitizenContactNumber Phone = new TCitizenContactNumber();
		public TCitizenContactNumber Phone2 = new TCitizenContactNumber();
		public TCitizenContactNumber Phone3 = new TCitizenContactNumber();
		public string Cellphone;
		public string Email;
		public TPoliticalParty PoliticalParty;
		public TInstitution Institution = new TInstitution();
		public TInstitution Institution2 = new TInstitution();
		public TInstitution Institution3 = new TInstitution();
		public TInstitutionRole Role = new TInstitutionRole();
		public TInstitutionRole Role2 = new TInstitutionRole();
		public TInstitutionRole Role3 = new TInstitutionRole();
		public TUser Author = new TUser();
		public DateTime CreatedDate;
		public TUser LastEditor = new TUser();
		public DateTime EditDate;

		public string VoterCode;
		public string VoterOCR;
		public string VoterCIC;
		public string VoterSection;

		public bool AttentionRequired;

		public List<TCitizenRelationship> Relationships = new List<TCitizenRelationship>();

		// this parameter will have the relationship the current user related citizen has with this user
		// so in a way is kind of the other way around, as the relationships array
		public TCitizenRelationship UserRelationship;

		public bool IsPoliticalActivist;
		public DateTime PoliticalRegisterDate;

		public bool KnownBirthday;
		public bool KnownBirthyear;
		public bool KnownPoliticalRegisterDate;

		public TCitizenCategory Category = new TCitizenCategory();

		public string FullName
		{
			get
			{
				return $"{Name} {PaternalName} {MaternalName}";
			}
		}

		private string GetNameStringWithFirstCapitals(string name_string)
		{
			List<string> word_list = name_string.Split(' ').ToList();
			string[] uncapitalizable_words = { "de", "del", "la" };

			string formated_name = "";

			foreach (string word in word_list)
			{
				string formated_word = word;

				if (uncapitalizable_words.Contains(word.ToLower()) == false)
				{
					if (formated_word.Length == 0)
						continue;

					formated_word = formated_word.First().ToString().ToUpper() + formated_word.Substring(1).ToLower();
				}
				else
				{
					formated_word = formated_word.ToLower();
				}

				formated_name += formated_word + " ";
			}

			return formated_name.Trim();
		}

		public string FullNameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(FullName);
			}
		}

		public string NameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(Name);
			}
		}

		public string MaternalNameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(MaternalName);
			}
		}

		public string PaternalNameWithFirstCapitals
		{
			get
			{
				return GetNameStringWithFirstCapitals(PaternalName);
			}
		}

		public string DisplayBirthday
		{
			get
			{
				string birthday = "";

				if (KnownBirthday)
				{
					string day = Birthday.ToString("dd");
					string month = Birthday.ToString("MMMM").ToUpper().First() + Birthday.ToString("MMMM").Substring(1);
					string year = Birthday.ToString("yyyy");

					birthday += $"{day} de {month}";

					if (KnownBirthyear)
					{
						birthday += $" de {year}";
					}
				}

				return birthday;
			}
		}

		public void FillFromReader(DbDataReader reader)
		{
			Assistant = new TCitizen();
			Institution = new TInstitution();
			UserRelationship = new TCitizenRelationship();

			Id = reader.GetInt32(0);
			Name = reader.GetString(1);
			PaternalName = reader.GetString(2);
			MaternalName = reader.GetString(3);
			Title = (TCitizenTitle)reader.GetInt32(4);
			CURP = reader.GetString(5);
			Birthday = reader.GetDateTime(6);
			Observations = reader.GetString(7);
			Sex = (TSex)reader.GetInt32(8);
			Address.Id = reader.GetInt32(9);
			Assistant.Id = reader.GetInt32(10);
			Phone.Number = reader.GetString(11);
			Phone.Extension = reader.GetString(12);
			Cellphone = reader.GetString(13);
			PoliticalParty = (TPoliticalParty)reader.GetInt32(14);
			Institution.Id = reader.GetInt32(15);
			Role.Id = reader.GetInt32(16);
			Email = reader.GetString(17);
			Author.Id = reader.GetInt32(18);
			CreatedDate = reader.GetDateTime(19);
			LastEditor.Id = reader.GetInt32(20);
			EditDate = reader.GetDateTime(21);
			VoterCode = reader.GetString(22);
			VoterOCR = reader.GetString(23);
			VoterCIC = reader.GetString(24);
			VoterSection = reader.GetString(25);
			Category.Id = reader.GetInt32(26);
			Institution2.Id = reader.GetInt32(27);
			Role2.Id = reader.GetInt32(28);
			Institution3.Id = reader.GetInt32(29);
			Role3.Id = reader.GetInt32(30);
			AttentionRequired = reader.GetBoolean(31);
			IsPoliticalActivist = reader.GetBoolean(32);
			PoliticalRegisterDate = reader.GetDateTime(33);
			Phone2.Number = reader.GetString(34);
			Phone2.Extension = reader.GetString(35);
			Phone3.Number = reader.GetString(36);
			Phone3.Extension = reader.GetString(37);

			// if the value of the template is set for the role, then it is a template role 
			Role.InstitutionTemplateId = reader.GetInt32(38);
			Role2.InstitutionTemplateId = reader.GetInt32(39);
			Role3.InstitutionTemplateId = reader.GetInt32(40);

			KnownBirthday = reader.GetBoolean(41);
			KnownBirthyear = reader.GetBoolean(42);
			KnownPoliticalRegisterDate = reader.GetBoolean(43);
		}

		public void PropertiesToUpper()
		{
			Name = Name.ToUpper();
			PaternalName = PaternalName.ToUpper();
			MaternalName = MaternalName.ToUpper();
			CURP = CURP.ToUpper();
			Observations = Observations.ToUpper();
			Address.PropertiesToUpper();
			if (Assistant != null)
			{
				Assistant.Name.ToUpper();
				Assistant.PaternalName.ToUpper();
				Assistant.PaternalName.ToUpper();
			}
			Email = Email.ToUpper();
			Institution.PropertiesToUpper();
			Institution2.PropertiesToUpper();
			Institution3.PropertiesToUpper();
			Role.PropertiesToUpper();
			Role2.PropertiesToUpper();
			Role3.PropertiesToUpper();
			VoterCode = VoterCode.ToUpper();
			VoterOCR = VoterOCR.ToUpper();
			VoterCIC = VoterCIC.ToUpper();
			VoterSection = VoterSection.ToUpper();
			Category.PropertiesToUpper();
		}

		public override string GetAsLogString()
		{
			StringBuilder log_string = new StringBuilder();

			log_string.AppendLine($"Id:              \t{Id}");
			log_string.AppendLine($"Name:            \t{Name}");
			log_string.AppendLine($"Paternal Name:   \t{PaternalName}");
			log_string.AppendLine($"Maternal Name:   \t{MaternalName}");
			log_string.AppendLine($"Title:           \t{Title}");
			log_string.AppendLine($"CURP:            \t{CURP}");
			log_string.AppendLine($"Known Birthday:  \t{KnownBirthday}");
			log_string.AppendLine($"Known Birthyear: \t{KnownBirthyear}");
			log_string.AppendLine($"Birthday:        \t{Birthday}");
			log_string.AppendLine($"Observations:    \t{Observations}");
			log_string.AppendLine($"Sex:             \t{Sex}");
			log_string.AppendLine($"Address:         \t{Address.Id}");
			log_string.AppendLine($"Assistant:       \t{Assistant.Id}");
			log_string.AppendLine($"Phone:           \t{Phone.Number}");
			log_string.AppendLine($"Phone Ext:       \t{Phone.Extension}");
			log_string.AppendLine($"Phone2:          \t{Phone2.Number}");
			log_string.AppendLine($"Phone2 Ext:      \t{Phone2.Extension}");
			log_string.AppendLine($"Phone3:          \t{Phone3.Number}");
			log_string.AppendLine($"Phone3 Ext:      \t{Phone3.Extension}");
			log_string.AppendLine($"Cellphone:       \t{Cellphone}");
			log_string.AppendLine($"Email:           \t{Email}");
			log_string.AppendLine($"Political Party: \t{PoliticalParty}");
			log_string.AppendLine($"Institution:     \t{Institution.Id}");
			log_string.AppendLine($"Role:            \t{Role.Id}");
			log_string.AppendLine($"Author:          \t{Author.Id}");
			log_string.AppendLine($"Created Date:    \t{CreatedDate}");
			log_string.AppendLine($"Last Editor:     \t{LastEditor.Id}");
			log_string.AppendLine($"Edit Date:       \t{EditDate}");
			log_string.AppendLine($"Category:        \t{Category.Id}");
			log_string.AppendLine($"Institution2:    \t{Institution2.Id}");
			log_string.AppendLine($"Role2:           \t{Role2.Id}");
			log_string.AppendLine($"Institution3:    \t{Institution3.Id}");
			log_string.AppendLine($"Role3:           \t{Role3.Id}");

			log_string.AppendLine($"Attention Required:\t{AttentionRequired}");

			log_string.AppendLine($"Voter Code:      \t{VoterCode}");
			log_string.AppendLine($"Voter OCR:       \t{VoterOCR}");
			log_string.AppendLine($"Voter CIC:       \t{VoterCIC}");
			log_string.AppendLine($"Voter Section:   \t{VoterSection}");
			log_string.AppendLine($"Is Political Activist:\t{IsPoliticalActivist}");
			log_string.AppendLine($"Knonw political register Date: \t{KnownPoliticalRegisterDate}");
			log_string.AppendLine($"Political Register Date:\t{PoliticalRegisterDate}");

			return log_string.ToString();
		}
	}
}
