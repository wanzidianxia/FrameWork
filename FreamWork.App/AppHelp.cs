using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Xml;

namespace FreamWork.App
{
	public class AppHelp : IApp
	{
		public string GetAppSetting(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}

		public int GetAppSettingToInt(string key)
		{
			string appSetting = this.GetAppSetting(key);
			int result;
			if (string.IsNullOrEmpty(appSetting))
			{
				result = 0;
			}
			else
			{
				int num;
				try
				{
					num = Convert.ToInt32(appSetting);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				result = num;
			}
			return result;
		}

		public string[] GetServiceName()
		{
			Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			return this.GetServiceName(configuration.FilePath);
		}

		public string[] GetServiceName(string AppName)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(AppName);
			XmlNode xmlNode = xmlDocument.SelectSingleNode("configuration/system.serviceModel/services");
			string[] array = null;
			if (xmlNode != null)
			{
				XmlNodeList xmlNodeList = xmlNode.SelectNodes("service");
				array = new string[xmlNodeList.Count];
				int num = 0;
				foreach (XmlNode xmlNode2 in xmlNodeList)
				{
					array[num] = xmlNode2.Attributes["name"].Value;
					num++;
				}
			}
			return array;
		}

		public void RefreshConfig(string SectionName)
		{
			ConfigurationManager.RefreshSection(SectionName);
		}

		public long GetNewID(DBEnum dbtype, string Tabelname)
		{
			string sqlstr = "update SYS_IDIncrease set @keyvalue=keyvalue=keyvalue+1 where tablename=@tablename ";
			DbParameter[] dBParms = Service.GetIDBparm("sql").GetDBParms(2);
			dBParms[0] = Service.GetIDBparm("sql").GetDBParm("@tablename", Tabelname);
			dBParms[1] = Service.GetIDBparm("sql").GetDBParm("@keyvalue", DbType.Int64, ParameterDirection.Output);
			try
			{
				Service.GetSqlHelp().ExecuteNonQuery(dbtype, CommandType.Text, sqlstr, dBParms);
			}
			catch (Exception ex)
			{
				string sQLandParstr = AppHelp.GetSQLandParstr(dbtype, sqlstr, dBParms);
				Service.GetExceptHelp().HandleExcept(ex, "@00000020", sQLandParstr, false);
			}
			return (long)dBParms[1].Value;
		}

		public List<decimal> GetNewIDList(DBEnum dbtype, int count, string Tabelname)
		{
			string sqlstr = " update SYS_IDINCREASE set @keyvalue=keyvalue=keyvalue+" + count + " where tablename=@tablename";
			DbParameter[] dBParms = Service.GetIDBparm("sql").GetDBParms(2);
			dBParms[0] = Service.GetIDBparm("sql").GetDBParm("@tablename", Tabelname);
			dBParms[1] = Service.GetIDBparm("sql").GetDBParm("@keyvalue", DbType.Decimal, ParameterDirection.Output);
			try
			{
				Service.GetSqlHelp().ExecuteNonQuery(dbtype, CommandType.Text, sqlstr, dBParms);
			}
			catch (Exception ex)
			{
				string sQLandParstr = AppHelp.GetSQLandParstr(dbtype, sqlstr, dBParms);
				Service.GetExceptHelp().HandleExcept(ex, "@00000020", sQLandParstr, false);
			}
			List<decimal> list = new List<decimal>();
			decimal num = count - 1;
			while (num >= 0m)
			{
				decimal item = (decimal)dBParms[1].Value - num;
				list.Add(item);
				num = --num;
			}
			return list;
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
	}
}
