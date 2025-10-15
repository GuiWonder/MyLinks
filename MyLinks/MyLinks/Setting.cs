using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyLinks
{
    public partial class Setting : Form
    {
        readonly FormMain f1;
        public Setting(FormMain form1)
        {
            InitializeComponent();
            f1 = form1;
            TopMost = f1.TopMost;
            textBoxTitle.Text = f1.Text;
            checkBoxHideStart.Checked = f1.hideStart;
            checkBoxHideRun.Checked = f1.hideRun;
            checkBoxTopmost.Checked = f1.TopMost;
            checkBoxNotExit.Checked = f1.noexit;
            checkBoxNoReadLnk.Checked = f1.noReadLnk;
            checkBoxDClick.Checked = f1.dClick;
            checkBoxStateBar.Checked = f1.ShowInTaskbar;
            checkBoxFormIcon.Checked = f1.ShowIcon;
            checkBoxAutoStart.Checked = IsAutoStart(null);
            numericUpDownC.Value = f1.columnSpacing;
            numericUpDownL.Value = f1.lineSpacing;
            numericUpDownLabW.Value = f1.tbwidth;
            numericUpDownLabH.Value = f1.tbheight;
            comboBoxTabLoac.SelectedIndex = (int)(f1.panelButton.Dock - 1);
            pictureBoxB1.BackColor = f1.panelButton.BackColor;
            //pictureBoxB1.BackColor = Color.White;
            pictureBoxB2.BackColor = f1.colorB2;
            pictureBoxF1.BackColor = f1.colorF1;
            pictureBoxF2.BackColor = f1.colorF2;
            checkBoxAutoStart.Click += CheckBoxAutoStart_Click;
            checkBoxHideStart.CheckedChanged += CheckBoxHideStart_CheckedChanged;
            checkBoxTopmost.CheckedChanged += CheckBoxTopmost_CheckedChanged;
            checkBoxDClick.CheckedChanged += CheckBoxDClick_CheckedChanged;
            checkBoxHideRun.CheckedChanged += CheckBoxHideRun_CheckedChanged;
            checkBoxNotExit.CheckedChanged += CheckBoxNotExit_CheckedChanged;
            checkBoxNoReadLnk.CheckedChanged += CheckBoxNoReadLnk_CheckedChanged;
            checkBoxFormIcon.CheckedChanged += CheckBoxFormIcon_CheckedChanged;
            comboBoxTabLoac.SelectedIndexChanged += ComboBoxTabLoac_SelectedIndexChanged;
            numericUpDownLabW.ValueChanged += NumericUpDownLab_ValueChanged;
            numericUpDownLabH.ValueChanged += NumericUpDownLab_ValueChanged;
            numericUpDownL.ValueChanged += NumericUpDown_ValueChanged;
            numericUpDownC.ValueChanged += NumericUpDown_ValueChanged;
            FormClosing += Setting_FormClosing;
            checkBoxHotKey.Checked = f1.hotkeyon;
            comboBoxKey1.Text = f1.hotkey1;
            comboBoxKey2.Text = f1.hotkey2;
            comboBoxKey1.Enabled = checkBoxHotKey.Checked;
            comboBoxKey2.Enabled = checkBoxHotKey.Checked;
            checkBoxHotKey.CheckedChanged += CheckBoxHotKey_CheckedChanged;
            linkLabelHome.LinkClicked += (s, e) => System.Diagnostics.Process.Start("https://github.com/GuiWonder/MyLinks");
        }

        private void CheckBoxHotKey_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxKey1.Enabled = checkBoxHotKey.Checked;
            comboBoxKey2.Enabled = checkBoxHotKey.Checked;
        }

        private bool IsAutoStart(bool? isOn)
        {
            string appPath = f1.apppath;
            string appName = f1.appname;
            if (appPath.Contains(" "))
            {
                appPath = $"\"{appPath}\"";
            }
            RegistryKey rgk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)
                ?? Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            if (isOn == true)
            {
                rgk.SetValue(appName, appPath);
            }
            if (isOn == false)
            {
                rgk.DeleteValue(appName, false);
            }
            return rgk.GetValue(appName) != null;
        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.ShowInTaskbar = checkBoxStateBar.Checked;
            f1.hotkeyon = checkBoxHotKey.Checked;
            f1.hotkey1 = comboBoxKey1.Text;
            f1.hotkey2 = comboBoxKey2.Text;
        }
        private void CheckBoxHideStart_CheckedChanged(object sender, EventArgs e) => f1.hideStart = checkBoxHideStart.Checked;
        private void CheckBoxHideRun_CheckedChanged(object sender, EventArgs e) => f1.hideRun = checkBoxHideRun.Checked;
        private void CheckBoxTopmost_CheckedChanged(object sender, EventArgs e) => f1.TopMost = checkBoxTopmost.Checked;
        private void CheckBoxNotExit_CheckedChanged(object sender, EventArgs e) => f1.noexit = checkBoxNotExit.Checked;
        private void TextBoxTitle_TextChanged(object sender, EventArgs e) => f1.Text = textBoxTitle.Text;
        private void CheckBoxNoReadLnk_CheckedChanged(object sender, EventArgs e) => f1.noReadLnk = checkBoxNoReadLnk.Checked;
        private void CheckBoxDClick_CheckedChanged(object sender, EventArgs e) => f1.dClick = checkBoxDClick.Checked;
        private void CheckBoxFormIcon_CheckedChanged(object sender, EventArgs e) => f1.ShowIcon = checkBoxFormIcon.Checked;

        private void CheckBoxAutoStart_Click(object sender, EventArgs e)
        {
            try
            {
                IsAutoStart(checkBoxAutoStart.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ComboBoxTabLoac_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.panelButton.Dock = (DockStyle)(comboBoxTabLoac.SelectedIndex + 1);
            f1.FitButton();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ((PictureBox)sender).BackColor = colorDialog.Color;
                }
            }
            FitColor();
        }

        private void FitColor()
        {
            f1.panelButton.BackColor = pictureBoxB1.BackColor;
            f1.colorB2 = pictureBoxB2.BackColor;
            f1.colorF1 = pictureBoxF1.BackColor;
            f1.colorF2 = pictureBoxF2.BackColor;
            f1.FitButton();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要载入预设值？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                pictureBoxB1.BackColor = Color.White;
                pictureBoxB2.BackColor = Color.LightBlue;
                pictureBoxF1.BackColor = Color.Black;
                pictureBoxF2.BackColor = Color.Black;
                FitColor();
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            f1.columnSpacing = (int)numericUpDownC.Value;
            f1.lineSpacing = (int)numericUpDownL.Value;
            f1.SetIcoSpacing();
        }

        private void NumericUpDownLab_ValueChanged(object sender, EventArgs e)
        {
            f1.tbwidth = (int)numericUpDownLabW.Value;
            f1.tbheight = (int)numericUpDownLabH.Value;
            f1.FitButton();
        }
    }
}
