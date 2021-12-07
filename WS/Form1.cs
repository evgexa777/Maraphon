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
    public partial class Form1 : Form
    {
        
        public static Form1 form1;
        public Form1()
        {
            InitializeComponent();
            form1 = this;

        }

        private void Buttonrun_Click(object sender, EventArgs e)
        {
            ПроверкаБегунов check = new ПроверкаБегунов();
            check.Show();
            Hide();
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

        private void Buttoninfo_Click(object sender, EventArgs e)
        {
            More More = new More();
            More.Show();
            this.Hide();
        }

        private void Buttonlog_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Buttonspon_Click(object sender, EventArgs e)
        {
            Sponsor spon = new Sponsor();
            spon.Show();
            this.Hide();
        }
    }
}
