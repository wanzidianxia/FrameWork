using System;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;

namespace FreamWork
{
	internal class OrclParam : IDBParam
	{
		public DbParameter GetDBParm()
		{
			return new OracleParameter();
		}

		public DbParameter GetDBParm(string name)
		{
			return new OracleParameter();
		}

		public DbParameter GetDBParm(string name, object value)
		{
			return new OracleParameter
			{
				ParameterName = name,
				Value = value
			};
		}

		public DbParameter GetDBParm(string name, DbType dbtype, ParameterDirection direction)
		{
			return this.GetDBParm(name, dbtype, null, direction);
		}

		public DbParameter GetDBParm(string name, DbType dbtype, object value, ParameterDirection direction)
		{
			return new OracleParameter
			{
				ParameterName = name,
				DbType = dbtype,
				Value = value,
				Direction = direction
			};
		}

		public DbParameter[] GetDBParms(int parmcount)
		{
			return new OracleParameter[parmcount];
		}
	}
}
