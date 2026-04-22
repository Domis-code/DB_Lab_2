namespace Lab_2_DB;

using System.Collections.Concurrent;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

public class Sql
{
	private class QueryFormatter 
	{
		public string ParamValToStr(MySqlParameter param)
		{
			string strPv = "";

			switch (param.MySqlDbType)
			{
				case MySqlDbType.Text:				
				case MySqlDbType.VarChar:
				case MySqlDbType.VarString:
				case MySqlDbType.Enum:
				case MySqlDbType.Date:
				case MySqlDbType.Time:
				case MySqlDbType.Timestamp:
				case MySqlDbType.DateTime:
				case MySqlDbType.Year:
				case MySqlDbType.Newdate: 
					{
						if( param.Value == null || param.Value == DBNull.Value )
							strPv = "NULL";
						else
							strPv = "'" + param.Value.ToString().Replace("'", "''") + "'";

						break;
					}

				case MySqlDbType.Bit:
					{
						if( param.Value == null || param.Value == DBNull.Value )
							strPv = "NULL";
						else
							strPv = ((bool)param.Value == false) ? "0" : "1";

						break;
					}

				default:
					{
						if( param.Value == null || param.Value == DBNull.Value )
							strPv = "NULL";
						else
							strPv = param.Value.ToString().Replace("'", "''");
						break;
					}
			}

			return strPv;
		}

		public string CommandToStr(MySqlCommand cmd)
		{
			string sql = cmd.CommandText;

			sql = 
				sql.Replace("\r\n", "")
				.Replace("\r", "")
				.Replace("\n", "");
			sql = Regex.Replace(sql, @"\s+", " ");

			foreach( MySqlParameter param in cmd.Parameters )
			{
				string paramName = param.ParameterName;
				string paramValue = ParamValToStr(param);
				sql = sql.Replace(paramName, paramValue);
			}

			sql = sql.Replace("= NULL", "IS NULL");
			sql = sql.Replace("!= NULL", "IS NOT NULL");

			return sql;
		}
	}

	public class DataRowExtractor
	{
		private DataRow mRow;
		
		private Sql mSql;

		public DataRowExtractor(DataRow row, Sql sql)
		{
			if( row == null )
				throw new ArgumentException("Argument 'row' is null.");

			if( sql == null )
				throw new ArgumentException("Argument 'sql' is null.");

			this.mRow = row;
			this.mSql = sql;
		}

		public T From<T>(string attrName)
		{
			if( attrName == null )
				throw new ArgumentException("Argument 'attrName' is null.");

			var attr = mRow[attrName];

			{
				if( typeof(T) == typeof(byte) )
					return (T)(object)Convert.ToByte(attr);

				if( typeof(T) == typeof(byte?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToByte(it));

				if( typeof(T) == typeof(short) )
					return (T)(object)Convert.ToInt16(attr);

				if( typeof(T) == typeof(short?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToInt16(it));

				if( typeof(T) == typeof(int) )
					return (T)(object)Convert.ToInt32(attr);

				if( typeof(T) == typeof(int?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToInt32(it));

				if( typeof(T) == typeof(long) )
					return (T)(object)Convert.ToInt64(attr);

				if( typeof(T) == typeof(long?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToInt64(it));

				if( typeof(T) == typeof(bool) )
					return (T)(object)Convert.ToBoolean(attr);

				if( typeof(T) == typeof(bool?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToBoolean(it));

				if( typeof(T) == typeof(double) )
					return (T)(object)Convert.ToDouble(attr);

				if( typeof(T) == typeof(double?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToDouble(it));

				if( typeof(T) == typeof(float) )
					return (T)(object)Convert.ToDouble(attr);

				if( typeof(T) == typeof(float?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToDouble(it));

				if( typeof(T) == typeof(decimal) )
					return (T)(object)Convert.ToDecimal(attr);

				if( typeof(T) == typeof(decimal?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToDecimal(it));

				if( typeof(T) == typeof(DateTime) )
					return (T)(object)Convert.ToDateTime(attr);

				if( typeof(T) == typeof(DateTime?) )
					return (T)(object)mSql.AllowNull(attr, it => Convert.ToDateTime(it));

				if( typeof(T) == typeof(string) )
					return (T)(object)Convert.ToString(attr);

				throw new Exception($"Target type '{typeof(T)}' is not supported in '<T>'.");
			}
		}
	}

	public class CommandArgumentSetter
	{
		private MySqlCommand mCmd;

		public CommandArgumentSetter(MySqlCommand cmd)
		{
			if( cmd == null )
				throw new ArgumentException("Argument 'row' is null.");

			this.mCmd = cmd;
		}

		public void Add<T>(string argName, T argValue)
		{
			if( argName == null )
				throw new ArgumentException("Argument 'argName' is null.");

			var pars = mCmd.Parameters;

			{
				if( typeof(T) == typeof(byte) || typeof(T) == typeof(byte?) )
				{
					pars.Add(argName, MySqlDbType.Byte).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(short) || typeof(T) == typeof(short?) )
				{
					pars.Add(argName, MySqlDbType.Int16).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(int) || typeof(T) == typeof(int?) )
				{
					pars.Add(argName, MySqlDbType.Int32).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(long) || typeof(T) == typeof(long?) )
				{
					pars.Add(argName, MySqlDbType.Int64).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(bool) || typeof(T) == typeof(bool?) )
				{
					pars.Add(argName, MySqlDbType.Bit).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(double) || typeof(T) == typeof(double?) )
				{
					pars.Add(argName, MySqlDbType.Double).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(float) || typeof(T) == typeof(float?) )
				{
					pars.Add(argName, MySqlDbType.Float).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(decimal) || typeof(T) == typeof(decimal?) )
				{
					pars.Add(argName, MySqlDbType.Decimal).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?) )
				{
					pars.Add(argName, MySqlDbType.DateTime).Value = argValue;
					return;
				}

				if( typeof(T) == typeof(string) )
				{
					pars.Add(argName, MySqlDbType.VarChar).Value = argValue;
					return;
				}

				throw new Exception($"Source type '{typeof(T)}' is not supported in 'paramValue'.");
			}
		}
	}

	public static AsyncLocal<Sql> LocalInstance = new AsyncLocal<Sql>();

	public static ConcurrentDictionary<String, ConcurrentQueue<String>> Queries { get; } = new ConcurrentDictionary<String, ConcurrentQueue<String>>();

	private String mHttpRequestId;

	public Sql(String httpRequestId) 
	{
		if( httpRequestId == null )
			throw new ArgumentException("Argument 'httpRequest' is null.");

		this.mHttpRequestId = httpRequestId;

		Queries[httpRequestId] = new ConcurrentQueue<string>();
	}

	~Sql() 
	{
		if( Queries.ContainsKey(mHttpRequestId) )
			Queries.Remove(mHttpRequestId, out _);
	}

	private String RecordCommandSql(MySqlCommand cmd) 
	{
		var qf = new QueryFormatter();
		var sql = qf.CommandToStr(cmd);
		Queries[mHttpRequestId].Enqueue(sql);

		return sql;
	}

	public DataRowCollection Query(string query, Action<CommandArgumentSetter> args = null)
	{
		var dbConnStr = Config.DBConnStr;

		using( var dbCon = new MySqlConnection(dbConnStr) )
		using( var dbCmd = new MySqlCommand(query, dbCon) )
		{
			if( args != null )
			{
				var cas = new CommandArgumentSetter(dbCmd);
				args(cas);
			}

			var sql = RecordCommandSql(dbCmd);

			dbCon.Open();
			var da = new MySqlDataAdapter(dbCmd);
			var dt = new DataTable();
			da.Fill(dt);

			return dt.Rows;
		}
	}

	public long Insert(string statement, Action<CommandArgumentSetter> args = null)
	{
		var dbConnStr = Config.DBConnStr;

		using( var dbCon = new MySqlConnection(dbConnStr) )
		using( var dbCmd = new MySqlCommand(statement, dbCon) )
		{
			if( args != null)
			{
				var cas = new CommandArgumentSetter(dbCmd);
				args(cas);
			}

			var sql = RecordCommandSql(dbCmd);

			dbCon.Open();
			var numRowsAffected = dbCmd.ExecuteNonQuery();

			return dbCmd.LastInsertedId;
		}
	}

	public int Update(string statement, Action<CommandArgumentSetter> args = null)
	{
		var dbConnStr = Config.DBConnStr;

		using( var dbCon = new MySqlConnection(dbConnStr) )
		using( var dbCmd = new MySqlCommand(statement, dbCon) )
		{
			if( args != null )
			{
				var cas = new CommandArgumentSetter(dbCmd);
				args(cas);
			}

			var sql = RecordCommandSql(dbCmd);

			dbCon.Open();
			var numRowsAffected = dbCmd.ExecuteNonQuery();

			return numRowsAffected;
		}
	}

	public int Delete(string statement, Action<CommandArgumentSetter> args = null)
	{
		var dbConnStr = Config.DBConnStr;

		using( var dbCon = new MySqlConnection(dbConnStr) )
		using( var dbCmd = new MySqlCommand(statement, dbCon) )
		{
			if( args != null )
			{
				var cas = new CommandArgumentSetter(dbCmd);
				args(cas);
			}

			var sql = RecordCommandSql(dbCmd);

			dbCon.Open();
			var numRowsAffected = dbCmd.ExecuteNonQuery();

			return numRowsAffected;
		}
	}

	public T AllowNull<E,T>(E entry, Func<E, T> converter) where E : class
	{
		if( entry == DBNull.Value )
			return default(T);

		return converter(entry);
	}

	public List<T> MapAll<T>(DataRowCollection rows, Action<DataRowExtractor, T> mapper) where T : class, new()
	{
		var list = new List<T>(rows.Count);

		foreach(DataRow row in rows)
		{
			var target = new T();

			var extr = new DataRowExtractor(row, this);
			mapper(extr, target);

			list.Add(target);
		}

		return list;
	}

	public T MapOne<T>(DataRowCollection rows, Action<DataRowExtractor, T> mapper) where T : class, new()
	{	
		if( rows.Count == 0 )
			throw new ArgumentException("There are no rows in argument 'rows'.");

		var target = new T();

		var extr = new DataRowExtractor(rows[0], this);
		mapper(extr, target);

		return target;
	}
}




