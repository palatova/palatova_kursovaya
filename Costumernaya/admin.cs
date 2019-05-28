using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Costumernaya
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            for (int i = 0; i < ORDER.Get().Count; i++)
            {
                listView1.Items.Add(Convert.ToString(ORDER.Get()[i].ID_ZAKAZA));
                listView1.Items[i].SubItems.Add(Convert.ToString(ORDER.Get()[i].ID_COSTUME));
                listView1.Items[i].SubItems.Add(Convert.ToString(ORDER.Get()[i].ID_KVITANCII));
                listView1.Items[i].SubItems.Add(Convert.ToString(ORDER.Get()[i].ID_CLIENT));
                listView1.Items[i].SubItems.Add(ORDER.Get()[i].DATA_VIPOLNENIA);
                listView1.Items[i].SubItems.Add(ORDER.Get()[i].DEN_GOTOVNOSTI);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Хотите изменить данное поле?");
            try
            {
                ORDER.Update(Convert.ToInt32(comboBox2.SelectedItem.ToString()), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void admin_Load(object sender, EventArgs e)
        {
           
            for (int i = 0; i < ORDER.Id_Zakaza().Count; i++)
            {
                comboBox2.Items.Add(Convert.ToString(ORDER.Id_Zakaza()[i].ID_ZAKAZA));


            }
            
            
            for (int i = 0; i < CLIENT_INFO.GET_INFO().Count; i++)
            {
                listView2.Items.Add(Convert.ToString(CLIENT_INFO.GET_INFO()[i].ID_CLIENT));
                listView2.Items[i].SubItems.Add(CLIENT_INFO.GET_INFO()[i].FAMILY);
                listView2.Items[i].SubItems.Add(CLIENT_INFO.GET_INFO()[i].NAME);
                listView2.Items[i].SubItems.Add(CLIENT_INFO.GET_INFO()[i].OTCHESTVO);
                listView2.Items[i].SubItems.Add(CLIENT_INFO.GET_INFO()[i].EMAIL);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login.ActiveForm.Hide();
            Form1 f4 = new Form1();
            f4.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login.ActiveForm.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
            Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Login f4 = new Login();
            f4.ShowDialog();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                if (String.IsNullOrEmpty(textBox5.Text))
                {
                    string family = textBox6.Text;
                    string name = textBox7.Text;
                    string otchestvo = textBox8.Text;
                    id = CLIENT_INFO.Get_id(family, name, otchestvo);
                }
                else
                {
                    id = Convert.ToInt32(textBox5.Text);
                }
                List<int> y = ORDER.NAL(id);
                int nal = 0;
                foreach (int item in y)
                {
                    if (item != 0)
                    {
                        nal = 1;
                    }
                }
                if (nal == 1)
                {
                    textBox9.Text = "заказ выполнен";
                }
                else
                {
                    textBox9.Text = "отсутствует";
                }
                textBox10.Text = CLIENT_INFO.GET_DATE(id);
                textBox11.Text = Convert.ToString(CLIENT_INFO.GET_COUNTER_ZAKAZOV(id));
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
                
          MessageBox.Show("Отправить данным клиентам рекламную рассылку с текстом:        "+ textBox12.Text+"\n"+ "?\n");
            
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
