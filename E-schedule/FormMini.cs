using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace E_schedule
{
    public partial class FormMini : Form
    {
        public FormMini()
        {
            InitializeComponent();
        }
        public void TimeToRing()
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = TimeSpan.Zero;
            string s = "";
            foreach (var item in FormSettings.ScheduleTime)
            {
                if (((now.Hour == item.Key.Hour) && (now.Minute > item.Key.Minute)) || now.Hour > item.Key.Hour || (now.Hour == item.Key.Hour && now.Minute == item.Key.Minute)) { }
                else
                {
                    ts = item.Key - now; break;
                }
            }
            s = $"{ts.Minutes}:";
            if(ts.Seconds <10)
            {
                s += "0";
            }
            s += $"{ts.Seconds}";
            labelTime2.Text = s;
        }
        public void TimeAfterRing()
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = TimeSpan.Zero;
            foreach (var item in FormSettings.ScheduleTime)
            {
                if (now >= item.Key)
                {
                    ts = now - item.Key; 
                }
                else
                {

                }
            }
            labelTime.Text = $"{ts.Minutes}:";
            if (ts.Seconds < 10)
            {
                labelTime.Text += "0";
            }
            labelTime.Text += $"{ts.Seconds}";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (FormSettings.LessonNow.ToUpper() == "БОЛЬШАЯ ПЕРЕМЕНА" || FormSettings.LessonNow.ToUpper() == "ПЕРЕМЕНА")
            {
                label1.Text = " "+FormSettings.LessonNow.ToUpper()+" ";
            }else
            {
                label1.Text =FormSettings.LessonNow.ToUpper();
            }
            TimeToRing();
            TimeAfterRing();
        }

        private void FormMini_Load(object sender, EventArgs e)
        {
            if (FormSettings.LessonNow.ToUpper() == "БОЛЬШАЯ ПЕРЕМЕНА" || FormSettings.LessonNow.ToUpper() == "ПЕРЕМЕНА")
            {
                label1.Text = " "+FormSettings.LessonNow.ToUpper()+" ";
            }
            else
            {
                label1.Text =FormSettings.LessonNow.ToUpper();
            }
            TimeToRing();
            TimeAfterRing();
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Opacity != FormSettings.Opacity)
            {
                Opacity = FormSettings.Opacity;
            }
        }


        private void переключениеФормыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(переключениеФормыToolStripMenuItem.Checked)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.None;
                this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
            }
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        Point lastPoint;
        private void FormMini_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void FormMini_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point (e.X, e.Y);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            FormMini_MouseDown(sender, e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            FormMini_MouseMove(sender, e);
        }
    }
}
