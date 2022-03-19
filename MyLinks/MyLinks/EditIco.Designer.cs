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
    public partial class EditIco : Form
    {
        public EditIco(IcoFileInfo f1, bool topmost)
        {
            InitializeComponent();
            f = f1;
            TopMost = topmost;
            textBoxName.Text = f.Name;
            textBoxParth.Text = f.FullName;
            textBoxArg.Text = f.Args;
            checkBoxRunAs.Checked = f.RunAsA;
        }
        public IcoFileInfo f;

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                MessageBox.Show("请输入名称。");
                return;
            }
            f.Name = textBoxName.Text.Trim();
            f.FullName = textBoxParth.Text.Trim();
            f.Args = textBoxArg.Text.Trim();
            f.RunAsA = checkBoxRunAs.Checked;
            DialogResult = DialogResult.OK;
        }

        private void ButtonCanc_Click(object sender, EventArgs e) => Close();

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxParth.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
