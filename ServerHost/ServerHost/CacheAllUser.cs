using FreamWork;
using FreamWork.Cache;
using System;
using System.Data;

namespace ServerHost
{
	public static class CacheAllUser
	{
		internal static void caching()
		{
			if (!string.IsNullOrEmpty(Service.GetAppHelp().GetAppSetting("userdbname")))
			{
				Console.Write("  缓存所有用户:....");
				DataSet dataSet = CacheData.SelectAllUser();
				foreach (DataRow dataRow in dataSet.Tables[0].Rows)
				{
					Service.GetCacheHelp().Add(dataRow[1].ToString(), dataRow[0].ToString());
				}
				CommandColor.SetGreen();
				Console.WriteLine("完成");
				CommandColor.SetWhite();
				Console.Write("  缓存行政区划:....");
				DataSet cacheo = CacheData.SelectProvince();
				DataSet cacheo2 = CacheData.SelectCity();
				DataSet cacheo3 = CacheData.SelectCounty();
				DataSet cacheo4 = CacheData.SelectStreet();
				Service.GetCacheHelp().AddFile("ProvinceCache", cacheo, Service.GetAppHelp().GetAppSetting("ProvinceCache"));
				Service.GetCacheHelp().AddFile("CityCache", cacheo2, Service.GetAppHelp().GetAppSetting("CityCache"));
				Service.GetCacheHelp().AddFile("CountyCache", cacheo3, Service.GetAppHelp().GetAppSetting("CountyCache"));
				Service.GetCacheHelp().AddFile("StreetCache", cacheo4, Service.GetAppHelp().GetAppSetting("StreetCache"));
				CommandColor.SetGreen();
				Console.WriteLine("完成");
				CommandColor.SetWhite();
				Console.Write("  缓存功能菜单:....");
				DataSet cacheo5 = CacheData.SelectMenu();
				Service.GetCacheHelp().AddFile("MenuCache", cacheo5, Service.GetAppHelp().GetAppSetting("MenuCache"));
				CommandColor.SetGreen();
				Console.WriteLine("完成");
				CommandColor.SetWhite();
				Console.Write("  缓存枚举:....");
				DataSet cacheo6 = CacheData.SelectEunm();
				Service.GetCacheHelp().AddFile("EunmCache", cacheo6, Service.GetAppHelp().GetAppSetting("EunmCache"));
				CommandColor.SetGreen();
				Console.WriteLine("完成");
				CommandColor.SetWhite();
			}
		}
	}
}
