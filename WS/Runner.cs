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
    public partial class Runner : Form
    {
        public Runner()
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

        private void Button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Contacts Contacts = new Contacts();
            Contacts.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string email = File.ReadAllText("Resources/login.txt");
            EditR EditR = new EditR();
            using (SqlConnection conn = new SqlConnection(WS.Properties.Settings.Default.МарафонConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT [User].Email, [User].Password, [User].FirstName, [User].LastName, Runner.Gender, Runner.DateOfBirth, Runner.CountryCode, [Image] FROM [User] INNER JOIN Runner ON [User].Email = Runner.Email where [User].Email='" + email + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EditR.label14.Text = reader["Email"].ToString();
                    EditR.textBox4.Text = reader["FirstName"].ToString();
                    EditR.textBox5.Text = reader["LastName"].ToString();
                    EditR.comboBox1.Text = reader["Gender"].ToString();
                    EditR.dateTimePicker1.Value = Convert.ToDateTime(reader["DateOfBirth"]);
                    EditR.comboBox2.Text = reader["CountryCode"].ToString();
                    if (reader["Image"].ToString() != "")
                    {
                        EditR.pictureBox1.Image = Image.FromFile("Resources/" + reader["Image"]);
                    }
                    EditR.textBox6.Text = reader["Image"].ToString();
                }
                conn.Close();
            }
            EditR.Show();
            this.Hide();
        }
    }
}
