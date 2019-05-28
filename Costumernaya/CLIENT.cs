using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;

namespace Costumernaya
{
    class CLIENT
    {
        public int NUMBER { get; set; }
        public int ID { get; set; }
        public static void Insert()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "INSERT INTO CLIENT (ID) VALUES((SELECT MAX(ID) FROM CLIENT)+1);";
                db.Execute(sqlQuery);

            }
        }
    }
}
