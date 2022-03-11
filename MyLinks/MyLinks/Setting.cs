using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLinks
{
    public partial class Setting : Form
    {
        readonly FormMain f1;
        readonly int i;
        readonly string lnkname = "MyLink.lnk";
        readonly string link;
        public Setting(FormMain form1, int i1)
        {
            InitializeComponent();
            f1 = form1;
            i = i1;
            TopMost = f1.TopMost;
            checkBoxHideStart.Checked = f1.hideStart;
            checkBoxHideRun.Checked = f1.hideRun;
            checkBoxTopmost.Checked = f1.TopMost;
            checkBoxNotExit.Checked = f1.notexit;
            textBoxTitle.Text = f1.Text;
            if (f1.Visible)
            {
                int x, y;
                x = f1.Location.X + (f1.Width / 2) - (Width / 2);
                y = f1.Location.Y + (f1.Height / 2) - (Height / 2);
                Location = new Point(x, y);
                StartPosition = FormStartPosition.Manual;
            }
            link = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + lnkname;
            checkBoxAutoStart.Checked = System.IO.File.Exists(link);
        }

        private void CheckBoxHideStart_CheckedChanged(object sender, EventArgs e) => f1.hideStart = checkBoxHideStart.Checked;
        private void CheckBoxHideRun_CheckedChanged(object sender, EventArgs e) => f1.hideRun = checkBoxHideRun.Checked;
        private void CheckBoxTopmost_CheckedChanged(object sender, EventArgs e) => f1.TopMost = checkBoxTopmost.Checked;
        private void CheckBoxNotExit_CheckedChanged(object sender, EventArgs e) => f1.notexit = checkBoxNotExit.Checked;
        private void TextBoxTitle_TextChanged(object sender, EventArgs e) => f1.Text = textBoxTitle.Text;
        private void CheckBoxAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxAutoStart.Checked)
                {
                    var shellType = Type.GetTypeFromProgID("WScript.Shell");
                    dynamic shell = Activator.CreateInstance(shellType);
                    var shortcut = shell.CreateShortcut(link);
                    shortcut.TargetPath = Application.ExecutablePath;
                    //shortcut.Arguments = args;
                    shortcut.WorkingDirectory = Application.StartupPath;
                    shortcut.Save();
                }
                else
                {
                    System.IO.File.Delete(link);
                }
            }
            catch { }
        }
    }
}
