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
    class DECLARATION
    {
        public int ID_ZAKAZA { get; set; }
        public int ID_KVITANCII { get; set; }
        public int SUMMA_OPLATY { get; set; }
        public static List<DECLARATION> DOHOD(DateTime date1, DateTime date2)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var param = new { date1, date2 };
                return db.Query<DECLARATION>("Bugalter_help", param, commandType: CommandType.StoredProcedure).ToList();




            }
        }
    }
}
