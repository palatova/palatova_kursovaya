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
    class ORDER
    {
        public int ID_ZAKAZA { get; set; }
        public int ID_COSTUME { get; set; }
        public int ID_KVITANCII { get; set; }
        public string VOZVRAT { get; set; }
        public int ID_CLIENT{ get; set; }
        public string DATA_VIPOLNENIA { get; set; }
        public string DEN_GOTOVNOSTI { get; set; }
        public static void Insert(int id_c, int id_k, int id_cl)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "INSERT INTO [ORDER](ID_COSTUME,ID_KVITANCII,ID_CLIENT) VALUES(@id_c,@id_k, @id_cl);";
                db.Execute(sqlQuery, new { id_c,id_k, id_cl });

            }


        }
        public static List<ORDER> Get()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<ORDER>("SELECT ID_ZAKAZA,ID_COSTUME,ID_KVITANCII,ID_CLIENT,DATA_VIPOLNENIA,DEN_GOTOVNOSTI FROM [ORDER]").ToList();
            }
        }
        public static void Update(int id_zakaza, int id_costume, int id_kvitancii, int id_client)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "UPDATE [ORDER] " +
                    "SET ID_COSTUME=@id_costume WHERE(ID_ZAKAZA=@id_zakaza) " +
                    "UPDATE [ORDER] SET ID_KVITANCII=@id_kvitancii WHERE(ID_ZAKAZA=@id_zakaza)" +
                    "UPDATE [ORDER] SET ID_CLIENT=@id_client WHERE(ID_ZAKAZA=@id_zakaza)";
                db.Execute(sqlQuery, new { id_costume, id_zakaza, id_kvitancii, id_client});

            }


        }
        public static List<int> NAL(int id)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var param = new { id };
                return db.Query<int>("Nalichie_zakaz", param, commandType: CommandType.StoredProcedure).ToList();

            }
        }
        public static int Id_Kvit_Last()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<int>("SELECT ID_KVITANCII FROM [ORDER] WHERE(ID_ZAKAZA=(SELECT MAX(ID_ZAKAZA) FROM [ORDER]))").FirstOrDefault();
            }
        }
        public static List<ORDER> Id_Zakaza()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<ORDER>("SELECT ID_ZAKAZA FROM [ORDER]").ToList();
            }
        }
        public static List<ORDER> Id_Kvitancii()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<ORDER>("SELECT ID_KVITANCII FROM [ORDER]").ToList();
            }
        }
        public static List<ORDER> Id_Client()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<ORDER>("SELECT ID_CLIENT FROM [ORDER]").ToList();
            }
        }

    }
}
