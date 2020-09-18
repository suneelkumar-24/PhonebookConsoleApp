using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhonebookConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DBManager manager = new DBManager("dbConnString");
            String sqlQuery = "select * from user_data";
           //  DataTable dt = manager.executeStoreProcedure("getAllUser");
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@userID", 2));

            DataTable dt = manager.executeStoreProcedure("getUser", parameters);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["user_id"].ToString() + "----" + row["user_name"].ToString());
            }

        }
    }
}
