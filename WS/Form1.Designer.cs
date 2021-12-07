namespace WS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonlog = new System.Windows.Forms.Button();
            this.buttoninfo = new System.Windows.Forms.Button();
            this.buttonspon = new System.Windows.Forms.Button();
            this.buttonrun = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonlog);
            this.panel1.Controls.Add(this.buttoninfo);
            this.panel1.Controls.Add(this.buttonspon);
            this.panel1.Controls.Add(this.buttonrun);
            this.panel1.Location = new System.Drawing.Point(0, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 220);
            this.panel1.TabIndex = 0;
            // 
            // buttonlog
            // 
            this.buttonlog.Location = new System.Drawing.Point(586, 184);
            this.buttonlog.Name = "buttonlog";
            this.buttonlog.Size = new System.Drawing.Size(75, 23);
            this.buttonlog.TabIndex = 3;
            this.buttonlog.Text = "Login";
            this.buttonlog.UseVisualStyleBackColor = true;
            this.buttonlog.Click += new System.EventHandler(this.Buttonlog_Click);
            // 
            // buttoninfo
            // 
            this.buttoninfo.Location = new System.Drawing.Point(227, 131);
            this.buttoninfo.Name = "buttoninfo";
            this.buttoninfo.Size = new System.Drawing.Size(223, 34);
            this.buttoninfo.TabIndex = 2;
            this.buttoninfo.Text = "Я хочу узнать больше о событии";
            this.buttoninfo.UseVisualStyleBackColor = true;
            this.buttoninfo.Click += new System.EventHandler(this.Buttoninfo_Click);
            // 
            // buttonspon
            // 
            this.buttonspon.Location = new System.Drawing.Point(227, 75);
            this.buttonspon.Name = "buttonspon";
            this.buttonspon.Size = new System.Drawing.Size(223, 34);
            this.buttonspon.TabIndex = 1;
            this.buttonspon.Text = "Я хочу стать спонсором бегуна";
            this.buttonspon.UseVisualStyleBackColor = true;
            this.buttonspon.Click += new System.EventHandler(this.Buttonspon_Click);
            // 
            // buttonrun
            // 
            this.buttonrun.Location = new System.Drawing.Point(227, 24);
            this.buttonrun.Name = "buttonrun";
            this.buttonrun.Size = new System.Drawing.Size(223, 33);
            this.buttonrun.TabIndex = 0;
            this.buttonrun.Text = "Я хочу стать бегуном";
            this.buttonrun.UseVisualStyleBackColor = true;
            this.buttonrun.Click += new System.EventHandler(this.Buttonrun_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(223, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "MARATHON SKILLS 2021";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(257, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Москва, Россия\r\nсреда 21 октября 2021";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(235, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "0 дней 0 часов до начала марафона";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(673, 386);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Text = "MarathonSkills 2021";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonlog;
        private System.Windows.Forms.Button buttoninfo;
        private System.Windows.Forms.Button buttonspon;
        private System.Windows.Forms.Button buttonrun;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}

