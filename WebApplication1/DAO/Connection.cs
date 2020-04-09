using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.DAO
{
	public class Connection
	{
		public SqlConnection con;
		public Connection(string sqlConnection)
		{
			con = new SqlConnection(sqlConnection);
			if(ConnectionState.Closed==con.State)
			{
				con.Open();
			}
			
		}
	}
	public class DBOperation
	{
		public SqlDataAdapter _sqlDataAdapter;
		public DataSet dataset;
		public Connection connetionObj;
		public SqlCommand command;
		public int InsertEmployee(string connection,string CommandText)
		{
			connetionObj = new Connection(connection);
			command = new SqlCommand(CommandText, connetionObj.con);
			int result = command.ExecuteNonQuery();
			return result;
		}
		public DataSet GetEmployees(string connection,string CommandText)
		{
			connetionObj = new Connection(connection);
			_sqlDataAdapter = new SqlDataAdapter(CommandText, connetionObj.con);
			dataset = new DataSet();
			_sqlDataAdapter.Fill(dataset);
			return dataset;
		}
		public int DeleteEmployee(string connection, string CommandText)
		{
			connetionObj = new Connection(connection);
			command = new SqlCommand(CommandText, connetionObj.con);
			int result = command.ExecuteNonQuery();
			return result;
		}
		public int UpdateEmployee(string connection, string CommandText)
		{
			connetionObj = new Connection(connection);
			command = new SqlCommand(CommandText, connetionObj.con);
			int result = command.ExecuteNonQuery();
			return result;
		}
	}
}
