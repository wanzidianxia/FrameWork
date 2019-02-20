using FreamWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.Threading;

namespace ServerHost
{
	internal class WCFServiceManage
	{
		private string[] allappservice;

		private Hashtable asstable;

		private Hashtable ServiceTable = new Hashtable();

		private Thread _thread;

		private MexHost host;

		public WCFServiceManage(Hashtable asstable)
		{
			this.asstable = asstable;
		}

		public string[] GetAppService()
		{
			return this.allappservice;
		}

		public Hashtable GetOpenService()
		{
			return this.ServiceTable;
		}

		private bool GetServiceState(string serviceTypeName)
		{
			return this.ServiceTable[serviceTypeName] != null;
		}

		public void RefreshApp()
		{
			Service.GetAppHelp().RefreshConfig("appSettings");
		}

		public void StartAllService()
		{
			this.allappservice = Service.GetAppHelp().GetServiceName();
			if (this.allappservice != null)
			{
				string[] array = this.allappservice;
				for (int i = 0; i < array.Length; i++)
				{
					string serviceTypeName = array[i];
					this.StartService(serviceTypeName);
				}
			}
		}

		private ServiceHost starthostaddvalidation(Type type)
		{
			this.host = new MexHost(type, new Uri[0]);
			this._thread = new Thread(new ThreadStart(this.RunService));
			this._thread.Start();
			return this.host;
		}

		private void RunService()
		{
			this.host.Open();
		}

		public void StartService(string serviceTypeName)
		{
			Console.Write("   启动服务" + serviceTypeName + "..........");
			if (this.GetServiceState(serviceTypeName))
			{
				CommandColor.SetYellow();
				Console.WriteLine("服务运行中");
				CommandColor.SetWhite();
			}
			else
			{
				int num = serviceTypeName.IndexOf('.', 4);
				if (num == -1)
				{
					CommandColor.SetRed();
					Console.WriteLine("失败");
					Console.WriteLine("服务名称格式错误");
					CommandColor.SetWhite();
				}
				else
				{
					string str = serviceTypeName.Substring(0, num);
					Assembly assembly = (Assembly)this.asstable[str + ".dll"];
					if (assembly == null)
					{
						CommandColor.SetRed();
						Console.WriteLine("失败");
						Console.WriteLine("服务程序集不存在");
						CommandColor.SetWhite();
					}
					else
					{
						ServiceHost value = null;
						Type type = assembly.GetType(serviceTypeName, true);
						if (type == null)
						{
							CommandColor.SetRed();
							Console.WriteLine("失败");
							Console.WriteLine("服务类型不存在");
							CommandColor.SetWhite();
						}
						else
						{
							try
							{
								value = this.starthostaddvalidation(type);
							}
							catch (Exception ex)
							{
								CommandColor.SetRed();
								Console.Write("失败");
								Console.WriteLine(ex.Message);
								Console.WriteLine(ex.StackTrace);
								CommandColor.SetWhite();
								return;
							}
							this.ServiceTable.Add(serviceTypeName, value);
							CommandColor.SetGreen();
							Console.WriteLine("完成");
							CommandColor.SetWhite();
						}
					}
				}
			}
		}

		public void StopAllService()
		{
			List<string> list = new List<string>();
			foreach (string item in this.ServiceTable.Keys)
			{
				list.Add(item);
			}
			foreach (string current in list)
			{
				this.StopService(current);
			}
		}

		public void StopService(string serviceTypeName)
		{
			Console.Write("   关闭服务" + serviceTypeName + "..........");
			object obj = this.ServiceTable[serviceTypeName];
			if (obj != null)
			{
				ServiceHost serviceHost = (ServiceHost)obj;
				try
				{
					serviceHost.Close();
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
					return;
				}
				this.ServiceTable.Remove(serviceTypeName);
				CommandColor.SetGreen();
				Console.WriteLine("完成");
				CommandColor.SetWhite();
			}
			else
			{
				CommandColor.SetRed();
				Console.WriteLine("服务不存在");
				CommandColor.SetWhite();
			}
		}
	}
}
