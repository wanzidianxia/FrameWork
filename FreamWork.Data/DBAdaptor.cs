using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FreamWork.Data
{
	public class DBAdaptor : IDB
	{
		private DbCommand PrepareCommand(Database db, CommandType cmdType, string sqlstr, DbParameter[] cmdParms)
		{
			int timeout = 300;
			return this.PrepareCommand(db, cmdType, sqlstr, timeout, cmdParms);
		}

		private DbCommand PrepareCommand(Database db, CommandType cmdType, string sqlstr, int timeout, DbParameter[] cmdParms)
		{
			DbCommand sqlStringCommand = db.GetSqlStringCommand(sqlstr);
			sqlStringCommand.CommandType = cmdType;
			sqlStringCommand.CommandTimeout = timeout;
			if (cmdParms != null)
			{
				for (int i = 0; i < cmdParms.Length; i++)
				{
					DbParameter dbParameter = cmdParms[i];
					if (dbParameter != null)
					{
						sqlStringCommand.Parameters.Add(dbParameter);
					}
				}
			}
			return sqlStringCommand;
		}

		public DbTransaction BeginTractionand(DBEnum dbtype)
		{
			DbConnection dbConnection = DatabaseFactory.CreateDatabase(dbtype.ToString()).CreateConnection();
			dbConnection.Open();
			return dbConnection.BeginTransaction();
		}

		public void CommitTractionand(DbTransaction dbTransaction)
		{
			DbConnection connection = dbTransaction.Connection;
			dbTransaction.Commit();
			connection.Close();
		}

		public DataSet ExecuteDataSet(DBEnum dbtype, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteDataSet(dbtype, commandtype, sqlstr, null);
		}

		public DataSet ExecuteDataSet(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, parameterValues);
			return database.ExecuteDataSet(dbCommand);
		}

		public DataSet ExecuteDataSet(DBEnum dbtype, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, timeout, parameterValues);
			return database.ExecuteDataSet(dbCommand);
		}

		public int ExecuteNonQuery(DBEnum dbtype, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteNonQuery(dbtype, null, commandtype, sqlstr, null);
		}

		public int ExecuteNonQuery(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			return this.ExecuteNonQuery(dbtype, null, commandtype, sqlstr, parameterValues);
		}

		public int ExecuteNonQuery(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteNonQuery(dbtype, dbTransaction, commandtype, sqlstr, null);
		}

		public int ExecuteNonQuery(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			int result;
			try
			{
				Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
				DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, parameterValues);
				if (dbTransaction == null)
				{
					result = database.ExecuteNonQuery(dbCommand);
				}
				else
				{
					result = database.ExecuteNonQuery(dbCommand, dbTransaction);
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		public int ExecuteNonQuery(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, timeout, parameterValues);
			int result;
			if (dbTransaction == null)
			{
				result = database.ExecuteNonQuery(dbCommand);
			}
			else
			{
				result = database.ExecuteNonQuery(dbCommand, dbTransaction);
			}
			return result;
		}

		public IDataReader ExecuteReader(DBEnum dbtype, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteReader(dbtype, commandtype, sqlstr, null);
		}

		public IDataReader ExecuteReader(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, parameterValues);
			return database.ExecuteReader(dbCommand);
		}

		public IDataReader ExecuteReader(DBEnum dbtype, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, timeout, parameterValues);
			return database.ExecuteReader(dbCommand);
		}

		public IDataReader ExecuteReader(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteReader(dbtype, dbTransaction, commandtype, sqlstr, null);
		}

		public IDataReader ExecuteReader(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, parameterValues);
			IDataReader result;
			if (dbTransaction == null)
			{
				result = database.ExecuteReader(dbCommand);
			}
			else
			{
				result = database.ExecuteReader(dbCommand, dbTransaction);
			}
			return result;
		}

		public object ExecuteScalar(DBEnum dbtype, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteScalar(dbtype, null, commandtype, sqlstr, null);
		}

		public object ExecuteScalar(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			return this.ExecuteScalar(dbtype, null, commandtype, sqlstr, parameterValues);
		}

		public object ExecuteScalar(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr)
		{
			return this.ExecuteScalar(dbtype, dbTransaction, commandtype, sqlstr, null);
		}

		public object ExecuteScalar(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, parameterValues);
			object obj;
			if (dbTransaction == null)
			{
				obj = database.ExecuteScalar(dbCommand);
			}
			else
			{
				obj = database.ExecuteScalar(dbCommand, dbTransaction);
			}
			if (obj == DBNull.Value)
			{
				obj = null;
			}
			return obj;
		}

		public object ExecuteScalar(DBEnum dbtype, DbTransaction dbTransaction, CommandType commandtype, string sqlstr, int timeout, params DbParameter[] parameterValues)
		{
			Database database = DatabaseFactory.CreateDatabase(dbtype.ToString());
			DbCommand dbCommand = this.PrepareCommand(database, commandtype, sqlstr, timeout, parameterValues);
			object obj;
			if (dbTransaction == null)
			{
				obj = database.ExecuteScalar(dbCommand);
			}
			else
			{
				obj = database.ExecuteScalar(dbCommand, dbTransaction);
			}
			if (obj == DBNull.Value)
			{
				obj = null;
			}
			return obj;
		}

		public int ExecuteScalarToInt(DBEnum dbtype, CommandType commandtype, string sqlstr)
		{
			object o = this.ExecuteScalar(dbtype, commandtype, sqlstr);
			return this.ObjectToInt(o);
		}

		public int ExecuteScalarToInt(DBEnum dbtype, CommandType commandtype, string sqlstr, params DbParameter[] parameterValues)
		{
			object o = this.ExecuteScalar(dbtype, commandtype, sqlstr, parameterValues);
			return this.ObjectToInt(o);
		}

		private int ObjectToInt(object o)
		{
			int result;
			if (o != null)
			{
				result = Convert.ToInt32(o);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public void RollbackTractionand(DbTransaction dbTransaction)
		{
			DbConnection connection = dbTransaction.Connection;
			dbTransaction.Rollback();
			connection.Close();
		}

		public bool ExecuteBulkCopy(DBEnum dbtype, DataTable dt, string db, DbTransaction dbt)
		{
			bool result;
			if (db == "sql")
			{
				SqlBulkCopy sqlBulkCopy;
				if (dbt != null)
				{
					sqlBulkCopy = new SqlBulkCopy((SqlConnection)dbt.Connection, SqlBulkCopyOptions.CheckConstraints, (SqlTransaction)dbt);
				}
				else
				{
					SqlConnection sqlConnection = (SqlConnection)DatabaseFactory.CreateDatabase(dbtype.ToString()).CreateConnection();
					sqlBulkCopy = new SqlBulkCopy(sqlConnection.ConnectionString, SqlBulkCopyOptions.UseInternalTransaction);
				}
				sqlBulkCopy.DestinationTableName = dt.TableName;
				foreach (DataColumn dataColumn in dt.Columns)
				{
					sqlBulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
				}
				sqlBulkCopy.WriteToServer(dt);
				sqlBulkCopy.Close();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
