using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Costumernaya
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection(string datasource,string database, string username, string password)
        {
            //string datasource = @"DESKTOP-MJ9ENA5";
            //string database= "COSTUMERNAYA";
           // string username = "Ivanova";
           // string password = "12345";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
      
    }

}
