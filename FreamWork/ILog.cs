using System;

namespace FreamWork
{
	public interface ILog
	{
		int WriteErrorLog(ErrorLogObject errorlogobject);

		int WriteLoginLog(string UserID, string IPAddress, string ClientType);

		int WriteOperateLog(OperateLogObject operateLogObject);

		void WriteTxtLog(string filename, string errorlog);
	}
}
