using System;

namespace FreamWork
{
	public interface IException
	{
		void HandleExcept(Exception ex, string ExceptionCode);

		void HandleExcept(Exception ex, string ExceptionCode, bool IsToClient);

		void HandleExcept(Exception ex, string ExceptionCode, string ExceptSQL, bool IsToClient);

		void HandleExcept(Exception ex, string ExceptionCode, string ExceptSQL, string ExcetptionAddreee, bool IsToClient);
	}
}
