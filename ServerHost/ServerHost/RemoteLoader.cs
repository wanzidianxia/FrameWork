using System;
using System.Reflection;

namespace ServerHost
{
	public class RemoteLoader : MarshalByRefObject
	{
		private Assembly assembly;

		public string FullName
		{
			get
			{
				return this.assembly.FullName;
			}
		}

		public Assembly LoadAssembly(string fullName)
		{
			this.assembly = Assembly.LoadFile(fullName);
			return this.assembly;
		}
	}
}
