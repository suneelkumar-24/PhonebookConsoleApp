using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;

namespace PhonebookConsoleApp
{
    interface IDB
    {

        DataTable executeQuery(string sqlQuery);

        DataTable executeStoreProcedure(string procedureName);

        DataTable executeStoreProcedure(string procedureName, List<SqlParameter> parameters);
    }
}
