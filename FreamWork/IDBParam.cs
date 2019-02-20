using System;
using System.Data;
using System.Data.Common;

namespace FreamWork
{
	public interface IDBParam
	{
		DbParameter GetDBParm();

		DbParameter GetDBParm(string name);

		DbParameter GetDBParm(string name, object value);

		DbParameter GetDBParm(string name, DbType dbtype, ParameterDirection direction);

		DbParameter GetDBParm(string name, DbType dbtype, object value, ParameterDirection direction);

		DbParameter[] GetDBParms(int parmcount);
	}
}
