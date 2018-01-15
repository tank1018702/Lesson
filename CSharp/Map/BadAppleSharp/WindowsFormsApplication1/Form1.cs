using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static StreamReader reader;
        private void Form1_Load(object sender, EventArgs e)
        {
            reader = new StreamReader("AscPic.txt");
            axWindowsMediaPlayer1.settings.volume = 100;
            axWindowsMediaPlayer1.URL = " BadApple.mp3";
            timer1.Enabled = true;
        }
        int num = 0;
        string xinde = "W";
        string jiude = "W";
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            num++;
            this.progressBar1.Value = num;
            label2.Text = "第" + num.ToString()+"帧\r\n播放时间:"+axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            if (num < 50)
            {
                return;
            }
            else if(num==800) 
            {
                timer1.Interval = 33;
            }else if(num==1000)
            {
                timer1.Interval = 32;
            }else if(num==1500)
            {
                timer1.Interval = 31;
            }
            StringBuilder data = new StringBuilder(2500);
            for (int i = 0; i < 61; i++)
            {
                data.Append(reader.ReadLine()+"\r\n");
            }
            label1.Text = data.ToString().Replace(jiude, xinde);
            if (checkBox1.Checked)
            {
                label1.ForeColor = GetRomColor();
            }
        }
        bool a = true;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString()==" ")
            {
                if (a)
                {
                    timer1.Enabled = false;
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    a = false;
                }
                else 
                {
                    timer1.Enabled = true;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    a = true;
                }

            }
        }
        private Color GetRomColor() 
        {
            Random suiji = new Random(Guid.NewGuid().GetHashCode());
            return  Color.FromArgb(suiji.Next(0, 254), suiji.Next(0, 254), suiji.Next(0, 254));
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.BackColor = Color.Pink;
                this.label1.BackColor = Color.Pink;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                progressBar1.Visible = false;
                trackBar1.Visible = false;
            }
            else 
            {
                this.BackColor = Color.Black;
                this.label1.BackColor = Color.Black;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                progressBar1.Visible = true;
                trackBar1.Visible = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.Opacity = (double)this.trackBar1.Value / 100;
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                xinde = textBox1.Text;
            }
        }
    }
}
