using System;
using System.Data;
using System.Data.Common;

namespace FreamWork.Log
{
	internal class LogHelpDataAccess
	{
		private IDB ish;

		public LogHelpDataAccess(string dbkey)
		{
			this.ish = ServicesManager.GetServicesManager().GetService<IDB>(dbkey);
		}

		internal int InsertErrorLog(ErrorLogObject InsertObject)
		{
			string text = " Insert into ErrorLog(";
			string text2 = "";
			DbParameter[] dBParms = Service.GetIDBparm("sql").GetDBParms(6);
			if (InsertObject.ErrorAddress != null)
			{
				text += "ErrorAddress,";
				text2 += "@ErrorAddress,";
				dBParms[0] = Service.GetIDBparm("sql").GetDBParm("@ErrorAddress", InsertObject.ErrorAddress);
			}
			if (InsertObject.ErrorData != null)
			{
				text += "ErrorData,";
				text2 += "@ErrorData,";
				dBParms[1] = Service.GetIDBparm("sql").GetDBParm("@ErrorData", InsertObject.ErrorData);
			}
			if (InsertObject.ErrorMessage != null)
			{
				text += "ErrorMessage,";
				text2 += "@ErrorMessage,";
				dBParms[2] = Service.GetIDBparm("sql").GetDBParm("@ErrorMessage", InsertObject.ErrorMessage);
			}
			if (InsertObject.ErrorSQL != null)
			{
				text += "ErrorSQL,";
				text2 += "@ErrorSQL,";
				dBParms[3] = Service.GetIDBparm("sql").GetDBParm("@ErrorSQL", InsertObject.ErrorSQL);
			}
			if (InsertObject.ErrorType.HasValue)
			{
				text += "ErrorType,";
				text2 += "@ErrorType,";
				dBParms[4] = Service.GetIDBparm("sql").GetDBParm("@ErrorType", InsertObject.ErrorType);
			}
			if (InsertObject.ErrorCode != null)
			{
				text += "ErrorCode,";
				text2 += "@ErrorCode,";
				dBParms[5] = Service.GetIDBparm("sql").GetDBParm("@ErrorCode", InsertObject.ErrorCode);
			}
			text = text.Substring(0, text.Length - 1);
			text2 = text2.Substring(0, text2.Length - 1);
			text = text + ")values(" + text2 + ")";
			return this.ish.ExecuteNonQuery(DBEnum.log, CommandType.Text, text, dBParms);
		}

		internal int Insertloginlog(string UserID, string IPAddress, string ClientType)
		{
			string text = " Insert into loginlog(";
			string text2 = "";
			DbParameter[] dBParms = Service.GetIDBparm("sql").GetDBParms(3);
			if (ClientType != null)
			{
				text += "ClientType,";
				text2 += "@ClientType,";
				dBParms[0] = Service.GetIDBparm("sql").GetDBParm("@ClientType", ClientType);
			}
			if (IPAddress != null)
			{
				text += "IPAddress,";
				text2 += "@IPAddress,";
				dBParms[1] = Service.GetIDBparm("sql").GetDBParm("@IPAddress", IPAddress);
			}
			if (UserID != null)
			{
				text += "UserID,";
				text2 += "@UserID,";
				dBParms[2] = Service.GetIDBparm("sql").GetDBParm("@UserID", UserID);
			}
			text = text.Substring(0, text.Length - 1);
			text2 = text2.Substring(0, text2.Length - 1);
			text = text + ")values(" + text2 + ")";
			return this.ish.ExecuteNonQuery(DBEnum.log, CommandType.Text, text, dBParms);
		}

		internal int InsertOperateLog(OperateLogObject InsertObject)
		{
			string text = " Insert into OperateLog(";
			string text2 = "";
			DbParameter[] dBParms = Service.GetIDBparm("sql").GetDBParms(9);
			if (InsertObject.ClientType != null)
			{
				text += "ClientType,";
				text2 += "@ClientType,";
				dBParms[0] = Service.GetIDBparm("sql").GetDBParm("@ClientType", InsertObject.ClientType);
			}
			if (InsertObject.UserID != null)
			{
				text += "UserID,";
				text2 += "@UserID,";
				dBParms[1] = Service.GetIDBparm("sql").GetDBParm("@UserID", InsertObject.UserID);
			}
			if (InsertObject.IPAddress != null)
			{
				text += "IPAddress,";
				text2 += "@IPAddress,";
				dBParms[2] = Service.GetIDBparm("sql").GetDBParm("@IPAddress", InsertObject.IPAddress);
			}
			if (InsertObject.OperateData != null)
			{
				text += "OperateData,";
				text2 += "@OperateData,";
				dBParms[3] = Service.GetIDBparm("sql").GetDBParm("@OperateData", InsertObject.OperateData);
			}
			if (InsertObject.OperateKey != null)
			{
				text += "OperateKey,";
				text2 += "@OperateKey,";
				dBParms[4] = Service.GetIDBparm("sql").GetDBParm("@OperateKey", InsertObject.OperateKey);
			}
			if (InsertObject.OperateMethod != null)
			{
				text += "OperateMethod,";
				text2 += "@OperateMethod,";
				dBParms[5] = Service.GetIDBparm("sql").GetDBParm("@OperateMethod", InsertObject.OperateMethod);
			}
			if (InsertObject.OperateTable != null)
			{
				text += "OperateTable,";
				text2 += "@OperateTable,";
				dBParms[6] = Service.GetIDBparm("sql").GetDBParm("@OperateTable", InsertObject.OperateTable);
			}
			if (InsertObject.OperatetyeGuid.HasValue)
			{
				text += "OperatetyeGuid,";
				text2 += "@OperatetyeGuid,";
				dBParms[7] = Service.GetIDBparm("sql").GetDBParm("@OperatetyeGuid", InsertObject.OperatetyeGuid);
			}
			text += "Operatetype,";
			text2 += "@Operatetype,";
			dBParms[8] = Service.GetIDBparm("sql").GetDBParm("@Operatetype", InsertObject.Operatetype.ToString());
			text = text.Substring(0, text.Length - 1);
			text2 = text2.Substring(0, text2.Length - 1);
			text = text + ")values(" + text2 + ")";
			return this.ish.ExecuteNonQuery(DBEnum.log, CommandType.Text, text, dBParms);
		}
	}
}
