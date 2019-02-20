using System;

namespace FreamWork
{
	public class ErrorLogObject
	{
		public string ErrorAddress;

		public string ErrorCode;

		public string ErrorData;

		public string ErrorMessage;

		public string ErrorSQL;

		public int? ErrorType;

		public ErrorLogObject()
		{
		}

		public ErrorLogObject(string ErrorMessage, string ErrorAddress, string ErrorCode)
		{
			this.ErrorMessage = ErrorMessage;
			this.ErrorAddress = ErrorAddress;
			this.ErrorCode = ErrorCode;
		}

		public ErrorLogObject(string ErrorMessage, string ErrorAddress, string ErrorCode, string ErrorSQL)
		{
			this.ErrorMessage = ErrorMessage;
			this.ErrorAddress = ErrorAddress;
			this.ErrorCode = ErrorCode;
			this.ErrorSQL = ErrorSQL;
			this.ErrorType = new int?(1);
		}
	}
}
