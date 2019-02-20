using System;
using System.Data;
using System.Data.Common;

namespace FreamWork
{
	public interface IDB
	{
		DbTransaction BeginTractionand(DBEnum dbtype);

		void CommitTractionand(DbTransaction dbTransaction);

		DataSet ExecuteDataSet(DBEnum dbtype, CommandType commandtype, string sqlstr);

		DataSet ExecuteDataSet(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		DataSet ExecuteDataSet(DBEnum dbtype, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues);

		int ExecuteNonQuery(DBEnum dbtype, CommandType commandtype, string sqlstr);

		int ExecuteNonQuery(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		int ExecuteNonQuery(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr);

		int ExecuteNonQuery(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		int ExecuteNonQuery(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues);

		IDataReader ExecuteReader(DBEnum dbtype, CommandType commandtype, string sqlstr);

		IDataReader ExecuteReader(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr);

		IDataReader ExecuteReader(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		IDataReader ExecuteReader(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		IDataReader ExecuteReader(DBEnum dbtype, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues);

		object ExecuteScalar(DBEnum dbtype, CommandType commandtype, string sqlstr);

		object ExecuteScalar(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		object ExecuteScalar(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr);

		object ExecuteScalar(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		object ExecuteScalar(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues);

		int ExecuteScalarToInt(DBEnum dbtype, CommandType commandtype, string sqlstr);

		int ExecuteScalarToInt(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues);

		void RollbackTractionand(DbTransaction dbTransaction);

		bool ExecuteBulkCopy(DBEnum dbtype, DataTable dt, string db, DbTransaction dbt);
	}
}
