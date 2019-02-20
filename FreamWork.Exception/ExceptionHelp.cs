using System;

namespace FreamWork.Exception
{
	public class ExceptionHelp : IException
	{
		private ILog Ilh;

		public ExceptionHelp(string logkey)
		{
			this.Ilh = ServicesManager.GetServicesManager().GetService<ILog>(logkey);
		}

		public void HandleExcept(System.Exception ex, string ExceptionCode)
		{
			this.HandleExcept(ex, ExceptionCode, null, null, true);
		}

		public void HandleExcept(System.Exception ex, string ExceptionCode, bool IsToClient)
		{
			this.HandleExcept(ex, ExceptionCode, null, null, IsToClient);
		}

        public void HandleExcept(System.Exception ex, string ExceptionCode, string ExceptSQL, bool IsToClient)
		{
			this.HandleExcept(ex, ExceptionCode, ExceptSQL, null, IsToClient);
		}

        public void HandleExcept(System.Exception ex, string ExceptionCode, string ExceptSQL, string ExcetptionAddreee, bool IsToClient)
		{
			ErrorLogObject errorLogObject = new ErrorLogObject
			{
				ErrorMessage = ex.Message,
				ErrorData = ex.StackTrace,
				ErrorCode = ExceptionCode,
				ErrorAddress = ExcetptionAddreee,
				ErrorSQL = ExceptSQL
			};
			if (string.IsNullOrEmpty(ExceptSQL))
			{
				errorLogObject.ErrorType = new int?(2);
			}
			else
			{
				errorLogObject.ErrorType = new int?(1);
			}
			this.Ilh.WriteErrorLog(errorLogObject);
			if (IsToClient)
			{
				throw new WCFException(ExceptionCode);
			}
		}
	}
}
