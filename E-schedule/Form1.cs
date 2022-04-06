using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_schedule
{
    public partial class Form1 : Form
    {
        Dictionary<string, string[][]> Schedule;
        Dictionary<DateTime, string> ScheduleTime;
        
        int cellNum = -1;
        public Form1()
        {
            InitializeComponent();
        }

        public void ChangeColor(DataGridViewCell arg, Color clr , Color clrText)
        {
            arg.Style.BackColor = clr;
            arg.Style.ForeColor = clrText;
        }
        public void ChangeColor(DataGridViewCell arg, Color clr)
        {
            arg.Style.BackColor = clr;
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
            ChangeColor(dataGridView1.Rows[cellNum], Color.LightGreen);
        }
        public void ReturnColor(DataGridViewCell arg)
        {
            arg.Style.BackColor = Color.White;
            arg.Style.ForeColor = Color.Black;
        }
        public void ReturnColor(DataGridViewRow arg)
        {
            foreach(DataGridViewCell item in arg.Cells)
            {
                item.Style.BackColor = Color.White;
                item.Style.ForeColor = Color.Black;
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

            if (скрытьПеременыToolStripMenuItem.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((string)row.Cells[0].Value == "") && (row.Cells[1].Value != null))
                    {
                        row.Visible = false;
                    }
                }
            }
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
                        dataGridView1.Rows.Add("Понедельник");
                        break;
                    case "Tuesday":
                        dataGridView1.Rows.Add("Вторник");
                        break;
                    case "Wednesday":
                        dataGridView1.Rows.Add("Среда");
                        break;
                    case "Thursday":
                        dataGridView1.Rows.Add("Четверг");
                        break;
                    case "Friday":
                        dataGridView1.Rows.Add("Пятница");
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
                ChangeColor(dataGridView1[0, i * 16], Color.Gray, Color.Black);
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

            if (скрытьПеременыToolStripMenuItem.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((string)row.Cells[0].Value == "") && (row.Cells[1].Value != null))
                    {
                        row.Visible = false;
                    }
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Расписание уроков
            Schedule = new Dictionary<string, string[][]>()
            {
                {
                    "Monday", new string[][]
                    {
                         new string[] {"1","МДК 01 02","08:15 - 08:55","Василий Дмитриевич","№3"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2","МДК 01 02","09:00 - 09:40", "Василий Дмитриевич", "№3"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3","МДК 01 02","09:50 - 10:30","Василий Дмитриевич","№3"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4","МДК 01 02", "10:50 - 11:30","Василий Дмитриевич","№3"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5","МДК 01 02","11:50 - 12:25","Василий Дмитриевич","№3"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6","МДК 01 02", "12:45 - 13:20","Василий Дмитриевич","№3"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7","Англ.яз", "13:30 - 14:05", "Юлия Викторовна","№3"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8","Англ.яз", "14:10 - 14:45", "Юлия Викторовна", "№3"},
                    }
                },
                {
                    "Tuesday", new string[][]
                    {
                         new string[] {"1","Теория Вероятности","08:15 - 08:55","Артём Владиславович","№3"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "Теория Вероятности", "09:00 - 09:40", "Артём Владиславович", "№3"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3","Безопасность Жизнедеятельности","09:50 - 10:30","Сергей Оленеков","№3"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "Безопасность Жизнедеятельности", "10:50 - 11:30", "Сергей Оленеков", "№3"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5","Элементы Высшей Логики","11:50 - 12:25","?","№3"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "Элементы Высшей Логики", "12:45 - 13:20","?","№3"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7","Технические средства", "13:30 - 14:05", "Василий Дмитриевич", "№3"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8","Технические средства", "14:10 - 14:45", "Василий Дмитриевич", "№3"},
                    }
                },
                {
                    "Wednesday", new string[][]
                    {
                         new string[] {"1","Информационный час","08:15 - 08:55","Диана Василевна","№7"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "Элементы Математической Логики", "09:00 - 09:40", "?", "№3"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3", "Элементы Математической Логики", "09:50 - 10:30", "?", "№3"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "Физ-ра", "10:50 - 11:30", "?", "№3"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5","Физ-ра","11:50 - 12:25", "?", "№3"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "МДК 01 01", "12:45 - 13:20", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7", "МДК 01 01", "13:30 - 14:05", "Василий Дмитриевич", "№3"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8", "МДК 01 01", "14:10 - 14:45", "Василий Дмитриевич", "№3"},
                    }
                },
                {
                    "Thursday", new string[][]
                    {
                         new string[] {"1", "Элементы Математической Логики","08:15 - 08:55", "?", "№3"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "Элементы Математической Логики", "09:00 - 09:40", "?", "№3"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3", "Технические средства", "09:50 - 10:30", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "Технические средства", "10:50 - 11:30", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5", "МДК 01 01", "11:50 - 12:25", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "МДК 01 01", "12:45 - 13:20", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7", "МДК 01 01", "13:30 - 14:05", "Василий Дмитриевич", "№3"},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8", "-", "14:10 - 14:45", "", ""},
                    }
                },
                {
                    "Friday", new string[][]
                    {
                         new string[] {"1","Теория Вероятности","08:15 - 08:55", "Артём Владиславович", "№3"},
                         new string[] {"","Перемена", "08:55 - 09:00","",""},
                         new string[] {"2", "МДК 01 02", "09:00 - 09:40", "Василий Дмитриевич", "№3"},
                         new string[] {"","Перемена", "09:40 - 9:50","",""},
                         new string[] {"3", "МДК 01 02", "09:50 - 10:30", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Большая перемена", "10:30 - 10:50","",""},
                         new string[] {"4", "МДК 01 02", "10:50 - 11:30", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Большая перемена", "11:30 - 11:50","",""},
                         new string[] {"5", "МДК 01 02", "11:50 - 12:25", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Большая перемена", "12:25 - 12:45","",""},
                         new string[] {"6", "МДК 01 02", "12:45 - 13:20", "Василий Дмитриевич", "№3"},
                         new string[] {"", "Перемена", "13:20 - 13:30","",""},
                         new string[] {"7", "-", "13:30 - 14:05", "", ""},
                         new string[] {"","Перемена", "14:05 - 14:10","",""},
                         new string[] {"8", "-", "14:10 - 14:45", "", ""},
                    }
                },

            };
            
            // Расписание звонков
            ScheduleTime = new Dictionary<DateTime, string>()
            {
                {DateTime.Parse("8:15"), "1 урок" },
                {DateTime.Parse("8:55"), "Перемена" },
                {DateTime.Parse("9:00"), "2 урок" },
                {DateTime.Parse("9:40"), "Перемена" },
                {DateTime.Parse("9:50"), "3 урок" },
                {DateTime.Parse("10:30"), "Большая перемена" },
                {DateTime.Parse("10:50"), "4 урок" },
                {DateTime.Parse("11:30"), "Большая перемена" },
                {DateTime.Parse("11:50"), "5 урок" },
                {DateTime.Parse("12:25"), "Большая перемена" },
                {DateTime.Parse("12:45"), "6 урок" },
                {DateTime.Parse("13:20"), "Перемена" },
                {DateTime.Parse("13:30"), "7 урок" },
                {DateTime.Parse("14:05"), "Перемена" },
                {DateTime.Parse("14:10"), "8 урок" },
                {DateTime.Parse("14:45"), "Конец учебного дня" },
               
            };

            // Выводим расписание на экран
            ShowScheduleToday();
        }

        private void настройкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
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
                    FlashLesson();

                    MessageBox.Show(item.Value,"Уведомление", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
        }

        private void скрытьПеременыToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if(скрытьПеременыToolStripMenuItem.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (((string)row.Cells[0].Value == "") && (row.Cells[1].Value != null))
                    {
                        row.Visible = false;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;  
                }
            }
        }
    }
}
