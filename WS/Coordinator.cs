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
    public partial class Coordinator : Form
    {
        public Coordinator()
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

 
    }
}
