using System;
using System.Collections.Generic;

namespace FreamWork
{
	public interface IApp
	{
		string GetAppSetting(string key);

		int GetAppSettingToInt(string key);

		string[] GetServiceName();

		string[] GetServiceName(string AppName);

		void RefreshConfig(string SectionName);

		long GetNewID(DBEnum dbtype, string Tabelname);

		List<decimal> GetNewIDList(DBEnum dbtype, int count, string Tabelname);
	}
}
