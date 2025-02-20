using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public enum Error
	{
		None = 0,

		// errors related to the session
		LoginInvalid,

		// errors related to users
		UserNotFound,

		// errors related to citizens
		CitizenNotFound,
		CitizenWithSameCURP,

		// errors related to institutions
		InstitutionNotFound,
		InstitutionRoleNotFound,
		InstitutionCategoryNotFound,
		InstitutionCategoryInUse,

		// errors related to settings
		SettingNotFound,

		// errors related to addresses
		AddressNotFound,
	}

	public static class Errors
	{
		private static readonly Dictionary<Error, string> DescriptionsMapping = new Dictionary<Error, string>()
		{
			{ Error.LoginInvalid, "Login inválido" },
			{ Error.UserNotFound, "Usuario no encontrado" },
			{ Error.CitizenNotFound, "Ciudadano no encontrado" },
			{ Error.CitizenWithSameCURP, "La clave CURP ya existe" },
			{ Error.InstitutionNotFound, "Institución no encontrada" },
			{ Error.InstitutionRoleNotFound, "Cargo de institución no encontrado" },
			{ Error.InstitutionCategoryNotFound, "Categoría de institución no encontrada" },
			{ Error.InstitutionCategoryInUse, "Categoría de institutción esta siendo utilizada" },
			{ Error.SettingNotFound, "No se encontró la configuración en la base de datos" },
			{ Error.AddressNotFound, "Dirección no encontrada" },
		};

		public static string GetErrorDescription(Error error)
		{
			if (DescriptionsMapping.ContainsKey(error) == false)
			{
				return "undefined error";
			}

			return DescriptionsMapping[error];
		}
	}
}
