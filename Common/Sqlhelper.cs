using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Common
{
    interface IDbHelper
    {

        int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters);

        object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters);

        IDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters);

        DataTable ExcuteDataTable(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters);

        DataSet ExcuteDataSet(string connectionString, CommandType commandType, string commandText, string srcTable, params IDataParameter[] commandParameters);
    }
    public class SqlHelper : IDbHelper
    {
        #region IDbHelper 成员

        public int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters)
        {
            int returnValue;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                command.Parameters.AddRange(commandParameters);

                connection.Open();
                returnValue = command.ExecuteNonQuery();
                connection.Close();
            }

            return returnValue;
        }

        public object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters)
        {
            object returnValue;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                command.Parameters.AddRange(commandParameters);

                connection.Open();
                returnValue = command.ExecuteScalar();
                connection.Close();
            }

            return returnValue;
        }

        public IDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = commandType;
            command.Parameters.AddRange(commandParameters);

            connection.Open();
            return command.ExecuteReader();
        }

        public DataTable ExcuteDataTable(string connectionString, CommandType commandType, string commandText, params IDataParameter[] commandParameters)
        {
            DataTable ThisDataTable = new DataTable();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(commandText, conn);
            cmd.CommandType = commandType;
            SqlDataAdapter DataAdaper = new SqlDataAdapter(cmd);
            cmd.Parameters.AddRange(commandParameters);
            conn.Open();
            DataAdaper.Fill(ThisDataTable);
            conn.Close();
            return ThisDataTable;
        }

        public DataSet ExcuteDataSet(string connectionString, CommandType commandType, string commandText, string srcTable, params IDataParameter[] commandParameters)
        {
            DataSet set = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = commandType;
                command.Parameters.AddRange(commandParameters);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(set, srcTable);
                connection.Close();
            }

            return set;
        }
        #endregion
    }
}