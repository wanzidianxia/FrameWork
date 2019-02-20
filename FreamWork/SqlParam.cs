using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FreamWork
{
	internal class SqlParam : IDBParam
	{
		public DbParameter GetDBParm()
		{
			return new SqlParameter();
		}

		public DbParameter GetDBParm(string name)
		{
			return new SqlParameter();
		}

		public DbParameter GetDBParm(string name, object value)
		{
			return new SqlParameter
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
			DbParameter result;
			if (dbtype == DbType.Decimal)
			{
				SqlParameter sqlParameter = new SqlParameter
				{
					ParameterName = name,
					DbType = dbtype,
					Value = value,
					Direction = direction
				};
				sqlParameter.Precision = 18;
				sqlParameter.Scale = 2;
				result = sqlParameter;
			}
			else
			{
				result = new SqlParameter
				{
					ParameterName = name,
					DbType = dbtype,
					Value = value,
					Direction = direction
				};
			}
			return result;
		}

		public DbParameter[] GetDBParms(int parmcount)
		{
			return new SqlParameter[parmcount];
		}
	}
}
