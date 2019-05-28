using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Costumernaya
{
   
    
    //class OPLATA
    //{
    //    void Info (string[] args)
    //    {
    //        SqlConnection conn = DBUtils.GetDBConnection();
    //        conn.Open();
    //        string sql = "Select * from OPLATA";
    //        SqlCommand cmd = new SqlCommand();

    //        // Сочетать Command с Connection.
    //        cmd.Connection = conn;
    //        cmd.CommandText = sql;
    //        conn.Close();
    //    }
    //}
        public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
           // // Show("Getting Connection ...");
           //SqlConnection conn = DBUtils.GetDBConnection();
           // conn.Open();
           // try
           // {

           //     MessageBox.Show("Connection successful!");
           // }
           // catch (Exception e1)
           // {
           //     MessageBox.Show("Error: " + e1.Message);
           // }
           // finally
           // {
           //     // Закрыть соединение.
           //     conn.Close();
           //     // Разрушить объект, освободить ресурс.
           //     conn.Dispose();
           // }


           // string sql = "Select * from COSTUMES";
           // SqlCommand cmd = new SqlCommand();
           // cmd.CommandText = sql;

      

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

                DateTime date1 = dateTimePicker1.Value;
                DateTime date2 = dateTimePicker2.Value;
                int summa = 0;
                for (int i = 0; i < DECLARATION.DOHOD(date1, date2).Count; i++)
                {
                    listView1.Items.Add(Convert.ToString(DECLARATION.DOHOD(date1, date2)[i].ID_ZAKAZA));
                    listView1.Items[i].SubItems.Add(Convert.ToString(DECLARATION.DOHOD(date1, date2)[i].SUMMA_OPLATY));
                    summa += DECLARATION.DOHOD(date1, date2)[i].SUMMA_OPLATY;
                }
                textBox3.Text = Convert.ToString(0.82 * summa);
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Login f4 = new Login();
            f4.ShowDialog();
            Close();
        }
    }
}
