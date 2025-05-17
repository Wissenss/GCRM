using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GCRM.Domain.Enums;

namespace GCRM.Shared
{
	public static class BConstants
	{
		public static string GetSocietySectorName(TSocietySector sector)
		{
			Dictionary<TSocietySector, string> mapping = new Dictionary<TSocietySector, string>()
			{
				{ TSocietySector.None, "Ninguno" },
				{ TSocietySector.Health, "Salud" },
				{ TSocietySector.Government, "Gobierno" },
				{ TSocietySector.Business, "Empresarial" },
				{ TSocietySector.Agricultural, "Agropecuario" },
				{ TSocietySector.Social, "Social" },
				{ TSocietySector.Educational, "Educativo" }
			};

			return mapping[sector];
		}

		public static string GetCitizenFullTitle(TCitizenTitle title, TSex sex = TSex.Unknown)
		{
			Dictionary<TCitizenTitle, string> mapping = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "Ciudadano(a)" },

				{ TCitizenTitle.DegreeLevel, "Licenciado(a)" },
				{ TCitizenTitle.Engineneer, "Ingeniero(a)" },
				{ TCitizenTitle.Master, "Maestro(a)" },
				{ TCitizenTitle.PhD, "Doctor(a)" },
				{ TCitizenTitle.Arq, "Arquitecto(a)" },
				{ TCitizenTitle.Technician, "Técnico(a)" },
				{ TCitizenTitle.Biologist, "Biólogo(a)" },
				{ TCitizenTitle.Lawyer, "Abogado(a)" },

				{ TCitizenTitle.PublicAccountant, "Contador(a) Público" },
				{ TCitizenTitle.Councilor, "Regidor(a)" },
				{ TCitizenTitle.Syndic, "Síndico(a)" },
				{ TCitizenTitle.MunicipalPresident, "Presidente(a) Municipal" },
				{ TCitizenTitle.Governor, "Gobernador(a)" },

				{ TCitizenTitle.LocalCongressman, "Diputado(a) Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado(a) Federal" },
				{ TCitizenTitle.Senator, "Senador(a)" },
				{ TCitizenTitle.President, "Presiente(a) de la República" },

				{ TCitizenTitle.Priest, "Sacerdote" },
				{ TCitizenTitle.Shepherd, "Pastor" },
				{ TCitizenTitle.Nun, "Monja" }
			};

			Dictionary<TCitizenTitle, string> mapping_male = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "Ciudadano" },

				{ TCitizenTitle.DegreeLevel, "Licenciado" },
				{ TCitizenTitle.Engineneer, "Ingeniero" },
				{ TCitizenTitle.Master, "Maestro" },
				{ TCitizenTitle.PhD, "Doctor" },
				{ TCitizenTitle.Arq, "Arquitecto" },
				{ TCitizenTitle.Technician, "Técnico" },
				{ TCitizenTitle.Biologist, "Biólogo" },
				{ TCitizenTitle.Lawyer, "Abogado" },

				{ TCitizenTitle.PublicAccountant, "Contador Público" },
				{ TCitizenTitle.Councilor, "Regidor" },
				{ TCitizenTitle.Syndic, "Síndico" },
				{ TCitizenTitle.MunicipalPresident, "Presidente Municipal" },
				{ TCitizenTitle.Governor, "Gobernador" },

				{ TCitizenTitle.LocalCongressman, "Diputado Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado Federal" },
				{ TCitizenTitle.Senator, "Senador" },
				{ TCitizenTitle.President, "Presidente de la República" }
			};

			Dictionary<TCitizenTitle, string> mapping_female = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "Ciudadana" },

				{ TCitizenTitle.DegreeLevel, "Licenciada" },
				{ TCitizenTitle.Engineneer, "Ingeniera" },
				{ TCitizenTitle.Master, "Maestra" },
				{ TCitizenTitle.PhD, "Doctora" },
				{ TCitizenTitle.Arq, "Arquitecta" },
				{ TCitizenTitle.Technician, "Técnica" },
				{ TCitizenTitle.Biologist, "Bióloga" },
				{ TCitizenTitle.Lawyer, "Abogada" },

				{ TCitizenTitle.PublicAccountant, "Contadora Pública" },
				{ TCitizenTitle.Councilor, "Regidora" },
				{ TCitizenTitle.Syndic, "Síndica" },
				{ TCitizenTitle.MunicipalPresident, "Presidenta Municipal" },
				{ TCitizenTitle.Governor, "Gobernadora" },

				{ TCitizenTitle.LocalCongressman, "Diputada Local" },
				{ TCitizenTitle.FederalCongressman, "Diputada Federal" },
				{ TCitizenTitle.Senator, "Senadora" },
				{ TCitizenTitle.President, "Presidenta de la República" }
			};

			string title_str = mapping[title];

			if (sex == TSex.Female && mapping_female.ContainsKey(title))
				title_str = mapping_female[title];
			else if (sex == TSex.Male && mapping_male.ContainsKey(title))
				title_str = mapping_male[title];

			return title_str;
		}

		public static string GetCitizenBriefTitle(TCitizenTitle title, TSex sex = TSex.Unknown)
		{
			Dictionary<TCitizenTitle, string> mapping = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "C." },

				{ TCitizenTitle.DegreeLevel, "Lic." },
				{ TCitizenTitle.Engineneer, "Ing." },
				{ TCitizenTitle.Master, "M." },
				{ TCitizenTitle.PhD, "Dr." },
				{ TCitizenTitle.Arq, "Arq." },
				{ TCitizenTitle.Technician, "Tec." },
				{ TCitizenTitle.Biologist, "Bio." },
				{ TCitizenTitle.Lawyer, "Abg." },

				{ TCitizenTitle.PublicAccountant, "C.P." },
				{ TCitizenTitle.Councilor, "Regidor(a)" },
				{ TCitizenTitle.Syndic, "Síndico(a)" },
				{ TCitizenTitle.MunicipalPresident, "Presidente(a) Municipal" },
				{ TCitizenTitle.Governor, "Gobernador(a)" },

				{ TCitizenTitle.LocalCongressman, "Dip." },
				{ TCitizenTitle.FederalCongressman, "Dip." },
				{ TCitizenTitle.Senator, "Sen." },
				{ TCitizenTitle.President, "Presidente(a)" },

				{ TCitizenTitle.Priest, "Pbro." },
				{ TCitizenTitle.Shepherd, "Pr." },
				{ TCitizenTitle.Nun, "Hna." }
			};

			Dictionary<TCitizenTitle, string> mapping_male = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.Master, "Mtro." },
				{ TCitizenTitle.PhD, "Dr." },

				{ TCitizenTitle.Councilor, "Regidor" },
				{ TCitizenTitle.Syndic, "Síndico" },
				{ TCitizenTitle.MunicipalPresident, "Presidente Municipal" },
				{ TCitizenTitle.Governor, "Gobernador" },

				{ TCitizenTitle.LocalCongressman, "Diputado Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado" },
				{ TCitizenTitle.Senator, "Senador" },
				{ TCitizenTitle.President, "Presidente" }
			};

			Dictionary<TCitizenTitle, string> mapping_female = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.Master, "Mtra." },
				{ TCitizenTitle.PhD, "Dra." },

				{ TCitizenTitle.Councilor, "Regidora" },
				{ TCitizenTitle.Syndic, "Síndica" },
				{ TCitizenTitle.MunicipalPresident, "Presidenta Municipal" },
				{ TCitizenTitle.Governor, "Gobernadora" },

				{ TCitizenTitle.LocalCongressman, "Diputada Local" },
				{ TCitizenTitle.FederalCongressman, "Diputada" },
				{ TCitizenTitle.Senator, "Senadora" },
				{ TCitizenTitle.President, "Presidenta" }
			};


			string title_str = mapping[title];

			if (sex == TSex.Female && mapping_female.ContainsKey(title))
				title_str = mapping_female[title];
			else if (sex == TSex.Male && mapping_male.ContainsKey(title))
				title_str = mapping_male[title];

			return title_str;
		}

		public static string GetCountryCommonName(TCountry country)
		{
			Dictionary<TCountry, string> mapping = new Dictionary<TCountry, string>
			{
				{ TCountry.MXN, "México" },
				{ TCountry.USA, "Estados Unidos" }
			};

			return mapping[country];
		}

		public static string GetCountryOfficialName(TCountry country)
		{
			Dictionary<TCountry, string> mapping = new Dictionary<TCountry, string>
			{
				{ TCountry.MXN, "Estados Unidos Mexicanos" },
				{ TCountry.USA, "Estados Unidos de América" }
			};

			return mapping[country];
		}

		public static string GetPoliticalPartyCommonName(TPoliticalParty party)
		{
			Dictionary<TPoliticalParty, string> mapping = new Dictionary<TPoliticalParty, string>()
			{
				{ TPoliticalParty.None, "Ninguno" },
				{ TPoliticalParty.PAN, "PAN" },
				{ TPoliticalParty.PRD, "PRD" },
				{ TPoliticalParty.MORENA, "Morena" },
				{ TPoliticalParty.PRI, "PRI" },
				{ TPoliticalParty.MC, "MC" },
				{ TPoliticalParty.PVEM, "PVEM" },
			};

			return mapping[party];
		}

		public static string GetPoliticalPartyOfficialName(TPoliticalParty party)
		{
			Dictionary<TPoliticalParty, string> mapping = new Dictionary<TPoliticalParty, string>()
			{
				{ TPoliticalParty.None, "Ninguno" },
				{ TPoliticalParty.PAN, "Partido Acción Nacional" },
				{ TPoliticalParty.PRD, "Partido de la Revolución Democrática" },
				{ TPoliticalParty.MORENA, "Morena" },
				{ TPoliticalParty.PRI, "Partido Revolucionario Institucional" },
				{ TPoliticalParty.MC, "Movimiento Ciudadano" },
				{ TPoliticalParty.PVEM, "Partido Verde Ecologista de México" },
			};

			return mapping[party];
		}

		public static string GetSexName(TSex sex)
		{
			Dictionary<TSex, string> mapping = new Dictionary<TSex, string>()
			{
				{ TSex.Unknown, "Desconocido" },
				{ TSex.Male, "Masculino" },
				{ TSex.Female, "Femenino" }
			};

			return mapping[sex];
		}

		public static string GetEventLogTypeName(TEventLogType event_log_type)
		{
			Dictionary<TEventLogType, string> mapping = new Dictionary<TEventLogType, string>
			{
				{ TEventLogType.unknown,                        "Desconocido" },
				{ TEventLogType.citizen_add,                    "Añadir ciudadano" },
				{ TEventLogType.citizen_edit,                   "Editar ciudadano" },
				{ TEventLogType.citizen_delete,                 "Eliminar ciudadano" },
				{ TEventLogType.citizen_attention_required,     "Ciudadano atención requerida" },
				{ TEventLogType.citizen_category_add,           "Añadir categoría ciudadana" },
				{ TEventLogType.citizen_category_edit,          "Editar categoría ciudadana" },
				{ TEventLogType.citizen_category_delete,        "Eliminar categoría ciudadana" },
				{ TEventLogType.institution_add,                "Añadir institución" },
				{ TEventLogType.institution_edit,               "Editar institución" },
				{ TEventLogType.institution_delete,             "Eliminar institución" },
				{ TEventLogType.institution_attention_required, "Institución atención requerido" },
				{ TEventLogType.institution_category_add,       "Añadir categoría ciudadana" },
				{ TEventLogType.institution_category_edit,      "Editar categoría ciudadana" },
				{ TEventLogType.institution_category_delete,    "Eliminar categoría ciudadana" },
			};

			return mapping[event_log_type];
		}

		public static string GetProductVersion()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
			string version = fileVersionInfo.ProductVersion;

			return version;
		}

		public static TSettingDatatype GetSettingDataTypeFromString(string _string)
		{
			Dictionary<string, TSettingDatatype> mapping = new Dictionary<string, TSettingDatatype>()
				{
					{ "string", TSettingDatatype.String },
					{ "boolean", TSettingDatatype.Boolean },
					{ "numeric", TSettingDatatype.Numeric },
					{ "blob", TSettingDatatype.Blob }
				};

			if (mapping.ContainsKey(_string) == false)
			{
				throw new ArgumentException($"no known convertion to SettingDatatype from string: '{_string}'", "_string");
			}

			return mapping[_string];
		}

		public static TSettingDatatype GetSettingDataTypeFromType(Type type)
		{
			Dictionary<Type, TSettingDatatype> mapping = new Dictionary<Type, TSettingDatatype>()
				{
					{ typeof(string),  TSettingDatatype.String },

					{ typeof(bool),    TSettingDatatype.Boolean },

					{ typeof(int),     TSettingDatatype.Numeric },
					{ typeof(decimal), TSettingDatatype.Numeric },
					{ typeof(double),  TSettingDatatype.Numeric },
					{ typeof(float),   TSettingDatatype.Numeric },
					{ typeof(long),    TSettingDatatype.Numeric },

					{ typeof(byte[]),  TSettingDatatype.Blob }
				};

			if (mapping.ContainsKey(type) == false)
			{
				throw new ArgumentException($"no known convertion to SettingDatatype from type: '{type.ToString()}'", "type");
			}

			return mapping[type];
		}
	}
}
