using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyLinks
{
    public partial class FormMain : Form
    {
        public List<FileInfoList> fileLists = new List<FileInfoList>();
        readonly string cfgFile = "MyLinks.xml";
        public List<string> backimage = new List<string>();
        public bool notexit;
        private bool goexit = false;
        public bool hideStart;
        public bool hideRun;
        public List<ListView> listViews = new List<ListView>();
        public TabControl tabControl;
        public FormMain()
        {
            InitializeComponent();
            FormClosing += FormMain_FormClosing;
            Load += FormMain_Load;
            MouseDown += FormMain_MouseDown;
            tabControl = new TabControl();
            tabControl.Alignment = TabAlignment.Bottom;
            tabControl.ContextMenuStrip = contextMenuStripMain;
            tabControl.Dock = DockStyle.Fill;
            tabControl.ItemSize = new Size(48, 16);
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(0);
            tabControl.Padding = new Point(0, 0);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(660, 427);
            Controls.Add(tabControl);
            ReadCfg();
            notifyIcon.Text = Text;
        }

        private void AddTab(string tabname)
        {
            backimage.Add("");
            FileInfoList fileInfoList = new FileInfoList(new string[] { });
            fileLists.Add(fileInfoList);
            ListView listView = new ListView();
            listView.AllowDrop = true;
            listView.BorderStyle = BorderStyle.None;
            listView.ContextMenuStrip = contextMenuStripMain;
            listView.Dock = DockStyle.Fill;
            listView.HideSelection = false;
            listView.Location = new Point(0, 0);
            listView.Margin = new Padding(0);
            listView.Size = new Size(652, 403);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.DragDrop += ListViews_DragDrop;
            listView.DragEnter += ListViews_DragEnter;
            listView.MouseClick += ListViews_MouseClick;
            listView.Columns.Add("名称", 100, HorizontalAlignment.Left);
            listView.Columns.Add("时间", 100, HorizontalAlignment.Left);
            listView.Columns.Add("类型", 60, HorizontalAlignment.Left);
            listView.Columns.Add("大小", 80, HorizontalAlignment.Left);
            listView.Columns.Add("参数", 100, HorizontalAlignment.Left);
            listView.Columns.Add("路径", 210, HorizontalAlignment.Left);
            listViews.Add(listView);
            TabPage tabPage = new TabPage();
            tabPage.Controls.Add(listView);
            tabPage.Location = new Point(4, 4);
            tabPage.Margin = new Padding(0);
            tabPage.Size = new Size(652, 403);
            tabPage.TabIndex = 0;
            tabPage.Text = tabname;
            tabPage.UseVisualStyleBackColor = true;
            tabControl.TabPages.Add(tabPage);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x0112, 0xF010 + 0x0002, 0);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (hideStart)
            {
                BeginInvoke(new System.Threading.ThreadStart(Hide));
            }
        }

        private void ListViews_MouseClick(object sender, MouseEventArgs e)
        {
            int i1 = tabControl.SelectedIndex;
            if (e.Button == MouseButtons.Left && listViews[i1].SelectedItems.Count == 1)
            {
                int i = listViews[i1].SelectedItems[0].Index;
                string path = fileLists[i1].list[i].fileInfo.FullName;
                string arg = fileLists[i1].list[i].Arg;
                try
                {
                    RunIcon(path, arg, fileLists[i1].list[i].RunAsA);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }
                if (hideRun)
                {
                    Hide();
                }
            }
        }

        private void RunIcon(string path, string arg, bool runas)
        {
            string dir = System.IO.Path.GetDirectoryName(path);
            if (path.Contains(" "))
            {
                path = "\"" + path + "\"";
            }
            using (System.Diagnostics.Process p = new System.Diagnostics.Process())
            {
                if (runas)
                {
                    p.StartInfo.Verb = "runas";
                }
                p.StartInfo.UseShellExecute = true;
                p.StartInfo.FileName = path;
                p.StartInfo.Arguments = arg;
                p.StartInfo.WorkingDirectory = dir;
                p.Start();
                p.Close();
            }
        }

        #region CFG
        private void WriteCfg()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);
            XmlElement cfg = doc.CreateElement("Config");
            doc.AppendChild(cfg);
            XmlElement set = doc.CreateElement("Setting");
            cfg.AppendChild(set);
            XmlElement h = doc.CreateElement("Height");
            h.InnerText = Height.ToString();
            set.AppendChild(h);
            XmlElement w = doc.CreateElement("Width");
            w.InnerText = Width.ToString();
            set.AppendChild(w);
            XmlElement lx = doc.CreateElement("LocationX");
            lx.InnerText = Location.X.ToString();
            set.AppendChild(lx);
            XmlElement ly = doc.CreateElement("LocationY");
            ly.InnerText = Location.Y.ToString();
            set.AppendChild(ly);
            XmlElement hide = doc.CreateElement("HideStart");
            hide.InnerText = hideStart.ToString();
            set.AppendChild(hide);
            XmlElement hrun = doc.CreateElement("HideRun");
            hrun.InnerText = hideRun.ToString();
            set.AppendChild(hrun);
            XmlElement topmost = doc.CreateElement("TopMost");
            topmost.InnerText = TopMost.ToString();
            set.AppendChild(topmost);
            XmlElement noex = doc.CreateElement("NotExit");
            noex.InnerText = notexit.ToString();
            set.AppendChild(noex);
            XmlElement title = doc.CreateElement("Title");
            title.InnerText = Text;
            set.AppendChild(title);
            XmlElement tbindex = doc.CreateElement("TableIndex");
            tbindex.InnerText = tabControl.SelectedIndex.ToString();
            set.AppendChild(tbindex);
            XmlElement datas = doc.CreateElement("Datas");
            cfg.AppendChild(datas);
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                XmlElement tbnane = doc.CreateElement($"Name");
                tbnane.InnerText = tabControl.TabPages[i].Text;
                XmlElement bk = doc.CreateElement($"BackImage");
                bk.SetAttribute("On", (listViews[i].BackgroundImage != null).ToString());
                bk.SetAttribute("Tiled", listViews[i].BackgroundImageTiled.ToString());
                bk.InnerText = backimage[i];
                XmlElement fcolor = doc.CreateElement($"ListForeColor");
                fcolor.InnerText = listViews[i].ForeColor.ToArgb().ToString();
                XmlElement tab = doc.CreateElement($"Table");
                tab.AppendChild(tbnane);
                tab.AppendChild(bk);
                tab.AppendChild(fcolor);
                foreach (FileInfoWithIcon item in fileLists[i].list)
                {
                    XmlElement data = doc.CreateElement("Data");
                    XmlElement name = doc.CreateElement("Name");
                    name.InnerText = item.Name;
                    XmlElement fullpath = doc.CreateElement("FullPath");
                    fullpath.InnerText = item.fileInfo.FullName;
                    XmlElement arg = doc.CreateElement("Args");
                    arg.InnerText = item.Arg;
                    XmlElement runas = doc.CreateElement("RunAs");
                    runas.InnerText = item.RunAsA.ToString();
                    data.AppendChild(name);
                    data.AppendChild(fullpath);
                    data.AppendChild(arg);
                    data.AppendChild(runas);
                    tab.AppendChild(data);
                }
                datas.AppendChild(tab);
            }
            doc.Save(cfgFile);
        }

        private void ReadCfg()
        {
            if (!System.IO.File.Exists(cfgFile))
            {
                return;
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(cfgFile);
                Height = int.Parse(doc.SelectSingleNode("Config/Setting/Height").InnerText);
                Width = int.Parse(doc.SelectSingleNode("Config/Setting/Width").InnerText);
                int lx = int.Parse(doc.SelectSingleNode("Config/Setting/LocationX").InnerText);
                int ly = int.Parse(doc.SelectSingleNode("Config/Setting/LocationY").InnerText);
                hideStart = bool.Parse(doc.SelectSingleNode("Config/Setting/HideStart").InnerText);
                hideRun = bool.Parse(doc.SelectSingleNode("Config/Setting/HideRun").InnerText);
                TopMost = bool.Parse(doc.SelectSingleNode("Config/Setting/TopMost").InnerText);
                notexit = bool.Parse(doc.SelectSingleNode("Config/Setting/NotExit").InnerText);
                Text = doc.SelectSingleNode("Config/Setting/Title").InnerText;
                tabControl.SelectedIndex = int.Parse(doc.SelectSingleNode("Config/Setting/TableIndex").InnerText);
                if (lx < 0)
                {
                    lx = 0;
                }
                if (ly < 0)
                {
                    ly = 0;
                }
                Location = new Point(lx, ly);
                XmlNodeList tabs = doc.SelectNodes($"Config/Datas/Table");
                for (int i = 0; i < tabs.Count; i++)
                {
                    AddTab(tabs[i].SelectSingleNode("Name").InnerText);
                    backimage[i] = tabs[i].SelectSingleNode("BackImage").InnerText;
                    if (bool.Parse(tabs[i].SelectSingleNode($"BackImage").Attributes["On"].Value))
                    {
                        if (System.IO.File.Exists(backimage[i]))
                        {
                            listViews[i].BackgroundImage = Image.FromFile(backimage[i]);
                        }
                    }
                    listViews[i].BackgroundImageTiled = bool.Parse(tabs[i].SelectSingleNode("BackImage").Attributes["Tiled"].Value);
                    listViews[i].ForeColor = Color.FromArgb(int.Parse(tabs[i].SelectSingleNode("ListForeColor").InnerText));
                    XmlNodeList items = tabs[i].SelectNodes("Data");
                    foreach (XmlNode item in items)
                    {
                        string name = item.SelectSingleNode("Name").InnerText;
                        string fullpath = item.SelectSingleNode("FullPath").InnerText;
                        string args = item.SelectSingleNode("Args").InnerText;
                        bool runas = bool.Parse(item.SelectSingleNode("RunAs").InnerText);
                        fileLists[i].AddFile(fullpath);
                        fileLists[i].list[fileLists[i].list.Count - 1].Name = name;
                        fileLists[i].list[fileLists[i].list.Count - 1].Arg = args;
                        fileLists[i].list[fileLists[i].list.Count - 1].RunAsA = runas;
                    }
                    InitListView(i);
                }
                tabControl.SelectedIndex = int.Parse(doc.SelectSingleNode("Config/Setting/TableIndex").InnerText);
            }
            catch (Exception)
            { }
        }
        #endregion

        private void ListViews_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            AddFiles(files);
        }

        private void ListViews_DragEnter(object sender, DragEventArgs e) => e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;

        private void AddFiles(string[] files)
        {
            int i = tabControl.SelectedIndex;
            foreach (string item in files)
            {
                if (item.ToLower().EndsWith(".lnk"))
                {
                    AddLink(item);
                }
                else
                {
                    fileLists[i].AddFile(item);
                }
            }
            InitListView(i);
            WriteCfg();
        }

        private void InitListView(int i)
        {
            listViews[i].BeginUpdate();
            listViews[i].Items.Clear();
            foreach (FileInfoWithIcon file in fileLists[i].list)
            {
                ListViewItem item = new ListViewItem
                {
                    Text = file.Name,
                    ImageIndex = file.iconIndex
                };
                item.SubItems.Add(file.fileInfo.LastWriteTime.ToString());
                item.SubItems.Add(file.tp);
                try
                {
                    item.SubItems.Add(string.Format(("{0:N0}"), file.fileInfo.Length));
                }
                catch (Exception)
                {
                    item.SubItems.Add("");
                }
                item.SubItems.Add(file.Arg);
                item.SubItems.Add(file.fileInfo.FullName);
                listViews[i].Items.Add(item);
            }
            listViews[i].LargeImageList = fileLists[i].imageListLargeIcon;
            listViews[i].SmallImageList = fileLists[i].imageListSmallIcon;
            listViews[i].Show();
            listViews[i].EndUpdate();
        }

        private void AddLink(string item)
        {
            int i = tabControl.SelectedIndex;
            var shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);
            var shortcut = shell.CreateShortcut(item);
            fileLists[i].AddFile(shortcut.TargetPath);
            string fn = System.IO.Path.GetFileName(item);
            string lname = fn.Substring(0, fn.LastIndexOf("."));
            fileLists[i].list[fileLists[i].list.Count - 1].Name = lname;
            fileLists[i].list[fileLists[i].list.Count - 1].Arg = shortcut.Arguments;
            //WorkDir = shortcut.WorkingDirectory;
        }

        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                Activate();
            }
        }
        #region MENU
        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.LargeIcon;
        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.SmallIcon;
        private void 详细ToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.Details;
        private void 列表ToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.List;
        private void 平铺ToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.Tile;
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddFiles(openFileDialog.FileNames);
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            if (listViews[i].SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "确定要删除选择的项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
                int j = listViews[i].SelectedItems[0].Index;
                for (int i1 = 0; i1 < ((System.Collections.IList)listViews[i].SelectedItems).Count; i1++)
                {
                    fileLists[i].RemoveFileAt(j);
                }
                InitListView(i);
                if (j < listViews[i].Items.Count)
                {
                    listViews[i].Items[j].Selected = true;
                }
                else if (listViews[i].Items.Count > 0)
                {
                    listViews[i].Items[j - 1].Selected = true;
                }
                WriteCfg();
            }
        }

        private void 查看文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViews[tabControl.SelectedIndex].SelectedItems.Count > 0)
            {
                int i = listViews[tabControl.SelectedIndex].SelectedItems[0].Index;
                string ffull = "\"" + fileLists[tabControl.SelectedIndex].list[i].fileInfo.FullName + "\"";
                using (System.Diagnostics.Process p = new System.Diagnostics.Process())
                {
                    p.StartInfo.FileName = "Explorer.exe";
                    p.StartInfo.Arguments = "/e,/select," + ffull;
                    p.Start();
                    p.Close();
                }
            }
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileLists[tabControl.SelectedIndex].list.Count >= 1 && MessageBox.Show(this, "确定要删除所有项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                fileLists[tabControl.SelectedIndex].RemoveAll();
                InitListView(tabControl.SelectedIndex);
                WriteCfg();
            }
        }

        private void 管理员方式运行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i1 = tabControl.SelectedIndex;
            if (listViews[i1].SelectedItems.Count == 1)
            {
                int i = listViews[i1].SelectedItems[0].Index;
                string path = fileLists[i1].list[i].fileInfo.FullName;
                string arg = fileLists[i1].list[i].Arg;
                try
                {
                    RunIcon(path, arg, true);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    return;
                }
                if (hideRun)
                {
                    Hide();
                }
            }
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i1 = tabControl.SelectedIndex;
            if (listViews[i1].SelectedItems.Count > 0)
            {
                int i = listViews[i1].SelectedItems[0].Index;
                FileName f1 = new FileName(fileLists[i1].list[i].fileInfo.FullName)
                {
                    Name = listViews[i1].SelectedItems[0].Text,
                    Args = fileLists[i1].list[i].Arg,
                    RunAsA = fileLists[i1].list[i].RunAsA
                };
                using (EditIco editIco = new EditIco(f1, TopMost))
                {
                    if (editIco.ShowDialog() == DialogResult.OK)
                    {
                        if (fileLists[i1].list[i].fileInfo.FullName != editIco.f.Path)
                        {
                            fileLists[i1].list[i] = new FileInfoWithIcon(editIco.f.Path);
                            fileLists[i1].imageListLargeIcon.Images[i] = fileLists[i1].list[i].largeIcon.ToBitmap();
                            fileLists[i1].imageListSmallIcon.Images[i] = fileLists[i1].list[i].smallIcon.ToBitmap();
                        }
                        fileLists[i1].list[i].Arg = editIco.f.Args;
                        fileLists[i1].list[i].Name = editIco.f.Name;
                        fileLists[i1].list[i].RunAsA = editIco.f.RunAsA;
                        InitListView(i1);
                        WriteCfg();
                    }
                }
            }
        }

        private void 修改本栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditTab editTab = new EditTab(this, tabControl.SelectedIndex))
            {
                editTab.ShowDialog();
            }
            InitListView(tabControl.SelectedIndex);
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Setting setting = new Setting(this, tabControl.SelectedIndex))
            {
                setting.ShowDialog();
            }
            WriteCfg();
            notifyIcon.Text = Text;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goexit = true;
            Close();
        }
        #endregion
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!notexit || goexit)
            { WriteCfg(); }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ContextMenuStripMain_Opening(object sender, CancelEventArgs e)
        {
            bool b = listViews.Count > 0 && listViews[tabControl.SelectedIndex].SelectedItems.Count > 0;
            管理员方式运行ToolStripMenuItem.Visible = b;
            删除ToolStripMenuItem.Visible = b;
            查看文件ToolStripMenuItem.Visible = b;
            编辑ToolStripMenuItem.Visible = b;
            刪除栏ToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
            查看ToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
            添加ToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
            清空ToolStripMenuItem.Visible = tabControl.TabPages.Count > 0 && listViews[tabControl.SelectedIndex].Items.Count > 0; ;
            修改本栏ToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
        }

        private void 添加栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NameTab nameTab = new NameTab(null))
            {
                nameTab.TopMost = TopMost;
                if (nameTab.ShowDialog() == DialogResult.OK)
                {
                    AddTab(nameTab.name);
                    tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                }
            }
        }

        private void 刪除栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex > -1 && MessageBox.Show(this, "确定要删除选择的项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                RemoveTab(tabControl.SelectedIndex);
            }
        }

        private void RemoveTab(int i)
        {
            backimage.RemoveAt(i);
            fileLists.RemoveAt(i);
            listViews.RemoveAt(i);
            tabControl.TabPages.RemoveAt(i);
        }
    }

    public class FileName
    {
        public FileName(string filename)
        {
            Path = filename;
            Args = "";
            RunAsA = false;
        }

        public string Name { get; set; }
        public string Path { set; get; }
        public string Args { set; get; }
        public bool RunAsA { set; get; }
    }
}
