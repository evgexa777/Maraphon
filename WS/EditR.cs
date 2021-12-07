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
    public partial class EditR : Form
    {
        SqlDataAdapter adapter;
        DataSet dataSet = new DataSet();
        string strings = "Фонд";
        BindingSource BindingSource = new BindingSource();

        public EditR()
        {
            InitializeComponent();
            if (textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == ""
                | textBox6.Text == "" | comboBox2.Text == "" | comboBox1.Text == "")
                button1.Enabled = false;
            else
                button1.Enabled = true;
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

        private void Button4_Click(object sender, EventArgs e)//Logout
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)//Отмена
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)//Сохранить
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
            if (textBox2.Text == "" && textBox3.Text == "")
            {
                SqlConnection con = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString);
                // Выборка
                adapter = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Runner ON [User].Email = Runner.Email", con);
                // Запрос на вставку
                adapter.InsertCommand = new SqlCommand("Update [User] set FirstName='" + textBox4.Text + "',LastName='" + textBox5.Text + 
                    "' where Email='" + label14.Text + "'" + "Update Runner set Gender = '" + comboBox1.Text + "', DateOfBirth = '" + 
                    dateTimePicker1.Value + "', CountryCode = '" + code + "', Image='" + textBox6.Text + "' where Email = '" + label14.Text + "'", con);
                // Создание набора таблиц
                dataSet = new DataSet();
                // Заполнение таблицы
                adapter.Fill(dataSet, strings);
                // Привязка к таблице
                BindingSource = new BindingSource(dataSet, strings);
                con.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
                Runner Runner = new Runner();
                Runner.Show();
                this.Hide();
            }
            else if (textBox2.Text == textBox3.Text && textBox2.Text != "" && textBox3.Text != "")
            {
                SqlConnection con = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString);
                // Выборка
                adapter = new SqlDataAdapter("SELECT * FROM [User] INNER JOIN Runner ON [User].Email = Runner.Email", con);
                // Запрос на вставку
                adapter.InsertCommand = new SqlCommand("Update [User] set [Password]='" + textBox2.Text + "',FirstName='" + textBox4.Text + 
                    "',LastName='" + textBox5.Text + "' where Email='" + label14.Text + "'" + "Update Runner set Gender = '" + comboBox1.Text 
                    + "', DateOfBirth = '" + dateTimePicker1.Value + "', CountryCode = '" + code + "', Image='" + textBox6.Text + 
                    "' where Email = '" + label14.Text + "'", con);
                // Создание набора таблиц
                dataSet = new DataSet();
                // Заполнение таблицы
                adapter.Fill(dataSet, strings);
                // Привязка к таблице
                BindingSource = new BindingSource(dataSet, strings);
                con.Open();
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
                Runner Runner = new Runner();
                Runner.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пароли не совпадают.");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox6.Text = openFileDialog1.SafeFileName;
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void EditR_Load(object sender, EventArgs e)
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

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            string expresion = @"(?=.*[\d])(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z])(?=.*[!@#$%^]).{6,}";
            if (Regex.IsMatch(textBox2.Text, expresion))
                textBox2.BackColor = Color.White;
            else
                textBox2.BackColor = Color.Red;
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
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
    }
}
