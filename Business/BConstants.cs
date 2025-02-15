using System.IO;

namespace Business
{
	public enum TSocietySector
	{
		Health = 1,
		Government = 2,
		Business = 3,
		Agricultural = 4,
		Social = 5
	}

	public enum TCitizenTitle
	{
		None = 0,
		
		DegreeLevel = 1,
		Engineneer = 2,
		Master = 3,
		PhD = 4,

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

	public static class BConstants
	{
		public static string GetSocietySectorName(TSocietySector sector)
		{
			Dictionary<TSocietySector, string> mapping = new Dictionary<TSocietySector, string>()
			{
				{ TSocietySector.Health, "Salud" },
				{ TSocietySector.Government, "Gobierno" },
				{ TSocietySector.Business, "Empresarial" },
				{ TSocietySector.Agricultural, "Agropecuario" },
				{ TSocietySector.Social, "Social" }
			};

			return mapping[sector];
		}

		public static string GetCitizenFullTitle(TCitizenTitle title)
		{
			Dictionary<TCitizenTitle, string> mapping = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "Ciudadano" },

				{ TCitizenTitle.DegreeLevel, "Licenciado" },
				{ TCitizenTitle.Engineneer, "Ingeniero" },
				{ TCitizenTitle.Master, "Maestro" },
				{ TCitizenTitle.PhD, "Doctor" },

				{ TCitizenTitle.PublicAccountant, "Contador Público" },
				{ TCitizenTitle.Councilor, "Regidor" },
				{ TCitizenTitle.Syndic, "Síndico" },
				{ TCitizenTitle.MunicipalPresident, "Presidente Municipal" },
				{ TCitizenTitle.Governor, "Gobernador" },

				{ TCitizenTitle.LocalCongressman, "Diputado Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado Federal" },
				{ TCitizenTitle.Senator, "Senador" },
				{ TCitizenTitle.President, "Presiendet de la República" }
			};

			return mapping[title];
		}

		public static string GetCitizenBriefTitle(TCitizenTitle title)
		{
			Dictionary<TCitizenTitle, string> mapping = new Dictionary<TCitizenTitle, string>()
			{
				{ TCitizenTitle.None, "C." },

				{ TCitizenTitle.DegreeLevel, "Lic." },
				{ TCitizenTitle.Engineneer, "Ing." },
				{ TCitizenTitle.Master, "Mtro." },
				{ TCitizenTitle.PhD, "Doc." },

				{ TCitizenTitle.PublicAccountant, "CP." },
				{ TCitizenTitle.Councilor, "Regidor" },
				{ TCitizenTitle.Syndic, "Síndico" },
				{ TCitizenTitle.MunicipalPresident, "Presidente Municipal" },
				{ TCitizenTitle.Governor, "Gobernador" },

				{ TCitizenTitle.LocalCongressman, "Diputado Local" },
				{ TCitizenTitle.FederalCongressman, "Diputado" },
				{ TCitizenTitle.Senator, "Senador" },
				{ TCitizenTitle.President, "Presidente" }
			};

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
	}
}
