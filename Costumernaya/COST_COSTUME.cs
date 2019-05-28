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
    class COST_COSTUME
    {
        public int ID_COSTUME { get; set; }
        public int CENA { get; set; }
        public static int GET_COST(int id)
        {
           using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Costumernaya.Properties.Settings.COSTUMERNAYAConnectionString"].ConnectionString))
            {
                var param = new {id};
                return db.Query<int>("Costof_Costume", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
           }
        }
    }
}
