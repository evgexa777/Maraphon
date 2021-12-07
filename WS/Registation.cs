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
using System.Text.RegularExpressions;


namespace WS
{
    public partial class Registation : Form
    {
        public Registation()
        {
            InitializeComponent();
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == ""
                | textBox6.Text == "" | comboBox2.Text == "" | comboBox1.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
        }

        private void Buttonback_Click(object sender, EventArgs e)// кнопка Назад
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
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

        private void Button2_Click(object sender, EventArgs e)//кнопка Отмена
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)//Просмотр
        {
            openFileDialog1.ShowDialog();
            textBox6.Text = openFileDialog1.SafeFileName;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void Registation_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT Gender  FROM Gender";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
                conn.Open();
                SqlCommand cmd1 = conn.CreateCommand();
                cmd1.CommandText = " SELECT CountryName  FROM Country";
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1[0]);
                }
                conn.Close();
            }
            var y = DateTime.Today;
            y = y.AddYears(-10);
            dateTimePicker1.MaxDate = y;
            dateTimePicker1.Value = y;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)//Email
        {
            string expresion = @".+@.+\..+";
            if (Regex.IsMatch(textBox1.Text, expresion))
                textBox1.BackColor = Color.White;
            else
                textBox1.BackColor = Color.Red;
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)//Password
        {
            string expresion = @"(?=.*[\d])(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*[!@#$%^]).{6,}";
            if (Regex.IsMatch(textBox2.Text, expresion))
                textBox2.BackColor = Color.White;
            else
                textBox2.BackColor = Color.Red;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)//Check password
        {
            if (textBox3.Text != textBox2.Text)
            {
                textBox3.BackColor = Color.Red;
                button1.Enabled = false;
            }
            else
            {
                textBox3.BackColor = Color.White;
                button1.Enabled = true;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string code = "";
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT CountryCode  FROM Country where CountryName='" + comboBox2.Text + "' OR CountryCode='" + comboBox2.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    code = reader[0].ToString();
                }
                conn.Close();
            }
            if (textBox2.Text == textBox3.Text)
            {
                using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "Insert into [User] Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','R')";
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "Insert into Runner Values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value + "','" + code + "','" + textBox6.Text + "')";
                    cmd1.ExecuteNonQuery();
                    conn.Close();
                }
                File.WriteAllText("Resources/run.txt", textBox1.Text);
                RegistrM RegistrM = new RegistrM();
                RegistrM.Show();
                this.Hide();
            }

        }
    }
}
