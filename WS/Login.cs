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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2021  6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            label2.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString()
                + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                int login = 0;
                string role = "";
                using (SqlConnection conn = new
                SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT Count(*) FROM [User] WHERE Email='" + textBox1.Text + "'AND Password = '" + textBox2.Text + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        login = Convert.ToInt32(reader[0]);
                    }
                    conn.Close();
                    conn.Open();
                    SqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "SELECT RoleId FROM [User] WHERE Email='" + textBox1.Text + "'AND Password = '" + textBox2.Text + "'";
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    while (reader1.Read())
                    {
                        role = reader1[0].ToString();
                    }
                    conn.Close();
                }
                if (login == 1)
                {
                    File.WriteAllText("Resources/login.txt", textBox1.Text);
                    if (role == "R")
                    {
                        Runner Runner = new Runner();
                        Runner.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (role == "A")
                        {
                            Admin Admin = new Admin();
                            Admin.Show();
                            this.Hide();
                        }
                        else
                        {
                            if (role == "C")
                            {
                                Coordinator Coordinator = new Coordinator();
                                Coordinator.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не правильный логин/пароль.");
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля!");
            }

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
