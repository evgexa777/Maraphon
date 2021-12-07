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
    public partial class HowLong : Form
    {
        public HowLong()
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

        private void Buttonback_Click(object sender, EventArgs e)
        {
            More More = new More();
            More.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            label4.Text = label11.Text;
            pictureBox1.Image = pictureBox7.Image;
            label5.Text = "Максимальная скорость F1 Car 345km/h. Это займет 12 минут, чтобы завершить 42km марафон.";
        }

        private void Label11_Click(object sender, EventArgs e)
        {
            label4.Text = label11.Text;
            pictureBox1.Image = pictureBox7.Image;
            label5.Text = "Максимальная скорость F1 Car 345km/h. Это займет 12 минут, чтобы завершить 42km марафон.";
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            label4.Text = label12.Text;
            pictureBox1.Image = pictureBox8.Image;
            label5.Text = "Максимальная скорость Slug 0.01km/h. Это займет 4200 часов, чтобы завершить 42km марафон.";
        }

        private void Label12_Click(object sender, EventArgs e)
        {
            label4.Text = label12.Text;
            pictureBox1.Image = pictureBox8.Image;
            label5.Text = "Максимальная скорость Slug 0.01km/h. Это займет 4200 часов, чтобы завершить 42km марафон.";
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            label4.Text = label13.Text;
            pictureBox1.Image = pictureBox9.Image;
            label5.Text = "Максимальная скорость Horse 15km/h. Это займет 2,8 часа, чтобы завершить 42km марафон.";

        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            label4.Text = label14.Text;
            pictureBox1.Image = pictureBox10.Image;
            label5.Text = "Максимальная скорость Sloth 0.12km/h. Это займет 350 часов, чтобы завершить 42km марафон.";
        }

        private void Label13_Click(object sender, EventArgs e)
        {
            label4.Text = label13.Text;
            pictureBox1.Image = pictureBox9.Image;
            label5.Text = "Максимальная скорость Horse 15km/h. Это займет 2,8 часа, чтобы завершить 42km марафон.";
        }

        private void Label14_Click(object sender, EventArgs e)
        {
            label4.Text = label14.Text;
            pictureBox1.Image = pictureBox10.Image;
            label5.Text = "Максимальная скорость Sloth 0.12km/h. Это займет 350 часов, чтобы завершить 42km марафон.";
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            label4.Text = label15.Text;
            pictureBox1.Image = pictureBox11.Image;
            label5.Text = "Максимальная скорость Capybara 35km/h. Это займет 1,2 часа, чтобы завершить 42km марафон.";
        }

        private void Label15_Click(object sender, EventArgs e)
        {
            label4.Text = label15.Text;
            pictureBox1.Image = pictureBox11.Image;
            label5.Text = "Максимальная скорость Capybara 35km/h. Это займет 1,2 часа, чтобы завершить 42km марафон.";
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            label4.Text = label16.Text;
            pictureBox1.Image = pictureBox12.Image;
            label5.Text = "Максимальная скорость Jaguar 80km/h. Это займет 31,5 минут, чтобы завершить 42km марафон.";
        }

        private void Label16_Click(object sender, EventArgs e)
        {
            label4.Text = label16.Text;
            pictureBox1.Image = pictureBox12.Image;
            label5.Text = "Максимальная скорость Jaguar 80km/h. Это займет 31,5 минут, чтобы завершить 42km марафон.";
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            label4.Text = label17.Text;
            pictureBox1.Image = pictureBox13.Image;
            label5.Text = "Максимальная скорость Worm 0.03km/h. Это займет 1400 часов, чтобы завершить 42km марафон.";
        }

        private void Label17_Click(object sender, EventArgs e)
        {
            label4.Text = label17.Text;
            pictureBox1.Image = pictureBox13.Image;
            label5.Text = "Максимальная скорость Worm 0.03km/h. Это займет 1400 часов, чтобы завершить 42km марафон.";
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            label4.Text = label6.Text;
            pictureBox1.Image = pictureBox2.Image;
            label5.Text = "Длина Bus 10m. Это займет 4200 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            label4.Text = label6.Text;
            pictureBox1.Image = pictureBox2.Image;
            label5.Text = "Длина Bus 10m. Это займет 4200 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            label4.Text = label7.Text;
            pictureBox1.Image = pictureBox3.Image;
            label5.Text = "Длина Pair of Havaianas 0.245m. Это займет 171429 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            label4.Text = label7.Text;
            pictureBox1.Image = pictureBox3.Image;
            label5.Text = "Длина Pair of Havaianas 0.245m. Это займет 171429 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            label4.Text = label8.Text;
            pictureBox1.Image = pictureBox4.Image;
            label5.Text = "Длина AirBus A380 73m. Это займет 576 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            label4.Text = label8.Text;
            pictureBox1.Image = pictureBox4.Image;
            label5.Text = "Длина AirBus A380 73m. Это займет 576 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            label4.Text = label9.Text;
            pictureBox1.Image = pictureBox5.Image;
            label5.Text = "Длина Football Field 105m. Это займет 400 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void Label9_Click(object sender, EventArgs e)
        {
            label4.Text = label9.Text;
            pictureBox1.Image = pictureBox5.Image;
            label5.Text = "Длина Football Field 105m. Это займет 400 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            label4.Text = label10.Text;
            pictureBox1.Image = pictureBox6.Image;
            label5.Text = "Длина Ronaldinho 1.81m. Это займет 23205 из них, чтобы покрыть расстояние в 42км марафона";
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            label4.Text = label10.Text;
            pictureBox1.Image = pictureBox6.Image;
            label5.Text = "Длина Ronaldinho 1.81m. Это займет 23205 из них, чтобы покрыть расстояние в 42км марафона";
        }
    }
}
