using System;

namespace FreamWork
{
	internal class DBParamFactory
	{
		public static IDBParam GetIDBParm(string databasetypekey)
		{
			IDBParam result;
			if (databasetypekey == "sql" && !string.IsNullOrEmpty(databasetypekey))
			{
				result = new SqlParam();
			}
			else if (databasetypekey == "orcl" && !string.IsNullOrEmpty(databasetypekey))
			{
				result = new OrclParam();
			}
			else
			{
				result = new OrclParam();
			}
			return result;
		}
	}
}
