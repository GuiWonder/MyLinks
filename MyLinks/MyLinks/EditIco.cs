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
        public EditIco(FileName f1, bool topmost)
        {
            InitializeComponent();
            f = f1;
            TopMost = topmost;
            textBoxName.Text = f.Name;
            textBoxParth.Text = f.Path;
            textBoxArg.Text = f.Args;
            checkBoxRunAs.Checked = f.RunAsA;
        }
        public FileName f;

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            f.Name = textBoxName.Text;
            f.Path = textBoxParth.Text;
            f.Args = textBoxArg.Text;
            f.RunAsA = checkBoxRunAs.Checked;
            DialogResult = DialogResult.OK;
        }

        private void ButtonCanc_Click(object sender, EventArgs e) => Close();

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxParth.Text = openFileDialog.FileName;
            }
        }
    }
}
