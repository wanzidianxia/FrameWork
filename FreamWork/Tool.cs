using System;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

namespace FreamWork
{
	public class Tool
	{
		public static DataSet ExeDataSetCache(DBEnum dbtype, CommandType commandtype, string sqlstr, int ExpiredSecond, params DbParameter[] parameterValues)
		{
			string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, parameterValues);
			DataSet data = Service.GetCacheHelp().GetData<DataSet>(sQLandParstr);
			DataSet result;
			if (data != null)
			{
				result = data;
			}
			else
			{
				DataSet dataSet = Service.GetSqlHelp().ExecuteDataSet(dbtype, commandtype, sqlstr, parameterValues);
				Service.GetCacheHelp().AddAbsolute(sQLandParstr, dataSet, ExpiredSecond);
				result = dataSet;
			}
			return result;
		}

		public static long GetNewID(DBEnum dbtype, string Tabelname)
		{
			string sqlstr = "update IDIncrease set @keyvalue=keyvalue=keyvalue+1 where tablename=@tablename ";
			DbParameter[] dBParms = Service.GetIDBparm().GetDBParms(2);
			dBParms[0] = Service.GetIDBparm().GetDBParm("@tablename", Tabelname);
			dBParms[1] = Service.GetIDBparm().GetDBParm("@keyvalue", DbType.Int64, ParameterDirection.Output);
			try
			{
				Service.GetSqlHelp().ExecuteNonQuery(dbtype, CommandType.Text, sqlstr, dBParms);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, dBParms);
				Service.GetExceptHelp().HandleExcept(ex, "@00000020", sQLandParstr, false);
			}
			return (long)dBParms[1].Value;
		}

		public static string GetSQLandParstr(DBEnum dbtype, string sqlstr, params DbParameter[] parameterValues)
		{
			string text = "";
			if (parameterValues != null)
			{
				for (int i = 0; i < parameterValues.Length; i++)
				{
					DbParameter dbParameter = parameterValues[i];
					if (dbParameter != null && dbParameter.Value != null)
					{
						text = string.Concat(new string[]
						{
							text,
							dbParameter.ParameterName,
							"=",
							dbParameter.Value.ToString(),
							";"
						});
					}
				}
			}
			return string.Concat(new string[]
			{
				dbtype.ToString(),
				":",
				sqlstr,
				";",
				text
			});
		}

		public static string GetUserName(long userID)
		{
			return Tool.SelectNameFromID(userID);
		}

		public static string InspectBitLength(string s, int l, string endStr)
		{
			string result;
			if (string.IsNullOrEmpty(s))
			{
				result = s;
			}
			else
			{
				string text = s.Substring(0, (s.Length < l) ? s.Length : l);
				if (Regex.Replace(text, "[一-龥]", "zz", RegexOptions.IgnoreCase).Length <= l)
				{
					result = text;
				}
				else
				{
					for (int i = text.Length; i >= 0; i--)
					{
						text = text.Substring(0, i);
						if (Regex.Replace(text, "[一-龥]", "zz", RegexOptions.IgnoreCase).Length <= l - endStr.Length)
						{
							result = text + endStr;
							return result;
						}
					}
					result = endStr;
				}
			}
			return result;
		}

		public static string InspectLength(string s, int l)
		{
			string result;
			if (!string.IsNullOrEmpty(s) && s.Length > l)
			{
				result = s.Substring(0, l);
			}
			else
			{
				result = s;
			}
			return result;
		}

		private static string SelectNameFromID(long userID)
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			string appSetting2 = Service.GetAppHelp().GetAppSetting("usernamefield");
			string appSetting3 = Service.GetAppHelp().GetAppSetting("useridfield");
			string appSetting4 = Service.GetAppHelp().GetAppSetting("tablename");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = string.Concat(new string[]
			{
				"select ",
				appSetting2,
				" from ",
				appSetting4,
				" where ",
				appSetting3,
				"=@userID and  state=0"
			});
			DbParameter[] dBParms = Service.GetIDBparm().GetDBParms(1);
			dBParms[0] = Service.GetIDBparm().GetDBParm("@userID", userID);
			string result = string.Empty;
			try
			{
				result = Service.GetSqlHelp().ExecuteScalar(dbtype, CommandType.Text, sqlstr, dBParms).ToString();
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@00000010", sQLandParstr, false);
			}
			return result;
		}
	}
}
