using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SQLDALManager : IDAL
    {
        SqlConnection connection;

        public SQLDALManager(string connkey)
        {
            string connString = ConfigurationManager.ConnectionStrings[connkey].ConnectionString;
            connection = new SqlConnection(connString);
        }

        public DataTable executeQuery(string sqlQuery)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection);
            DataTable data = new DataTable();
            try
            {
                connection.Open();
                adapter.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return data;
            }
            finally
            {
                connection.Close();
            }
            
        }

        public DataTable executeStoreProcedure(string procedureName)
        {
            
            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            try
            {
                connection.Open();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return table;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable executeStoreProcedure(string procedureName, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(procedureName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach(SqlParameter param in parameters)
            {
                command.Parameters.Add(param);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();

            try
            {
                connection.Open();
                adapter.Fill(data);
                return data;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return data;
            }
            finally
            {
                connection.Close();
            }
            
        }
    }
}
