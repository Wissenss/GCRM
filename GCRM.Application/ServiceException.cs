using GCRM.Domain.Enums;

namespace GCRM.Application
{
	public class ServiceException : ApplicationException
	{
		Error Error { get; }

		public ServiceException(Error error) : base(Errors.GetErrorDescription(error))
		{
			Error = error;

			HResult = (int)error;
		}
	}
}
