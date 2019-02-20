using System;
using System.IO;
using System.Reflection;

namespace ServerHost
{
	public class LocalLoader
	{
		public AppDomain appDomain;

		public RemoteLoader remoteLoader;

		public string FullName
		{
			get
			{
				return this.remoteLoader.FullName;
			}
		}

		public LocalLoader()
		{
			AppDomainSetup appDomainSetup = new AppDomainSetup();
			appDomainSetup.ApplicationName = "Test";
			appDomainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
			appDomainSetup.PrivateBinPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "private");
			appDomainSetup.CachePath = appDomainSetup.ApplicationBase;
			appDomainSetup.ShadowCopyFiles = "true";
			appDomainSetup.ShadowCopyDirectories = appDomainSetup.ApplicationBase;
			this.appDomain = AppDomain.CreateDomain("TestDomain", null, appDomainSetup);
			string fullName = Assembly.GetExecutingAssembly().GetName().FullName;
			this.remoteLoader = (RemoteLoader)this.appDomain.CreateInstanceAndUnwrap(fullName, typeof(RemoteLoader).FullName);
		}

		public Assembly LoadAssembly(string fullName)
		{
			return this.remoteLoader.LoadAssembly(fullName);
		}

		public void Unload()
		{
			AppDomain.Unload(this.appDomain);
			this.appDomain = null;
		}
	}
}
