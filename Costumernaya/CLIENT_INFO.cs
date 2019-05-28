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
    class CLIENT_INFO
    {
        public int ID_CLIENT { get; set; }
        public string FAMILY { get; set; }
        public string NAME { get; set; }
        public string OTCHESTVO { get; set; }
        public string EMAIL { get; set; }
        public string DATE { get; set; }
        public int COUNTER_ZAKAZOV { get; set; }
        public static int Get_id(string family, string name, string otch)
        {
  
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "SELECT ID_CLIENT  FROM CLIENT_INFO  WHERE ((FAMILY=@FAMILY) AND (NAME= @NAME)AND(OTCHESTVO=@OTCH))";
                int userId = db.Query<int>(sqlQuery,new {family, name,otch}).FirstOrDefault();
                return userId;
            }
         
        }
        public static List<CLIENT_INFO> GET_INFO()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<CLIENT_INFO>("SELECT * FROM CLIENT_INFO").ToList();
            }
        }
        public static string GET_DATE(int id)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var param = new { id };
                return db.Query<string>("Choose_Date_Order", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                
            }
        }
        public static int GET_COUNTER_ZAKAZOV(int id)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                return db.Query<int>("SELECT COUNTER_ZAKAZOV FROM [CLIENT_INFO] WHERE(ID_CLIENT=@ID)", new { id }).FirstOrDefault();
               
            }
        }
        public static void Insert(string fam, string nam, string ot, string em)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                int id = db.Query<int>("SELECT MAX(ID) FROM CLIENT").FirstOrDefault();
                var sqlQuery = "INSERT INTO CLIENT_INFO (ID_CLIENT,FAMILY,NAME,OTCHESTVO, EMAIL) VALUES(@id,@fam,@nam,@ot,@em);";
                db.Execute(sqlQuery, new {id,fam,nam,ot,em});
            
            }


        }
    }
}
