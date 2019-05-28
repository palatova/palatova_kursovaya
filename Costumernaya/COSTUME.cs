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
    class COSTUME
    {
        
            public int ID { get; set; }
            public int TYPE { get; set; }
            public int COUNT_C { get; set; }
            public string NAME { get; set; }

        public static List<COSTUME> Get()
        {
            
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<COSTUME>("SELECT * FROM COSTUME").ToList();
            }
        }
        public static int Get_Id(string NAME)
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<int>("SELECT ID FROM COSTUME WHERE (NAME=@NAME)",new { NAME}).FirstOrDefault();
            }
        }
        public static List<COSTUME> Id_Costume()
        {

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {

                return db.Query<COSTUME>("SELECT ID FROM COSTUME").ToList();
            }
        }
        public static void Insert(int COUNT_C, string NAME)
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
                {
                    var sqlQuery = "INSERT INTO COSTUME (TYPE,COUNT_C,NAME) VALUES(4,@COUNT_C, @NAME);";
                    db.Execute(sqlQuery, new { NAME, COUNT_C });

            }


        }

        public static void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var sqlQuery = "DELETE FROM COSTUME WHERE ID = @id";                  
                db.Execute(sqlQuery, new { id});

            }

        }
            //public int Get_Table()
            //{
            //    Login f = new Login();
            //    string username1 = f.Data;
            //    string password1 = f.Data1;
            //    SqlConnection conn = DBUtils.GetDBConnection(@"DESKTOP-MJ9ENA5", "COSTUMERNAYA", username1, password1);
            //    conn.Open();
            //    var command1 = new SqlCommand("Select ID From ORDER WHERE (TYPE=1)", conn);
            //    int id = (int)command1.ExecuteScalar();
            //    conn.Close();
            //    MessageBox.Show(Convert.ToString(id));

            //    return id;
            //}
        }
}
