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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((ORDER.Id_Kvit_Last() == OPLATA.Id_Kvit())||(comboBox3.SelectedItem.ToString() != comboBox2.SelectedItem.ToString()))
            {
                MessageBox.Show("Оплата заказ не был оплачен!");
            }
            else
            {



                if ((textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (comboBox2.SelectedIndex == -1))
                {
                    MessageBox.Show("Одно из обязательных полей не заполнено");
                }
                else
                {
                    if ((textBox11.Text.Contains("@"))&&(textBox11.Text.Contains(".")))
                    {

                        String FAMILY = textBox4.Text;
                    String NAME = textBox5.Text;
                    String OT = textBox6.Text;
                    try
                    {
                        int id = CLIENT_INFO.Get_id(FAMILY, NAME, OT);
                        ORDER.Insert(Convert.ToInt32(comboBox2.SelectedItem.ToString()), OPLATA.Id_Kvit(), id);
                    }
                    catch (Exception e2)
                    {
                        if ((textBox11.Text == ""))
                        {
                            MessageBox.Show(" Поле email не заполнено");
                        }
                        else
                        {
                            CLIENT.Insert();
                            CLIENT_INFO.Insert(FAMILY, NAME, OT, textBox11.Text);
                        }
                        int id = CLIENT_INFO.Get_id(FAMILY, NAME, OT);
                        ORDER.Insert(Convert.ToInt32(comboBox2.SelectedItem.ToString()), OPLATA.Id_Kvit(), id);
                    }
                   
                        MessageBox.Show("Заказ успешно оформлен");
                    }
                    else
                    {
                        MessageBox.Show("Некорректный ввод Email ");
                    }
                }

            }
           
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            for (int i = 0; i < COSTUME.Get().Count; i++)
            {
                listView1.Items.Add(Convert.ToString(COSTUME.Get()[i].ID));
                listView1.Items[i].SubItems.Add(Convert.ToString(COSTUME.Get()[i].TYPE));
                listView1.Items[i].SubItems.Add(Convert.ToString(COSTUME.Get()[i].COUNT_C));
                listView1.Items[i].SubItems.Add(COSTUME.Get()[i].NAME);
                
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < COSTUME.Id_Costume().Count; i++)
            {
                comboBox2.Items.Add(Convert.ToString(COSTUME.Id_Costume()[i].ID));
     

            }
            for (int i = 0; i < COSTUME.Id_Costume().Count; i++)
            {
                comboBox3.Items.Add(Convert.ToString(COSTUME.Id_Costume()[i].ID));


            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "")||(textBox8.Text == ""))
            {
                MessageBox.Show("Одно из обязательных полей не заполнено");
            }
            else
            {
                COSTUME.Insert(Convert.ToInt32(textBox1.Text), textBox8.Text);
                int id_costume = COSTUME.Get_Id(textBox8.Text);
                COSTUMES_CENA.Insert(id_costume,Convert.ToInt32(textBox2.Text));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            String text = listView1.SelectedItems[0].Text;
            listView1.Items.Remove(listView1.SelectedItems[0]);
            int id_costume = COSTUME.Get_Id(textBox8.Text);
            COSTUMES_CENA.Delete(id_costume);
            COSTUME.Delete(Convert.ToInt32(text));
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Не выбран тип оплаты");
            }
            else
            {

                string type_oplaty = comboBox1.SelectedItem.ToString();
                int type = 0;

                if (type_oplaty == "1 - наличными")
                {
                    type = 1;
                }
                else
                {
                    type = 2;
                }
                
                    int ID2 = OPLATA.Insert(type, Convert.ToInt32(textBox9.Text));
                    MessageBox.Show("Оплата прошла успешно. Номер квитанции:" + Convert.ToString(ID2));
                    textBox10.Text = Convert.ToString(ID2);
        

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран номер костюма");
            }
            else
            {
                string t = comboBox3.SelectedItem.ToString();
                if (t != "")
                {
                    int p = COST_COSTUME.GET_COST(Convert.ToInt32(t));
                    textBox9.Text = Convert.ToString(p);
                }
                else
                {
                    MessageBox.Show("Не введен номер костюма!");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Login f4 = new Login();
            f4.ShowDialog();
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
