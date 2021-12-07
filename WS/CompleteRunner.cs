using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS
{
    public partial class CompleteRunner : Form
    {
        public CompleteRunner()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan time1;
            DateTime initial_time = Convert.ToDateTime("21.10.2021  6:00");
            DateTime current_time = DateTime.Now;
            time1 = initial_time - current_time;
            label3.Text = time1.Days.ToString() + " дней " + time1.Hours.ToString()
                + " часов и " + time1.Minutes.ToString() + " минут до старта марафона!";
        }

        private void Button2_Click(object sender, EventArgs e)//Logout
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)//Ok
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }

        private void Buttonback_Click(object sender, EventArgs e)//Назад
        {
            Runner Runner = new Runner();
            Runner.Show();
            this.Hide();
        }
    }
}
