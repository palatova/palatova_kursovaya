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
    class COSTUMES_CENA
    {
        public int ID_COSTUME { get; set; }
        public int CENA { get; set; }
        public static void Insert(int ID, int CENA)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "INSERT INTO COSTUMES_CENA (ID_COSTUME,CENA) VALUES(@ID, @CENA);";
                db.Execute(sqlQuery, new { ID, CENA});
            }


        }
        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "DELETE FROM COSTUMES_CENA WHERE ID_COSTUME = @id";
                db.Execute(sqlQuery, new { id });

            }

        }
    }
}
