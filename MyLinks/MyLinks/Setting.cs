using Microsoft.Win32;
using System;
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
            checkBoxHideStart.Checked = f1.hideStart;
            checkBoxHideRun.Checked = f1.hideRun;
            checkBoxTopmost.Checked = f1.TopMost;
            checkBoxNotExit.Checked = f1.noexit;
            checkBoxNoReadLnk.Checked = f1.noReadLnk;
            comboBoxTabLoac.SelectedIndex = (int)(f1.panelButton.Dock - 1);
            textBoxTitle.Text = f1.Text;
            checkBoxStateBar.Checked = f1.ShowInTaskbar;
            checkBoxFormIcon.Checked = f1.ShowIcon;
            pictureBoxBack.BackColor = f1.panelButton.BackColor;
            textBoxBW.Text = f1.tbwidth.ToString();
            textBoxBH.Text = f1.tbheight.ToString();
            checkBoxAutoStart.Click += CheckBoxAutoStart_Click;
            FormClosing += Setting_FormClosing;
            checkBoxAutoStart.Checked = IsAutoStart(null);
        }

        private bool IsAutoStart(bool? isOn)
        {
            string appPath = f1.apppath;
            string appName = f1.appname;
            if (appPath.Contains(" "))
            {
                appPath = "\"" + appPath + "\"";
            }
            RegistryKey rgk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rgk == null)
            {
                rgk = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            }
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
            try
            {
                f1.tbwidth = int.Parse(textBoxBW.Text);
                f1.tbheight = int.Parse(textBoxBH.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                e.Cancel = true;
            }
            f1.ShowInTaskbar = checkBoxStateBar.Checked;
        }
        private void CheckBoxHideStart_CheckedChanged(object sender, EventArgs e) => f1.hideStart = checkBoxHideStart.Checked;
        private void CheckBoxHideRun_CheckedChanged(object sender, EventArgs e) => f1.hideRun = checkBoxHideRun.Checked;
        private void CheckBoxTopmost_CheckedChanged(object sender, EventArgs e) => f1.TopMost = checkBoxTopmost.Checked;
        private void CheckBoxNotExit_CheckedChanged(object sender, EventArgs e) => f1.noexit = checkBoxNotExit.Checked;
        private void TextBoxTitle_TextChanged(object sender, EventArgs e) => f1.Text = textBoxTitle.Text;
        private void CheckBoxNoReadLnk_CheckedChanged(object sender, EventArgs e) => f1.noReadLnk = checkBoxNoReadLnk.Checked;
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

        private void CheckBoxFormIcon_CheckedChanged(object sender, EventArgs e)
        {
            f1.ShowIcon = checkBoxFormIcon.Checked;
        }

        private void ComboBoxTabLoac_SelectedIndexChanged(object sender, EventArgs e)
        {
            f1.panelButton.Dock = (DockStyle)(comboBoxTabLoac.SelectedIndex + 1);
            f1.FitButton();
        }

        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxBack.BackColor = colorDialog.Color;
                    f1.panelButton.BackColor = colorDialog.Color;
                }
            }
        }
    }
}
