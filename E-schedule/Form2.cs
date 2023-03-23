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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            checkBoxHideBreaks.Checked = FormSettings.ShowBreaks;
            checkBoxSound.Checked = FormSettings.Sound;
            checkBoxMessage.Checked = FormSettings.Message;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(FormSettings.Language);
            trackBar1.Value = Convert.ToInt32(FormSettings.Opacity * 100);
            label2.Text = trackBar1.Value + "%";
        }

        private void checkBoxSound_CheckedChanged(object sender, EventArgs e)
        {
            FormSettings.Sound = checkBoxSound.Checked;
        }

        private void checkBoxMessage_CheckedChanged(object sender, EventArgs e)
        {
            FormSettings.Message = checkBoxMessage.Checked;
        }

        private void checkBoxHideBreaks_CheckedChanged(object sender, EventArgs e)
        {
            FormSettings.ShowBreaks = checkBoxHideBreaks.Checked;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double op = (double)trackBar1.Value/100;
            label2.Text = $"{trackBar1.Value}%";
            FormSettings.Opacity = op;
        }
    }
}
