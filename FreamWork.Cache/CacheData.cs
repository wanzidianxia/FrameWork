using System;
using System.Data;
using System.Data.Common;

namespace FreamWork.Cache
{
	public class CacheData
	{
		public static DataSet SelectAllUser()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = " SELECT  t.[UserID],t.[Guid] FROM [SYS_User] t WHERE t.IfDel=0 ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@用户缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectProvince()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select B.ProvinceID,B.ProvinceName from Bas_Nation_Province B  ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@省缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectCity()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select  B.CityID,B.CityName,B.ProvinceID from Bas_Nation_City B where  B.IfDel=0 order by CityName ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@市缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectCounty()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select B.CountyID,B.CountyName,B.CityID from Bas_Nation_County B  where  B.IfDel=0 ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@区缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectStreet()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select B.ID,B.CountyID,B.Street,B.IfCod from Bas_Nation_AdministrativeRegion B  where  B.IfDel=0 ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@街道缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectMenu()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select S.BarItemID,S.Caption,S.DllName,S.ImageName,S.ParentID,S.IsButton,S.ActionID from SYS_BarItem S  where 1=1 and BarItemID<>14 and BarItemID<>15  and NewOrOldFlag<>3 and IsEnable=1 order by ItemOrder ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@菜单缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectEunm()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select B.ItemCode,B.ItemValue,B.OperTime,B.OperStatus,B.CodeDicName,B.CodeDicID,B.ifDel,B.ifModify,B.ElseValue from Bas_CodeTable B  where B.ifDel=0 ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@枚举缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}

		public static DataSet SelectStation()
		{
			string appSetting = Service.GetAppHelp().GetAppSetting("userdbname");
			DBEnum dbtype = (DBEnum)Enum.Parse(typeof(DBEnum), appSetting);
			string sqlstr = "select B.IFDaoFu,B.ifzhipiao,B.StationType,B.StationID,B.StationName,B.Telphone,B.MobilePhone,B.Address,B.BelongCenterID,B.BelongCenter,B.ProvinceID,B.ParentCode,B.ifIn,B.JoinUnitID,B.StationCityID from Bas_StationInformation B   ";
			DataSet result;
			try
			{
				result = Service.GetSqlHelp().ExecuteDataSet(dbtype, CommandType.Text, sqlstr);
			}
			catch (Exception ex)
			{
				string sQLandParstr = Tool.GetSQLandParstr(dbtype, sqlstr, new DbParameter[0]);
				Service.GetExceptHelp().HandleExcept(ex, "@网点缓存", sQLandParstr, false);
				result = null;
			}
			return result;
		}
	}
}
