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
            checkBoxHideStart.Checked = f1.hideStart;
            checkBoxHideRun.Checked = f1.hideRun;
            checkBoxTopmost.Checked = f1.TopMost;
            checkBoxNotExit.Checked = f1.noexit;
            checkBoxNoReadLnk.Checked = f1.noReadLnk;
            checkBoxUpTab.Checked = f1.tabtop;
            textBoxTitle.Text = f1.Text;
            textBoxBW.Text = f1.tbwidth.ToString();
            textBoxBH.Text = f1.tbheight.ToString();
            if (f1.Visible)
            {
                int x, y;
                x = f1.Location.X + (f1.Width / 2) - (Width / 2);
                y = f1.Location.Y + (f1.Height / 2) - (Height / 2);
                Location = new Point(x, y);
                StartPosition = FormStartPosition.Manual;
            }
            checkBoxAutoStart.Click += CheckBoxAutoStart_Click;
            FormClosing += Setting_FormClosing;
            checkBoxAutoStart.Checked = IsAutoStart(null);
        }

        private bool IsAutoStart(bool? isOn)
        {
            string appPath = Application.ExecutablePath;
            string appName = Application.ProductName;
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
        }
        private void CheckBoxHideStart_CheckedChanged(object sender, EventArgs e) => f1.hideStart = checkBoxHideStart.Checked;
        private void CheckBoxHideRun_CheckedChanged(object sender, EventArgs e) => f1.hideRun = checkBoxHideRun.Checked;
        private void CheckBoxTopmost_CheckedChanged(object sender, EventArgs e) => f1.TopMost = checkBoxTopmost.Checked;
        private void CheckBoxNotExit_CheckedChanged(object sender, EventArgs e) => f1.noexit = checkBoxNotExit.Checked;
        private void TextBoxTitle_TextChanged(object sender, EventArgs e) => f1.Text = textBoxTitle.Text;
        private void CheckBoxNoReadLnk_CheckedChanged(object sender, EventArgs e) => f1.noReadLnk = checkBoxNoReadLnk.Checked;
        private void CheckBoxUpTab_CheckedChanged(object sender, EventArgs e)
        {
            f1.tabtop = checkBoxUpTab.Checked;
            if (f1.tabtop)
            {
                f1.tabControl.Location = new Point(-4, f1.tbheight - 4);
                f1.panel1.Dock = DockStyle.Top;
            }
            else
            {
                f1.tabControl.Location = new Point(-4, -4);
                f1.panel1.Dock = DockStyle.Bottom;
            }
        }
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
    }
}
