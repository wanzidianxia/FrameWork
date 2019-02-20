using System;
using System.Configuration;

namespace FreamWork
{
	public static class Service
	{
		public static IApp GetAppHelp()
		{
			return Service.GetAppHelp(null);
		}

		public static IApp GetAppHelp(string key)
		{
			return Service.GetServerHelp<IApp>(key, "app", "appkey");
		}

		public static ICache GetCacheHelp()
		{
			return Service.GetCacheHelp(null);
		}

		public static ICache GetCacheHelp(string key)
		{
			return Service.GetServerHelp<ICache>(key, "cache", "cachekey");
		}

		public static IException GetExceptHelp()
		{
			return Service.GetExceptHelp(null);
		}

		public static IException GetExceptHelp(string key)
		{
			return Service.GetServerHelp<IException>(key, "except", "exceptkey");
		}

		public static IDBParam GetIDBparm()
		{
			string databasetypekey = ConfigurationManager.AppSettings["databasetype"];
			return DBParamFactory.GetIDBParm(databasetypekey);
		}

		public static IDBParam GetIDBparm(string name)
		{
			return DBParamFactory.GetIDBParm(name);
		}

		public static ILog GetLogHelp()
		{
			return Service.GetLogHelp(null);
		}

		public static ILog GetLogHelp(string key)
		{
			return Service.GetServerHelp<ILog>(key, "log", "logkey");
		}

		private static T GetServerHelp<T>(string key, string defautkey, string appkey)
		{
			string text = key;
			if (string.IsNullOrEmpty(text) && ConfigurationManager.AppSettings[appkey] != null)
			{
				text = ConfigurationManager.AppSettings[appkey].ToString();
			}
			if (string.IsNullOrEmpty(text))
			{
				text = defautkey;
			}
			return ServicesManager.GetServicesManager().GetService<T>(text);
		}

		public static IDB GetSqlHelp()
		{
			return Service.GetSqlHelp(null);
		}

		public static IDB GetSqlHelp(string key)
		{
			return Service.GetServerHelp<IDB>(key, "db", "dbkey");
		}
	}
}
