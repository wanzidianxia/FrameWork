using System;

namespace ServerHost
{
	public static class RunServer
	{
		public static void Run()
		{
			CommandColor.SetBackWhite();
			CommandColor.SetBlack();
			Console.WriteLine("...启动服务...");
			CommandColor.SetBackBlack();
			CommandColor.SetWhite();
			LoadAllServer.LoadAllService();
			CacheAllUser.caching();
			AssManage assManage = new AssManage();
			assManage.LoadAllAss();
			WCFServiceManage wCFServiceManage = new WCFServiceManage(assManage.AssTable);
			wCFServiceManage.StartAllService();
			CommandColor.SetBackWhite();
			CommandColor.SetBlack();
			Console.WriteLine("...启动完成...");
			CommandColor.SetBackBlack();
			CommandColor.SetWhite();
			CommandHelp.showhelp();
			new HandleCommand(wCFServiceManage, assManage.AssTable).LoopCommand();
		}
	}
}
