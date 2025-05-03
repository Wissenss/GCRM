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
		UserUnauthorized,
		UserRepeatedUsername,
		UserGroupNotFound,
		UserGroupInUse,

		// errors related to citizens
		CitizenNotFound,
		CitizenWithSameCURP,
		CitizenWithSameName,
		CitizenWithSameVoterCode,
		CitizenInUse,
		CitizenCategoryNotFound,
		CitizenCategoryInUse,
		CitizenRelationshipNotFound,
		CitizenRelationshipRoleNotFound,

		// errors related to institutions
		InstitutionNotFound,
		InstitutionInUse,
		InstitutionRepeatedName,
		InstitutionRoleNotFound,
		InstitutionRoleInUser,
		
		InstitutionCategoryNotFound,
		InstitutionCategoryInUse,

		InstitutionTemplateNotFound,
		InstitutionTemplateInUse,
		InstitutionTemplateRoleNotFound,
		InstitutionTemplateRoleInUse,

		// errors related to settings
		SettingNotFound,

		// errors related to addresses
		AddressNotFound,

		// errors related to citizen networks
		CitizenNetworkNotFound,
		CitizenNetworkRoleNotFound,
		CitizenNetworkMemberNotFound,
		CitizenNetworkRoleInUse,
		CitizenNetworkMemberInUse
	}

	public static class Errors
	{
		private static readonly Dictionary<Error, string> DescriptionsMapping = new Dictionary<Error, string>()
		{
			{ Error.LoginInvalid, "Login inválido" },
			{ Error.UserNotFound, "Usuario no encontrado" },
			{ Error.UserUnauthorized, "Usuario no tiene autorizada esta acción" },
			{ Error.UserRepeatedUsername, "Existe un usuario con el mismo nombre de usuario" },
			{ Error.UserGroupNotFound, "Grupo de usuario no encontrado" }, 
			{ Error.UserGroupInUse, "Grupo de usuario esta siendo utilizado" },
			{ Error.CitizenNotFound, "Ciudadano no encontrado" },
			{ Error.CitizenWithSameCURP, "Existe un ciudadano con la misma clave CURP" },
			{ Error.CitizenWithSameName, "Existe un ciudadano con el mismo nombre" },
			{ Error.CitizenInUse, "Ciudadano esta siendo utilizado" },
			{ Error.CitizenRelationshipNotFound, "Relacion ciudadana no encontrada" },
			{ Error.CitizenRelationshipRoleNotFound, "Rol de relación ciudadana no encontrado" },
			{ Error.InstitutionNotFound, "Institución no encontrada" },
			{ Error.InstitutionInUse, "Institución esta siendo utilizada" },
			{ Error.InstitutionRepeatedName, "Existe una institución con el mismo nombre" },
			{ Error.InstitutionRoleNotFound, "Cargo de institución no encontrado" },
			{ Error.InstitutionRoleInUser, "Cargo de institución esta siendo utilizado" },
			{ Error.InstitutionCategoryNotFound, "Categoría de institución no encontrada" },
			{ Error.InstitutionCategoryInUse, "Categoría de institutción esta siendo utilizada" },
			{ Error.InstitutionTemplateNotFound, "Plantilla de institutción no encontrada" },
			{ Error.InstitutionTemplateInUse, "Plantilla de institución esta siendo utilizada" },
			{ Error.InstitutionTemplateRoleNotFound, "Cargo de plantilla de institución no encontrado" },
			{ Error.InstitutionTemplateRoleInUse, "Cargo de plantilla de institución esta siendo utilizado" },
			{ Error.SettingNotFound, "No se encontró la configuración en la base de datos" },
			{ Error.AddressNotFound, "Dirección no encontrada" },
			{ Error.CitizenNetworkNotFound, "Estructura ciudadana no encontrada" },
			{ Error.CitizenNetworkRoleNotFound, "Rol de estructura ciudadana no encontrado" },
			{ Error.CitizenNetworkMemberNotFound, "Miembro de estructura ciudadana no encontrado" },
			{ Error.CitizenNetworkRoleInUse, "Rol de estructura ciudadano esta siendo utilizado" },
			{ Error.CitizenNetworkMemberInUse, "Miembro de estructura ciudadana esta siendo utilizado" }
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
