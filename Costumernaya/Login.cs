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
    public partial class Login : Form
    {
        public string Data
        {
            get
            {
                return textBox1.Text;
            }
        }
        public string Data1
        {
            get
            {
                return textBox2.Text;
            }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
          
            try
            {
                SqlConnection conn = DBUtils.GetDBConnection(@"DESKTOP-MJ9ENA5", "COSTUMERNAYA", username, password);
                conn.Open();
                var command = new SqlCommand("Select role From Users WHERE login=@login AND password=@password", conn);
                var command1 = new SqlCommand("Select role From Users WHERE login='Palatova' AND password=54321", conn);
                var command2 = new SqlCommand("Select role From Users WHERE login='Ivanova' AND password=12345", conn);
                var command3 = new SqlCommand("Select role From Users WHERE login='Petrova' AND password=56789", conn);
                string role_admin = (string)command1.ExecuteScalar();
                string role_bugalter = (string)command2.ExecuteScalar();
                string role_prodavec = (string)command3.ExecuteScalar();
                command.Parameters.AddWithValue("@login", username);
                command.Parameters.AddWithValue("@password", password);
                string role = (string)command.ExecuteScalar();
                if (role == role_admin)
                {
                    Login.ActiveForm.Hide();
                    admin f4 = new admin();
                    f4.ShowDialog();
                    Close();
                }
                else
                {
                    if (role == role_prodavec)
                    {
                        Login.ActiveForm.Hide();
                        Form4 f4 = new Form4();
                        f4.ShowDialog();
                        Close();
                    }
                    else
                    {
                        if (role == role_bugalter)
                        {
                            Login.ActiveForm.Hide();
                            Form1 f4 = new Form1();
                            f4.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не имеет прав доступа к данному приложению");
                        }

                    }
                       
                }
                conn.Close();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Логин или пароль введен неправильно!");
            }
           
           



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
