using FreamWork;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ServerHost
{
	internal class HandleCommand
	{
		private Hashtable listass;

		private WCFServiceManage wcfmanage;

		public HandleCommand(WCFServiceManage wcfmanage, Hashtable listass)
		{
			this.wcfmanage = wcfmanage;
			this.listass = listass;
		}

		private void ListAssService()
		{
			Console.WriteLine("所有配置的服务");
			CommandColor.SetGreen();
			string[] appService = this.wcfmanage.GetAppService();
			for (int i = 0; i < appService.Length; i++)
			{
				string value = appService[i];
				Console.WriteLine(value);
			}
			CommandColor.SetWhite();
		}

		private void ListOpenService()
		{
			Console.WriteLine("所有启动的服务");
			CommandColor.SetGreen();
			foreach (string value in this.wcfmanage.GetOpenService().Keys)
			{
				Console.WriteLine(value);
			}
			CommandColor.SetWhite();
		}

		    public void LoopCommand()
    {
      Console.WriteLine("查看命令帮助 help ");
      Console.Write("WCF>");
      bool flag = true;
      while (flag)
      {
        string[] strArray = Console.ReadLine().Split(' ');
        switch (strArray[0])
        {
          case "exit":
            this.wcfmanage.StopAllService();
            flag = false;
            break;
          case "help":
            CommandHelp.showhelp();
            break;
          case "la":
            this.ShowAllAss();
            break;
          case "lapp":
            this.ListAssService();
            break;
          case "los":
            this.ListOpenService();
            break;
          case "startall":
            this.wcfmanage.StartAllService();
            break;
          case "stopall":
            this.wcfmanage.StopAllService();
            break;
          case "restart":
            this.wcfmanage.StopAllService();
            this.wcfmanage.RefreshApp();
            this.wcfmanage.StartAllService();
            break;
          case "rapp":
            this.wcfmanage.RefreshApp();
            break;
          case "start":
            if (strArray.Length == 2)
            {
              this.wcfmanage.StartService(strArray[1]);
              break;
            }
            CommandColor.SetRed();
            Console.WriteLine("必须有参数 ，服务的名称！傻瓜^_^");
            CommandColor.SetWhite();
            break;
          case "stop":
            if (strArray.Length == 2)
            {
              this.wcfmanage.StopService(strArray[1]);
              break;
            }
            CommandColor.SetRed();
            Console.WriteLine("必须有参数 ，服务的名称！傻瓜^_^");
            CommandColor.SetWhite();
            break;
          case "cacheinfo":
            Console.WriteLine("当前缓存个数为" + Service.GetCacheHelp().GetCurrentCount().ToString());
            break;
          default:
            Console.WriteLine("命令打错了，笨蛋！^_^");
            break;
        }
        Console.Write("\n");
        Console.Write("WCF>");
      }
    }

		private void ShowAllAss()
		{
			Console.WriteLine("所有加载的程序集");
			CommandColor.SetGreen();
			foreach (string value in this.listass.Keys)
			{
				Console.WriteLine(value);
			}
			CommandColor.SetWhite();
		}
	}
}
