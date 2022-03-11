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
            textBoxImg.Text = f1.backimage[i];
            checkBoxTiled.Checked = f1.listViews[i].BackgroundImageTiled;
            textBoxImg.Enabled = checkBoxBG.Checked;
            checkBoxTiled.Enabled = checkBoxBG.Checked;
            linkLabel1.Enabled = checkBoxBG.Checked;
            textBoxTitle.Text = f1.tabControl.TabPages[i].Text;
            listView.Columns.Add("名称", 100, HorizontalAlignment.Left);
            listView.Columns.Add("路径", 200, HorizontalAlignment.Left);
            listView.Columns.Add("参数", 60, HorizontalAlignment.Left);
            listView.Columns.Add("管理员运行", 60, HorizontalAlignment.Left);

            foreach (FileInfoWithIcon file in f1.fileLists[i].list)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = file.Name
                };
                item.SubItems.Add(file.fileInfo.FullName);
                item.SubItems.Add(file.Arg);
                item.SubItems.Add(file.RunAsA.ToString());
                listView.Items.Add(item);
            }
        }

        private void CheckBoxBG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBG.Checked)
            {
                if (System.IO.File.Exists(textBoxImg.Text))
                {
                    f1.listViews[i].BackgroundImage = Image.FromFile(textBoxImg.Text);
                }
            }
            else
            {
                f1.listViews[i].BackgroundImage = null;
            }

            textBoxImg.Enabled = checkBoxBG.Checked;
            checkBoxTiled.Enabled = checkBoxBG.Checked;
            linkLabel1.Enabled = checkBoxBG.Checked;
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.wmf|所有文件|*",
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                f1.backimage[i] = openFileDialog.FileName;
                textBoxImg.Text = f1.backimage[i];
                Image image = Image.FromFile(f1.backimage[i]);
                f1.listViews[i].BackgroundImage = image;
            }
        }

        private void CheckBoxTiled_CheckedChanged(object sender, EventArgs e) => f1.listViews[i].BackgroundImageTiled = checkBoxTiled.Checked;

        private void TextBoxTitle_TextChanged(object sender, EventArgs e) => f1.tabControl.TabPages[i].Text = textBoxTitle.Text;

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file1 in openFileDialog.FileNames)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = System.IO.Path.GetFileName(file1)
                    };
                    item.SubItems.Add(file1);
                    item.SubItems.Add("");
                    item.SubItems.Add("False");
                    listView.Items.Add(item);
                }
                listView.Items[listView.Items.Count - 1].Selected = true;
            }
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int i = listView.SelectedItems[0].Index;
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    listView.Items.Remove(item);
                }
                if (i < listView.Items.Count)
                {
                    listView.Items[i].Selected = true;
                }
                else if (listView.Items.Count > 0)
                {
                    listView.Items[i - 1].Selected = true;
                }
            }

        }

        private void ButtonInsert_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK && listView.SelectedItems.Count > 0)
            {
                foreach (string file1 in openFileDialog.FileNames)
                {
                    ListViewItem item = new ListViewItem
                    {
                        Text = System.IO.Path.GetFileName(file1)
                    };
                    item.SubItems.Add(file1);
                    item.SubItems.Add("");
                    item.SubItems.Add("False");
                    listView.Items.Insert(listView.SelectedItems[0].Index, item);
                }
            }
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int i = listView.SelectedItems[0].Index;
                if (i > 0)
                {
                    ListViewItem listViewItem = listView.Items[i - 1];
                    listView.Items.RemoveAt(i - 1);
                    listView.Items.Insert(i + listView.SelectedItems.Count - 1, listViewItem);
                }
            }

        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                int i = listView.SelectedItems[0].Index;
                if (i + listView.SelectedItems.Count < listView.Items.Count)
                {
                    ListViewItem listViewItem = listView.Items[i + listView.SelectedItems.Count];
                    listView.Items.RemoveAt(i + listView.SelectedItems.Count);
                    listView.Items.Insert(i, listViewItem);
                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e) => listView.Items.Clear();

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            f1.fileLists[i].RemoveAll();
            foreach (ListViewItem item in listView.Items)
            {
                f1.fileLists[i].AddFile(item.SubItems[1].Text);
                f1.fileLists[i].list[f1.fileLists[i].list.Count - 1].Name = item.Text;
                f1.fileLists[i].list[f1.fileLists[i].list.Count - 1].Arg = item.SubItems[2].Text;
                f1.fileLists[i].list[f1.fileLists[i].list.Count - 1].RunAsA = bool.Parse(item.SubItems[3].Text);
            }
        }
    }
}
