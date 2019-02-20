using System;
using System.IO;
using System.Text;

namespace FreamWork.Log
{
	public class LogHelp : ILog
	{
		private string dbkey;

		public LogHelp(string dbkey)
		{
			this.dbkey = dbkey;
		}

		public int WriteErrorLog(ErrorLogObject errorlogobject)
		{
			errorlogobject.ErrorSQL = Tool.InspectLength(errorlogobject.ErrorSQL, 1000);
			errorlogobject.ErrorMessage = Tool.InspectLength(errorlogobject.ErrorMessage, 500);
			errorlogobject.ErrorData = Tool.InspectLength(errorlogobject.ErrorData, 500);
			errorlogobject.ErrorAddress = Tool.InspectLength(errorlogobject.ErrorAddress, 100);
			errorlogobject.ErrorCode = Tool.InspectLength(errorlogobject.ErrorCode, 500);
			LogHelpDataAccess logHelpDataAccess = new LogHelpDataAccess(this.dbkey);
			return logHelpDataAccess.InsertErrorLog(errorlogobject);
		}

		public int WriteLoginLog(string UserID, string IPAddress, string ClientType)
		{
			UserID = Tool.InspectBitLength(UserID, 20, "");
			IPAddress = Tool.InspectBitLength(IPAddress, 40, "");
			ClientType = Tool.InspectLength(ClientType, 10);
			LogHelpDataAccess logHelpDataAccess = new LogHelpDataAccess(this.dbkey);
			return logHelpDataAccess.Insertloginlog(UserID, IPAddress, ClientType);
		}

		public int WriteOperateLog(OperateLogObject operateLogObject)
		{
			operateLogObject.UserID = Tool.InspectBitLength(operateLogObject.UserID, 20, "");
			operateLogObject.IPAddress = Tool.InspectBitLength(operateLogObject.IPAddress, 40, "");
			operateLogObject.ClientType = Tool.InspectLength(operateLogObject.ClientType, 10);
			operateLogObject.OperateData = Tool.InspectLength(operateLogObject.OperateData, 1000);
			operateLogObject.OperateKey = Tool.InspectLength(operateLogObject.OperateKey, 100);
			operateLogObject.OperateMethod = Tool.InspectLength(operateLogObject.OperateMethod, 100);
			operateLogObject.OperateTable = Tool.InspectLength(operateLogObject.OperateTable, 100);
			LogHelpDataAccess logHelpDataAccess = new LogHelpDataAccess(this.dbkey);
			return logHelpDataAccess.InsertOperateLog(operateLogObject);
		}

		public void WriteTxtLog(string filename, string errorlog)
		{
			using (FileStream fileStream = File.Open(filename, FileMode.Append))
			{
				errorlog = errorlog + "\r\n****************************************" + DateTime.Now.ToLongTimeString() + "************************************************\r\n";
				byte[] bytes = Encoding.Default.GetBytes(errorlog);
				fileStream.Write(bytes, 0, bytes.Length);
				fileStream.Close();
			}
		}
	}
}
