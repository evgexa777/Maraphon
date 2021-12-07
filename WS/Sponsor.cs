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

namespace WS
{
    public partial class Sponsor : Form
    {
        public Sponsor()
        {
            InitializeComponent();
            if (textBox1.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | comboBox1.Text == "" 
                | comboBox2.Text == "" | dateTimePicker1.Text == "")
                button3.Enabled = false;
            else
                button3.Enabled = true;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2021  6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            label15.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString()
                + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)//сумма пожертвований
        {
            if (textBox5.TextLength == 0)
                textBox5.Text = "0";
            label14.Text = textBox5.Text;
            if (Convert.ToInt32(textBox5.Text) <= 0)
            {
                MessageBox.Show("Вы должны пожертвовать хотя бы 1$");
                button3.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
            }

        }

        private void Sponsor_Load(object sender, EventArgs e)//загрузка бегунов и благотворительности
        {
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT [User].FirstName + ' ' + [User].LastName + ' - ' + CONVERT(varchar(20),RegistrationEvent.BibNumber) + ' (' + Runner.CountryCode +')' AS Runner FROM Runner INNER JOIN              [User] ON Runner.Email = [User].Email INNER JOIN                         Registration ON Runner.RunnerId = Registration.RunnerId INNER JOIN RegistrationEvent ON Registration.RegistrationId = RegistrationEvent.RegistrationId WHERE([User].RoleId = N'R')"; SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0]);
                }
                conn.Close();
            }
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName FROM Charity";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0]);
                }
                conn.Close();
            }

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)//длина карты
        {
            if (textBox3.TextLength != 16)
                textBox3.BackColor = Color.Red;
            else
                textBox3.BackColor = Color.White;
            textBox3.MaxLength = 16;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)//проверка на действия карты
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("Срок действия карты истек!");
                button3.Enabled = false;
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength != 3)
                textBox4.BackColor = Color.Red;
            else
                textBox4.BackColor = Color.White;
            textBox4.MaxLength = 3;
        }

        private void Buttonback_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Fond Fond = new Fond();
            using (SqlConnection conn = new
            SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = " SELECT CharityName,CharityDescription,CharityLogo FROM Charity WHERE CharityName = '" + comboBox2.Text + "'";
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

        private void Button2_Click(object sender, EventArgs e)//Кнопка +
        {
            int p;
            p = Convert.ToInt32(textBox5.Text);
            p = p + 5;
            textBox5.Text = Convert.ToString(p);
            label14.Text = textBox5.Text;
        }

        private void Button1_Click(object sender, EventArgs e)//Кнопка -
        {
            int p;
            p = Convert.ToInt32(textBox5.Text);
            if (p >= 5)
            {
                p = p - 5;
                textBox5.Text = Convert.ToString(p);
                label14.Text = textBox5.Text;
            }
            else
            {
                MessageBox.Show("Невозможно выполнить операцию!\r\nСумма пожертвования не может быть меньше 0!");
            }
        }
    }
}
