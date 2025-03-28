using System.IO;

namespace Business
{
	public enum TSocietySector
	{
		None = 0,

		Health = 1,
		Government = 2,
		Business = 3,
		Agricultural = 4,
		Social = 5,
		Educational = 6
	}

	public enum TCitizenTitle
	{
		None = 0,
		
		DegreeLevel = 1,
		Engineneer = 2,
		Master = 3,
		PhD = 4,
		Arq = 5,

		PublicAccountant	= 50,
		Councilor = 51,
		Syndic = 52,
		MunicipalPresident = 53,
		Governor = 54,

		LocalCongressman = 101,
		FederalCongressman = 102,
		Senator = 103,
		President = 104
	}

	public enum TCountry
	{
		MXN = 0,
		USA = 1
	}

	public enum TPoliticalParty
	{
		None = 0,

		PAN = 1,
		PRI = 2,
		PRD = 3,
		MC = 4,
		MORENA = 5
	}

	public enum TSex
	{
		Unknown = 0,
		Male = 1,
		Female = 2,
	}

	public enum TOperatingSystem
	{
		WindowsX64,
		WindowsX86,
	}

	public abstract class TEntity()
	{
		public abstract string GetAsLogString();
	}

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

				{ TCitizenTitle.PublicAccountant, "Contador(a) Público" },
				{ TCitizenTitle.Councilor, "Regidor(a)" },
				{ TCitizenTitle.Syndic, "Síndico(a)" },
				{ TCitizenTitle.MunicipalPresident, "Presidente(a) Municipal" },
				{ TCitizenTitle.Governor, "Gobernador(a)" },

				{ TCitizenTitle.LocalCongressman, "Diputado(a) Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado(a) Federal" },
				{ TCitizenTitle.Senator, "Senador(a)" },
				{ TCitizenTitle.President, "Presiente(a) de la República" }
			};

			if (sex == TSex.Male)
			{
				mapping = new Dictionary<TCitizenTitle, string>()
				{
					{ TCitizenTitle.None, "Ciudadano" },

					{ TCitizenTitle.DegreeLevel, "Licenciado" },
					{ TCitizenTitle.Engineneer, "Ingeniero" },
					{ TCitizenTitle.Master, "Maestro" },
					{ TCitizenTitle.PhD, "Doctor" },
					{ TCitizenTitle.Arq, "Arquitecto" },

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
			}

			if (sex == TSex.Female)
			{
				mapping = new Dictionary<TCitizenTitle, string>()
				{
					{ TCitizenTitle.None, "Ciudadana" },

					{ TCitizenTitle.DegreeLevel, "Licenciada" },
					{ TCitizenTitle.Engineneer, "Ingeniera" },
					{ TCitizenTitle.Master, "Maestra" },
					{ TCitizenTitle.PhD, "Doctora" },
					{ TCitizenTitle.Arq, "Arquitecta" },

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
			}

			return mapping[title];
		}

		public static string GetCitizenBriefTitle(TCitizenTitle title, TSex sex = TSex.Unknown)
		{
			Dictionary<TCitizenTitle, string> mapping = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "C." },

				{ TCitizenTitle.DegreeLevel, "Lic." },
				{ TCitizenTitle.Engineneer, "Ing." },
				{ TCitizenTitle.Master, "Mtro(a)." },
				{ TCitizenTitle.PhD, "Dr." },
				{ TCitizenTitle.Arq, "Arq." },

				{ TCitizenTitle.PublicAccountant, "CP." },
				{ TCitizenTitle.Councilor, "Regidor(a)" },
				{ TCitizenTitle.Syndic, "Síndico(a)" },
				{ TCitizenTitle.MunicipalPresident, "Presidente(a) Municipal" },
				{ TCitizenTitle.Governor, "Gobernador(a)" },

				{ TCitizenTitle.LocalCongressman, "Diputado(a) Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado(a)" },
				{ TCitizenTitle.Senator, "Senador(a)" },
				{ TCitizenTitle.President, "Presidente(a)" }
			};

			if (sex == TSex.Male)
			{
				mapping = new Dictionary<TCitizenTitle, string>()
				{
					{ TCitizenTitle.None, "C." },

					{ TCitizenTitle.DegreeLevel, "Lic." },
					{ TCitizenTitle.Engineneer, "Ing." },
					{ TCitizenTitle.Master, "Mtro." },
					{ TCitizenTitle.PhD, "Dr." },
					{ TCitizenTitle.Arq, "Arq." },

					{ TCitizenTitle.PublicAccountant, "C.P." },
					{ TCitizenTitle.Councilor, "Regidor" },
					{ TCitizenTitle.Syndic, "Síndico" },
					{ TCitizenTitle.MunicipalPresident, "Presidente Municipal" },
					{ TCitizenTitle.Governor, "Gobernador" },

					{ TCitizenTitle.LocalCongressman, "Diputado Local" },
					{ TCitizenTitle.FederalCongressman, "Diputado" },
					{ TCitizenTitle.Senator, "Senador" },
					{ TCitizenTitle.President, "Presidente" }
				};
			}

			if (sex == TSex.Female)
			{
				mapping = new Dictionary<TCitizenTitle, string>()
				{
					{ TCitizenTitle.None, "C." },

					{ TCitizenTitle.DegreeLevel, "Lic." },
					{ TCitizenTitle.Engineneer, "Ing." },
					{ TCitizenTitle.Master, "Mtra." },
					{ TCitizenTitle.PhD, "Dr." },
					{ TCitizenTitle.Arq, "Arq." },

					{ TCitizenTitle.PublicAccountant, "C.P." },
					{ TCitizenTitle.Councilor, "Regidora" },
					{ TCitizenTitle.Syndic, "Síndica" },
					{ TCitizenTitle.MunicipalPresident, "Presidenta Municipal" },
					{ TCitizenTitle.Governor, "Gobernadora" },

					{ TCitizenTitle.LocalCongressman, "Diputada Local" },
					{ TCitizenTitle.FederalCongressman, "Diputada" },
					{ TCitizenTitle.Senator, "Senadora" },
					{ TCitizenTitle.President, "Presidenta" }
				};
			}

			return mapping[title];
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
				{ TPoliticalParty.MC, "MC" }
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
				{ TPoliticalParty.MC, "Movimiento Ciudadano" }
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
				{ TEventLogType.unknown,                     "Desconocido" },
				{ TEventLogType.citizen_add,                 "Añadir ciudadano" },
				{ TEventLogType.citizen_edit,                "Editar ciudadano" },
				{ TEventLogType.citizen_delete,              "Eliminar ciudadano" },
				{ TEventLogType.citizen_category_add,        "Añadir categoría ciudadana" },
				{ TEventLogType.citizen_category_edit,       "Editar categoría ciudadana" },
				{ TEventLogType.citizen_category_delete,     "Eliminar categoría ciudadana" },
				{ TEventLogType.institution_add,             "Añadir institución" },
				{ TEventLogType.institution_edit,            "Editar institución" },
				{ TEventLogType.institution_delete,          "Eliminar institución" },
				{ TEventLogType.institution_category_add,    "Añadir categoría ciudadana" },
				{ TEventLogType.institution_category_edit,   "Editar categoría ciudadana" },
				{ TEventLogType.institution_category_delete, "Eliminar categoría ciudadana" },
			};

			return mapping[event_log_type];
		}
	}
}
