using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MySQLDALManager : IDAL
    {
        public DataTable executeQuery(string sqlQuery)
        {
            throw new NotImplementedException();
        }

        public DataTable executeStoreProcedure(string procedureName)
        {
            throw new NotImplementedException();
        }

        public DataTable executeStoreProcedure(string procedureName, List<SqlParameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
