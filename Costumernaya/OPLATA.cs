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
    class OPLATA
    {
        public int ID_KVITANCII { get; set; }
        public int TIP_OPLATY { get; set; }
        public int SUMMA_OPLATY { get; set; }
        public static int Insert(int TIP, int SUMMA)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "INSERT INTO OPLATA (TIP_OPLATY,SUMMA_OPLATY) VALUES(@TIP, @SUMMA);";
                db.Execute(sqlQuery, new { TIP,SUMMA });
                return db.Query<int>("SELECT ID_KVITANCII FROM OPLATA WHERE ID_KVITANCII=(SELECT MAX(ID_KVITANCII) FROM OPLATA)").FirstOrDefault();
            }


        }
        public static int Id_Kvit()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<int>("SELECT MAX(ID_KVITANCII) FROM OPLATA").FirstOrDefault();
            }
        }

    }
}
