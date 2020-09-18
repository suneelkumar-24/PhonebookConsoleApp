﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookConsoleApp
{

    //class MySqlManager : IDB
    //{
    //   if i have a another mysqlmanger than i can use this interface ;
    //}

    class DBManager : IDB
    {
        SqlConnection connection;

        public DBManager(string dbconnkey)
        {
            String connString = ConfigurationManager.ConnectionStrings[dbconnkey].ConnectionString;
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
