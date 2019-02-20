using System;
using System.Collections;
using System.IO;
using System.Reflection;

namespace ServerHost
{
	internal class AssManage
	{
		public Hashtable AssTable
		{
			get;
			set;
		}

		public AssManage()
		{
			this.AssTable = new Hashtable();
		}

		public void LoadAllAss()
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "loaddll");
			FileInfo[] files = directoryInfo.GetFiles("*.dll");
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo fileInfo = files[i];
				Console.Write("  加载程序集:" + fileInfo.Name + "....");
				Assembly value = Assembly.LoadFile(fileInfo.FullName);
				this.AssTable.Add(fileInfo.Name, value);
				CommandColor.SetGreen();
				Console.WriteLine("完成");
				CommandColor.SetWhite();
			}
		}
	}
}
