using System;

namespace FreamWork
{
	public interface ICache
	{
		void Add(string key, object cacheo);

		void AddFile(string key, object cacheo, string filepath);

		void Add(string key, object cacheo, int ExpiredSecond);

		void Add(string key, object cacheo, string ExpireString);

		void AddAbsolute(string key, object cacheo, int ExpiredSecond);

		int GetCurrentCount();

		T GetData<T>(string key);

		object GetData(string key);

		void Remove(string key);

		void RefreshCache(string CacheName);
	}
}
