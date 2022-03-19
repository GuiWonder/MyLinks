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
    public partial class EditTab : Form
    {
        readonly FormMain f1;
        readonly int i;
        public EditTab(FormMain form1, int i1)
        {
            InitializeComponent();
            f1 = form1;
            i = i1;
            if (f1.listViews[i].BackgroundImage != null)
            {
                checkBoxBG.Checked = true;
            }
            TopMost = f1.TopMost;
            textBoxImg.Text = f1.backimages[i];
            checkBoxTiled.Checked = f1.listViews[i].BackgroundImageTiled;
            textBoxImg.Enabled = checkBoxBG.Checked;
            checkBoxTiled.Enabled = checkBoxBG.Checked;
            linkLabelBKImage.Enabled = checkBoxBG.Checked;
            textBoxTitle.Text = f1.tabControl.TabPages[i].Text;
            pictureBoxFore.BackColor = f1.listViews[i].ForeColor;
            pictureBoxBack.BackColor = f1.listViews[i].BackColor;
        }

        private void TextBoxTitle_TextChanged(object sender, EventArgs e)
        {
            f1.tabControl.TabPages[i].Text = textBoxTitle.Text;
            f1.buttons[i].Text = textBoxTitle.Text;
        }

        private void CheckBoxBG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBG.Checked)
            {
                if (System.IO.File.Exists(textBoxImg.Text))
                {
                    try
                    {
                        SetBKImage(textBoxImg.Text);
                    }
                    catch (Exception)
                    { }
                }
            }
            else
            {
                f1.listViews[i].BackgroundImage = null;
            }
            textBoxImg.Enabled = checkBoxBG.Checked;
            checkBoxTiled.Enabled = checkBoxBG.Checked;
            linkLabelBKImage.Enabled = checkBoxBG.Checked;
        }

        private void LinkLabelBKImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.wmf|所有文件|*",
                Multiselect = false
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxImg.Text = openFileDialog.FileName;
                    SetBKImage(openFileDialog.FileName);
                }
            }
        }

        private void TextBoxImg_DragDrop(object sender, DragEventArgs e)
        {
            ((TextBox)sender).Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            SetBKImage(((TextBox)sender).Text);
        }

        private void TextBoxImg_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;

        private void TextBoxImg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (!string.IsNullOrWhiteSpace(textBoxImg.Text))
                {
                    if (System.IO.File.Exists(textBoxImg.Text.Trim()))
                    {
                        SetBKImage(textBoxImg.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show(this, "文件读取不存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                e.Handled = true;
            }
        }

        private void SetBKImage(string imgfile)
        {
            try
            {
                using (Image image = Image.FromFile(imgfile))
                {
                    f1.listViews[i].BackgroundImage = image;
                }
                f1.backimages[i] = imgfile;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "文件读取错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckBoxTiled_CheckedChanged(object sender, EventArgs e) => f1.listViews[i].BackgroundImageTiled = checkBoxTiled.Checked;

        private void PictureBoxFore_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFore.BackColor = colorDialog.Color;
                    f1.listViews[i].ForeColor = colorDialog.Color;
                }
            }
        }

        private void PictureBoxBack_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxBack.BackColor = colorDialog.Color;
                    f1.listViews[i].BackColor = colorDialog.Color;
                }
            }
        }
    }
}
