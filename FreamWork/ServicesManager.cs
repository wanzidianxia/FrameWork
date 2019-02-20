using System;
using System.Collections;

namespace FreamWork
{
	public class ServicesManager
	{
		private static ServicesManager _servicesManager;

		private Hashtable ServiceList = new Hashtable();

		private ServicesManager()
		{
		}

		public void AddService(string key, object Services)
		{
			if (this.ServiceList.ContainsKey(key))
			{
				throw new Exception("服务的Key已存在");
			}
			this.ServiceList.Add(key, Services);
		}

		public bool ContainsKey(string key)
		{
			return this.ServiceList.ContainsKey(key);
		}

		public T GetService<T>(string key)
		{
			object obj = this.ServiceList[key];
			T result;
			if (obj != null)
			{
				result = (T)((object)obj);
			}
			else
			{
				result = default(T);
			}
			return result;
		}

		public static ServicesManager GetServicesManager()
		{
			ServicesManager servicesManager;
			if (ServicesManager._servicesManager == null && ServicesManager._servicesManager == null)
			{
				ServicesManager._servicesManager = new ServicesManager();
				servicesManager = ServicesManager._servicesManager;
			}
			else
			{
				servicesManager = ServicesManager._servicesManager;
			}
			return servicesManager;
		}

		public void RemoveService(string key)
		{
			this.ServiceList.Remove(key);
		}
	}
}
