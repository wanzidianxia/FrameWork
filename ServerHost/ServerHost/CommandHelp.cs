using System;

namespace ServerHost
{
	internal class CommandHelp
	{
		public static void showhelp()
		{
			Console.WriteLine("              ***命令帮助***");
			Console.WriteLine(" start @servicename 启动服务 ");
			Console.WriteLine(" stop @servicename  停止服务 ");
			Console.WriteLine(" startall           启动所有服务 ");
			Console.WriteLine(" stopall            停止所有服务 ");
			Console.WriteLine(" restart            重启服务 ");
			Console.WriteLine(" la                 已加载程序集列表");
			Console.WriteLine(" los                启动的服务列表");
			Console.WriteLine(" lapp               配置的服务列表");
			Console.WriteLine(" rapp               刷新配置文件,对appsetting有效");
			Console.WriteLine(" cacheinfo          查询当前缓存信息");
			Console.WriteLine(" exit               退出 ");
			Console.WriteLine(" 说明：修改配置文件后必须退出后再运行，新的配置才会生效！");
		}
	}
}
