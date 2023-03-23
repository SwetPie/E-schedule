using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace E_schedule
{
    public partial class Form1 : Form
    {
        Dictionary<string, string[][]> Schedule;
        Dictionary<DateTime, string> ScheduleTime;
        Color defaultColor;

        int cellNum = -1;
        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeColor(DataGridViewRow arg, Color clrBack)
        {
            foreach(DataGridViewCell item in arg.Cells)
            {
                item.Style.BackColor=clrBack;
            }
        }
        public void ChangeColor(DataGridViewRow arg, Color clrBack, Color clrText)
        {
            foreach (DataGridViewCell item in arg.Cells)
            {
                item.Style.BackColor = clrBack;
                item.Style.ForeColor = clrText;
            }
        }
        public void FlashLesson()
        {
            try
            {
                ChangeColor(dataGridView1.Rows[cellNum], Color.LightGreen);
            }catch
            {
                ChangeColor(dataGridView1.Rows[0] , Color.LightGreen);
            }
        }
        public void ReturnColor(DataGridViewRow arg)
        {
            foreach(DataGridViewCell item in arg.Cells)
            {
                item.Style.BackColor = Color.White;
                item.Style.ForeColor = Color.Black;
            }
        }

        public void RefreshLessonNow()
        {
            try
            {
                if (dataGridView1[0, cellNum].Value.ToString() != "")
                {
                    FormSettings.LessonNow = $"{dataGridView1[0, cellNum].Value}. {dataGridView1[1, cellNum].Value}";
                }
                else
                {
                    FormSettings.LessonNow = $"{dataGridView1[1, cellNum].Value}";
                }
            }
            catch
            {
                FormSettings.LessonNow = $"Уроки не начались";
            }
        }

        public void ShowBreaks()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (((string)row.Cells[1].Value == "Большая перемена") || ((string)row.Cells[1].Value == "Перемена"))
                {
                    row.Visible = FormSettings.ShowBreaks;
                }
            }
        }

        public void ShowScheduleToday()
        {

            dataGridView1.Rows.Clear();
            foreach (var dic in Schedule)
            {
                if (dic.Key.ToUpper() == DateTime.Now.DayOfWeek.ToString().ToUpper())
                {
                    switch (dic.Key)
                    {
                        case "Monday":
                            label1.Text = "Понедельник";
                            break;
                        case "Tuesday":
                            label1.Text = "Вторник";
                            break;
                        case "Wednesday":
                            label1.Text = "Среда";
                            break;
                        case "Thursday":
                            label1.Text = "Четверг";
                            break;
                        case "Friday":
                            label1.Text = "Пятница";
                            break;
                        default:
                            label1.Text = "Выходные";
                            break;
                    }
                    foreach (var item in dic.Value)
                    {
                        dataGridView1.Rows.Add(item);
                    }

                }
            }

            cellNum = -1;
            var now = DateTime.Now;
            foreach (var item in ScheduleTime)
            {
                if (((now.Hour == item.Key.Hour) && (now.Minute > item.Key.Minute)) || now.Hour > item.Key.Hour)
                {
                    cellNum++;
                    label2.Text = item.Value;
                }
            }
            FlashLesson();
            ShowBreaks();
        }
        public void ShowScheduleAll()
        {
            int startNum = 1;
            label1.Text = "Вся неделя";
            dataGridView1.Rows.Clear();
            foreach (var dic in Schedule)
            {
                switch (dic.Key)
                {
                    case "Monday":
                        dataGridView1.Rows.Add("","Понедельник");
                        break;
                    case "Tuesday":
                        dataGridView1.Rows.Add("","Вторник");
                        break;
                    case "Wednesday":
                        dataGridView1.Rows.Add("","Среда");
                        break;
                    case "Thursday":
                        dataGridView1.Rows.Add("","Четверг");
                        break;
                    case "Friday":
                        dataGridView1.Rows.Add("","Пятница");
                        break;
                    default:
                        break;
                }

                foreach (var item in dic.Value)
                {
                    dataGridView1.Rows.Add(item);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                ChangeColor(dataGridView1.Rows[ i * 16], Color.Gray);
            }
            foreach (var item in Schedule.Keys)
            {
                if (item.ToUpper() == DateTime.Today.DayOfWeek.ToString().ToUpper())
                {
                    cellNum += startNum;
                    FlashLesson();
                }
                else
                {
                    startNum += 16;
                }
            }
            ShowBreaks();
        }

        public void TimeToRing()
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = TimeSpan.Zero;
            foreach (var item in ScheduleTime)
            {
                if (((now.Hour == item.Key.Hour) && (now.Minute > item.Key.Minute)) || now.Hour > item.Key.Hour || (now.Hour == item.Key.Hour&& now.Minute == item.Key.Minute )) { }
                else
                {
                    ts = item.Key - now; break;
                }
            }
            label4.Text = $"Осталось:{ts.Minutes}:{ts.Seconds}";
        }
        public void Minimization()
        {
            FormMini formMini = new FormMini();
            
            formMini.Show();

            formMini.Opacity = .85;
            WindowState = FormWindowState.Minimized;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Расписание уроков
            Schedule = FormSettings.Schedule;
            // Расписание звонков
            ScheduleTime = FormSettings.ScheduleTime;

            // Выводим расписание на экран
            ShowScheduleToday();
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width  = 60;

            defaultColor = BackColor;
            RefreshLessonNow();
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            ShowScheduleToday();
        }

        private void неделяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowScheduleAll();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();  
        }

        private void сегодняToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowScheduleToday();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            foreach (var item in ScheduleTime)
                if (now.Hour == item.Key.Hour && now.Minute == item.Key.Minute)
                {
                    ReturnColor(dataGridView1.Rows[cellNum]);
                    timer2.Enabled = true;
                    timer1.Enabled = false;
                    cellNum++;
                    label2.Text = item.Value;
                    RefreshLessonNow();
                    try
                    {
                        FlashLesson();
                    }catch
                    {
                        cellNum--;
                    }
                    if (FormSettings.Sound)
                    {
                        try {
                            SoundPlayer soundPlayer = new SoundPlayer("C:\\Windows\\WinSxS\\amd64_microsoft-windows-shell-sounds_31bf3856ad364e35_10.0.19041.1_none_cd0389b654e71da2\\Alarm03.wav");
                            soundPlayer.Play();
                        }
                        catch {  }
                    }
                    if (FormSettings.Message)
                    {
                        MessageBox.Show(item.Value, "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }

        private void минимизироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Minimization();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            TimeToRing();
        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            BackColor = defaultColor;
            contextMenuStrip1.Items[0].Visible =false;
            contextMenuStrip1.Items[1].Visible = true;
            TopMost = !TopMost;
            tableLayoutPanel1.Visible = !tableLayoutPanel1.Visible;
            menuStrip1.Visible = !menuStrip1.Visible;

            TimeToRing();

            label4.Visible = !label4.Visible;
            timer3.Enabled = !timer3.Enabled;

            label3.Visible = !label3.Visible;
            Size = new Size(800, 640);
            Location = new Point(200,200);*/
        }

        private void минимизироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Minimization();
        }
    }
}
