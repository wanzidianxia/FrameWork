using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using System;
using System.Configuration;
using System.IO;
using System.Text;

namespace FreamWork.Cache
{
    public class CacheHelp : ICache
    {
        [Serializable]
        public class CacheItemRefreshAction : ICacheItemRefreshAction
        {
            void ICacheItemRefreshAction.Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
            {
                if (removalReason == 0)
                {
                    if (removedKey == "ProvinceCache")
                    {
                        Service.GetCacheHelp().AddFile("ProvinceCache", CacheData.SelectProvince(), Service.GetAppHelp().GetAppSetting("ProvinceCache"));
                        Console.Write("更新省缓存");
                    }
                    else if (removedKey == "CityCache")
                    {
                        Service.GetCacheHelp().AddFile("CityCache", CacheData.SelectCity(), Service.GetAppHelp().GetAppSetting("CityCache"));
                        Console.Write("更新市缓存");
                    }
                    else if (removedKey == "CountyCache")
                    {
                        Service.GetCacheHelp().AddFile("CountyCache", CacheData.SelectCounty(), Service.GetAppHelp().GetAppSetting("CountyCache"));
                        Console.Write("更新区缓存");
                    }
                    else if (removedKey == "MenuCache")
                    {
                        Service.GetCacheHelp().AddFile("MenuCache", CacheData.SelectMenu(), Service.GetAppHelp().GetAppSetting("MenuCache"));
                        Console.Write("更新菜单缓存");
                    }
                    else if (removedKey == "StationCache")
                    {
                        Service.GetCacheHelp().AddFile("StationCache", CacheData.SelectStation(), Service.GetAppHelp().GetAppSetting("StationCache"));
                        Console.Write("更新网点缓存");
                    }
                    else if (removedKey == "EunmCache")
                    {
                        Service.GetCacheHelp().AddFile("EunmCache", CacheData.SelectEunm(), Service.GetAppHelp().GetAppSetting("EunmCache"));
                        Console.Write("更新枚举缓存");
                    }
                }
            }
        }

        private ICacheManager cm = CacheFactory.GetCacheManager();

        public void Add(string key, object cacheo)
        {
            this.cm.Add(key, cacheo, CacheItemPriority.Normal, null, new ICacheItemExpiration[]
			{
				new NeverExpired()
			});
        }

        public void AddFile(string key, object cacheo, string filepath)
        {
            this.cm.Add(key, cacheo, CacheItemPriority.Normal, new CacheHelp.CacheItemRefreshAction(), new ICacheItemExpiration[]
			{
				new FileDependency(filepath)
			});
        }

        public void Add(string key, object cacheo, int ExpiredSecond)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds((double)ExpiredSecond);
            this.cm.Add(key, cacheo, CacheItemPriority.Normal, new CacheHelp.CacheItemRefreshAction(), new ICacheItemExpiration[]
			{
				new SlidingTime(timeSpan)
			});
        }

        public void Add(string key, object cacheo, string ExpireString)
        {
            this.cm.Add(key, cacheo, CacheItemPriority.Normal, null, new ICacheItemExpiration[]
			{
				new ExtendedFormatTime(ExpireString)
			});
        }

        public void AddAbsolute(string key, object cacheo, int ExpiredSecond)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds((double)ExpiredSecond);
            this.cm.Add(key, cacheo, CacheItemPriority.Normal, null, new ICacheItemExpiration[]
			{
				new AbsoluteTime(timeSpan)
			});
        }

        public int GetCurrentCount()
        {
            return this.cm.Count;
        }

        public T GetData<T>(string key)
        {
            object data = this.cm.GetData(key);
            T result;
            if (data == null)
            {
                result = default(T);
            }
            else
            {
                result = (T)((object)data);
            }
            return result;
        }

        public object GetData(string key)
        {
            return this.cm.GetData(key);
        }

        public void Remove(string key)
        {
            this.cm.Remove(key);
        }

        public void RefreshCache(string CacheName)
        {
            string path = ConfigurationManager.AppSettings[CacheName].ToString();
            FileStream fileStream = new FileStream(path, FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
            streamWriter.WriteLine(DateTime.Now.ToString());
            streamWriter.Close();
            fileStream.Close();
        }
    }
}
