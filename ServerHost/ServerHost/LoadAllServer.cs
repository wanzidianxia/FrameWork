using FreamWork;
using FreamWork.App;
using FreamWork.Cache;
using FreamWork.Data;
using FreamWork.Exception;
using FreamWork.Log;
using System;

namespace ServerHost
{
	internal class LoadAllServer
	{
		public static void LoadAllService()
		{
			Console.Write("   加载基础服务..........");
			ServicesManager servicesManager = ServicesManager.GetServicesManager();
			servicesManager.AddService("db", new DBAdaptor());
			servicesManager.AddService("log", new LogHelp("db"));
			servicesManager.AddService("cache", new CacheHelp());
			servicesManager.AddService("app", new AppHelp());
			servicesManager.AddService("except", new ExceptionHelp("log"));
			CommandColor.SetGreen();
			Console.WriteLine("完成");
			CommandColor.SetWhite();
		}
	}
}
