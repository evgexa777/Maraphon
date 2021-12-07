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
using System.IO;


namespace WS
{
    public partial class RegistrM : Form
    {
        string kit = "";//переменная для RadioBatton - буква Варианта
        int cost = 0;//переменная для RadioBatton - стоимость
        int b = 0;//переменная для RadioBatton -сумма взноса

        public RegistrM()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2021  6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            label13.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString()
                + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void Buttonback_Click(object sender, EventArgs e)//Назад
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)//Logout
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)//Отмена
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void RegistrM_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName  FROM Charity";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                label11.Text = (Convert.ToInt32(label11.Text) + 145).ToString();
            else
                label11.Text = (Convert.ToInt32(label11.Text) - 145).ToString();
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                label11.Text = (Convert.ToInt32(label11.Text) + 75).ToString();
            else
                label11.Text = (Convert.ToInt32(label11.Text) - 75).ToString();
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                label11.Text = (Convert.ToInt32(label11.Text) + 20).ToString();
            else
                label11.Text = (Convert.ToInt32(label11.Text) - 20).ToString();
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                kit = "A";
                cost = 0;
                label11.Text = (Convert.ToInt32(label11.Text) + 0).ToString();
            }
            else
                label11.Text = (Convert.ToInt32(label11.Text) - 0).ToString();

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                kit = "B";
                cost = 20;
                label11.Text = (Convert.ToInt32(label11.Text) + 20).ToString();
            }
            else
                label11.Text = (Convert.ToInt32(label11.Text) - 20).ToString();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                kit = "C";
                cost = 45;
                label11.Text = (Convert.ToInt32(label11.Text) + 45).ToString();
            }
            else
                label11.Text = (Convert.ToInt32(label11.Text) - 45).ToString();

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0)
            {
                textBox2.Text = "0";
                label11.Text = (Convert.ToInt32(label11.Text) - b).ToString();
            }
            label11.Text = (b + Convert.ToInt32(textBox2.Text)).ToString();
        }

        private void TextBox2_Click(object sender, EventArgs e)
        {
            b = Convert.ToInt32(label11.Text);
        }

        private void PictureBox1_Click(object sender, EventArgs e)//переход на форму при нажатии на картинку Инфо
        {
            Fond Fond = new Fond();
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName,CharityDescription,CharityLogo  FROM Charity WHERE CharityName='" + comboBox1.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Fond.label1.Text = reader["CharityName"].ToString();
                    Fond.richTextBox1.Text = reader["CharityDescription"].ToString();
                    Fond.pictureBox1.Image = Image.FromFile("Resources/" + reader["CharityLogo"].ToString());
                }
                conn.Close();
            }
            Fond.ShowDialog();

        }

        private void Button1_Click(object sender, EventArgs e)//Регистрация
        {
            string charity = "";
            string rid = "";
            string email = File.ReadAllText("Resources/run.txt");
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT RunnerID  FROM Runner where Email='" + email + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rid = reader[0].ToString();
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = "SELECT CharityId  FROM Charity where CharityName='" + comboBox1.Text + "'";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    charity = reader1[0].ToString();
                }
                conn.Close();
            }
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true)
            {
                using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into Registration Values ('" + rid + "','" + DateTime.Today + "','" + kit + "','4','" + cost + "','" + charity + "','" + textBox2.Text + "')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                CompleteRunner CompleteRunner = new CompleteRunner();
                CompleteRunner.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Вы не выбрали марафон.");
            }

        }
    }
}
