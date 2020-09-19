using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDAL
    {
        DataTable executeQuery(string sqlQuery);

        DataTable executeStoreProcedure(string procedureName);

        DataTable executeStoreProcedure(string procedureName, List<SqlParameter> parameters);
    }
}
