using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace MyLinks
{
    public partial class FormMain : Form
    {
        public List<string> backimages = new List<string>();
        public List<ListView> listViews = new List<ListView>();
        public List<Button> buttons = new List<Button>();
        public List<ImageList> largeImageLists = new List<ImageList>();
        public List<ImageList> smallImageLists = new List<ImageList>();
        public TabControl tabControl;
        public bool noexit;
        private bool goexit = false;
        public bool hideStart;
        public bool hideRun;
        public bool noReadLnk;
        public bool dClick;
        public int tbwidth;
        public int tbheight;
        public int lineSpacing;
        public int columnSpacing;
        public readonly string apppath;
        public readonly string appname;
        public readonly string appdir;
        private readonly string cfgFile;
        private int width;
        private int height;
        private int locationx;
        private int locationy;
        //public Color colorB1 = Color.White;
        public Color colorF1 = Color.Black;
        public Color colorB2 = Color.LightBlue;
        public Color colorF2 = Color.Black;

        private ListViewItem dragMove;

        public FormMain()
        {
            apppath = Application.ExecutablePath;
            appdir = Application.StartupPath.TrimEnd('\\');
            appname = System.IO.Path.GetFileNameWithoutExtension(apppath);
            cfgFile = appdir + "\\" + appname + ".xml";
            tbwidth = 55;
            tbheight = 23;
            lineSpacing = 75;
            columnSpacing = 75;
            InitializeComponent();
            Load += FormMain_Load;
            FormClosing += FormMain_FormClosing;
            panel1.MouseDown += FormMain_MouseDown;
            panelButton.MouseDown += FormMain_MouseDown;
            Resize += FormMain_Resize;
            LocationChanged += FormMain_LocationChanged;
            tabControl = new TabControl
            {
                Alignment = TabAlignment.Bottom,
                ContextMenuStrip = contextMenuStripMain,
                //tabControl.Dock = DockStyle.Fill;
                ItemSize = new Size(48, 16),
                //Location = new Point(0, 0),
                Margin = new Padding(0),
                Padding = new Point(0, 0)
            };
            panel1.Controls.Add(tabControl);
            ReadCfg();
            notifyIcon.Text = Text;
            //if (tabControl.SelectedIndex > -1)
            //{
            //    buttons[tabControl.SelectedIndex].BackColor = Color.LightBlue;
            //}
            panelButton.Height = tbheight;
            panelButton.Width = tbwidth;
            string icofile = appdir + "\\" + appname + ".ico";
            if (System.IO.File.Exists(icofile))
            {
                try
                {
                    notifyIcon.Icon = new Icon(icofile);
                }
                catch { }
            }
            Icon = notifyIcon.Icon;
            FitButton();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        #region Event
        private void FormMain_Load(object sender, EventArgs e)
        {
            if (hideStart)
            {
                WindowState = FormWindowState.Minimized;
                BeginInvoke(new System.Threading.ThreadStart(Hide));
            }
            if (lineSpacing != 75 || columnSpacing != 75)
                SetIcoSpacing();
        }

        public void SetIcoSpacing()
        {
            foreach (ListView listView in listViews)
            {
                SendMessage(listView.Handle, 0x1035, 0, 0x10000 * columnSpacing + lineSpacing);
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            tabControl.Width = panel1.Width + 8;
            tabControl.Height = panel1.Height + 8 + 16;
            tabControl.Location = new Point(-4, -4);
            if (WindowState == FormWindowState.Normal)
            {
                width = Width;
                height = Height;
            }
            else if (!ShowInTaskbar && WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void FormMain_LocationChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                locationx = Location.X;
                locationy = Location.Y;
            }
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x0112, 0xF010 + 0x0002, 0);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!noexit || goexit)
            {
                WriteCfg();
            }
            else
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ListViews_MouseClick(object sender, MouseEventArgs e)
        {
            if (!dClick && e.Button == MouseButtons.Left && listViews[tabControl.SelectedIndex].SelectedItems.Count == 1)
            {
                RunItem();
            }
        }

        private void RunItem()
        {
            string path = listViews[tabControl.SelectedIndex].SelectedItems[0].SubItems[1].Text;
            string arg = listViews[tabControl.SelectedIndex].SelectedItems[0].SubItems[2].Text;
            bool runas = listViews[tabControl.SelectedIndex].SelectedItems[0].SubItems[3].Text.ToLower() == "true";
            try
            {
                RunIcon(path, arg, runas);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }
            if (hideRun == !(ModifierKeys == Keys.Control))
            {
                Hide();
            }
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            if (dClick)
            {
                RunItem();
            }
        }

        private void ListView_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = ((ListView)sender).PointToClient(MousePosition);
            ListViewItem toitem = ((ListView)sender).GetItemAt(p.X, p.Y);
            if (toitem == null)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x0112, 0xF010 + 0x0002, 0);
            }
        }

        private void ListView_ItemDrag(object sender, ItemDragEventArgs e) => ((ListView)sender).DoDragDrop(e.Item, DragDropEffects.Move);

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            Point p = ((ListView)sender).PointToClient(MousePosition);
            ListViewItem item = ((ListView)sender).GetItemAt(p.X, p.Y);
            if (item != null && item.Selected == false)
            {
                dragMove = item;
            }
        }

        private void ListViews_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (s != null && s.Length > 0)
            {
                AddFiles(s);
            }
            else
            {
                Point p = ((ListView)sender).PointToClient(MousePosition);
                ListViewItem toitem = ((ListView)sender).GetItemAt(p.X, p.Y);
                ListViewItem fritem = ((ListView)sender).SelectedItems[0];
                if (dragMove != null && toitem != null && fritem != toitem)
                {
                    ((ListView)sender).BeginUpdate();
                    if (fritem.Index > toitem.Index)
                    {
                        ((ListView)sender).Items.RemoveAt(fritem.Index);
                        ((ListView)sender).Items.Insert(toitem.Index, fritem);
                    }
                    else if (fritem.Index < toitem.Index)
                    {
                        ((ListView)sender).Items.RemoveAt(fritem.Index);
                        ((ListView)sender).Items.Insert(toitem.Index + 1, fritem);
                    }
                    View view = ((ListView)sender).View;
                    if (view != View.Details && view != View.List)
                    {
                        ((ListView)sender).View = View.Details;
                        ((ListView)sender).View = view;
                    }
                ((ListView)sender).EndUpdate();
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int j = tabControl.SelectedIndex;
            int bi = buttons.IndexOf((Button)sender);
            if (bi != j)
            {
                tabControl.SelectedIndex = bi;
                foreach (Button item in buttons)
                {
                    if (item == sender)
                    {
                        //item.BackColor = Color.LightBlue;
                        item.ForeColor = colorF2;
                        item.BackColor = colorB2;// Color.LightBlue;
                    }
                    else
                    {
                        item.BackColor = Color.Transparent;// Color.White;
                        item.ForeColor = colorF1;
                    }
                    item.FlatAppearance.BorderColor = colorB2;
                }
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
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
        #endregion

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
            XmlElement title = doc.CreateElement("Title");
            title.InnerText = Text;
            set.AppendChild(title);
            XmlElement h = doc.CreateElement("Height");
            h.InnerText = height.ToString();
            set.AppendChild(h);
            XmlElement w = doc.CreateElement("Width");
            w.InnerText = width.ToString();
            set.AppendChild(w);
            XmlElement lx = doc.CreateElement("LocationX");
            lx.InnerText = locationx.ToString();
            set.AppendChild(lx);
            XmlElement ly = doc.CreateElement("LocationY");
            ly.InnerText = locationy.ToString();
            set.AppendChild(ly);
            XmlElement statusBar = doc.CreateElement("StatusBar");
            statusBar.InnerText = ShowInTaskbar.ToString();
            set.AppendChild(statusBar);
            XmlElement showicon = doc.CreateElement("WindowIcon");
            showicon.InnerText = ShowIcon.ToString();
            set.AppendChild(showicon);
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
            noex.InnerText = noexit.ToString();
            set.AppendChild(noex);
            XmlElement nordlnk = doc.CreateElement("NoReadLnk");
            nordlnk.InnerText = noReadLnk.ToString();
            set.AppendChild(nordlnk);
            XmlElement dcl = doc.CreateElement("DoubleClickRun");
            dcl.InnerText = dClick.ToString();
            set.AppendChild(dcl);
            XmlElement lspa = doc.CreateElement("LineSpacing");
            lspa.InnerText = lineSpacing.ToString();
            set.AppendChild(lspa);
            XmlElement cspa = doc.CreateElement("ColumnSpacing");
            cspa.InnerText = columnSpacing.ToString();
            set.AppendChild(cspa);
            XmlElement tbloc = doc.CreateElement("LabelLocation");
            tbloc.InnerText = ((int)panelButton.Dock).ToString();
            set.AppendChild(tbloc);
            XmlElement tbbak1 = doc.CreateElement("LabelBackColor1");
            tbbak1.InnerText = panelButton.BackColor.ToArgb().ToString();
            set.AppendChild(tbbak1);
            XmlElement tbbak2 = doc.CreateElement("LabelBackColor2");
            tbbak2.InnerText = colorB2.ToArgb().ToString();
            set.AppendChild(tbbak2);
            XmlElement tbfore1 = doc.CreateElement("LabelForeColor1");
            tbfore1.InnerText = colorF1.ToArgb().ToString();
            set.AppendChild(tbfore1);
            XmlElement tbfore2 = doc.CreateElement("LabelForeColor2");
            tbfore2.InnerText = colorF2.ToArgb().ToString();
            set.AppendChild(tbfore2);
            XmlElement tbindex = doc.CreateElement("PageIndex");
            tbindex.InnerText = tabControl.SelectedIndex.ToString();
            set.AppendChild(tbindex);
            XmlElement tbw = doc.CreateElement("LabelWidth");
            tbw.InnerText = tbwidth.ToString();
            set.AppendChild(tbw);
            XmlElement tbh = doc.CreateElement("LabelHeight");
            tbh.InnerText = tbheight.ToString();
            set.AppendChild(tbh);
            XmlElement datas = doc.CreateElement("Pages");
            cfg.AppendChild(datas);
            for (int i = 0; i < listViews.Count; i++)
            {
                XmlElement tbnane = doc.CreateElement("Name");
                tbnane.InnerText = buttons[i].Text;
                XmlElement bk = doc.CreateElement("BackImage");
                bk.SetAttribute("On", (listViews[i].BackgroundImage != null).ToString());
                bk.SetAttribute("Tiled", listViews[i].BackgroundImageTiled.ToString());
                bk.InnerText = backimages[i];
                XmlElement fcolor = doc.CreateElement("ListForeColor");
                fcolor.InnerText = listViews[i].ForeColor.ToArgb().ToString();
                XmlElement bcolor = doc.CreateElement("ListBackColor");
                bcolor.InnerText = listViews[i].BackColor.ToArgb().ToString();
                XmlElement tab = doc.CreateElement("Page");
                tab.AppendChild(tbnane);
                tab.AppendChild(bk);
                tab.AppendChild(fcolor);
                tab.AppendChild(bcolor);
                foreach (ListViewItem item in listViews[i].Items)
                {
                    XmlElement data = doc.CreateElement("Data");
                    XmlElement name = doc.CreateElement("Name");
                    name.InnerText = item.Text;
                    XmlElement fullpath = doc.CreateElement("FullPath");
                    fullpath.InnerText = item.SubItems[1].Text;
                    XmlElement arg = doc.CreateElement("Args");
                    arg.InnerText = item.SubItems[2].Text;
                    XmlElement runas = doc.CreateElement("RunAs");
                    runas.InnerText = item.SubItems[3].Text;
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
                LoadDefault();
                return;
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(cfgFile);
                Text = doc.SelectSingleNode("Config/Setting/Title").InnerText;
                Height = int.Parse(doc.SelectSingleNode("Config/Setting/Height").InnerText);
                Width = int.Parse(doc.SelectSingleNode("Config/Setting/Width").InnerText);
                int lx = int.Parse(doc.SelectSingleNode("Config/Setting/LocationX").InnerText);
                ShowInTaskbar = bool.Parse(doc.SelectSingleNode("Config/Setting/StatusBar").InnerText);
                ShowIcon = bool.Parse(doc.SelectSingleNode("Config/Setting/WindowIcon").InnerText);
                int ly = int.Parse(doc.SelectSingleNode("Config/Setting/LocationY").InnerText);
                hideStart = bool.Parse(doc.SelectSingleNode("Config/Setting/HideStart").InnerText);
                hideRun = bool.Parse(doc.SelectSingleNode("Config/Setting/HideRun").InnerText);
                TopMost = bool.Parse(doc.SelectSingleNode("Config/Setting/TopMost").InnerText);
                noexit = bool.Parse(doc.SelectSingleNode("Config/Setting/NotExit").InnerText);
                noReadLnk = bool.Parse(doc.SelectSingleNode("Config/Setting/NoReadLnk").InnerText);
                dClick = bool.Parse(doc.SelectSingleNode("Config/Setting/DoubleClickRun").InnerText);
                lineSpacing = int.Parse(doc.SelectSingleNode("Config/Setting/LineSpacing").InnerText);
                columnSpacing = int.Parse(doc.SelectSingleNode("Config/Setting/ColumnSpacing").InnerText);
                tbwidth = int.Parse(doc.SelectSingleNode("Config/Setting/LabelWidth").InnerText);
                tbheight = int.Parse(doc.SelectSingleNode("Config/Setting/LabelHeight").InnerText);
                if (lx + Width <= 0)
                {
                    lx = 0;
                }
                if (lx >= Screen.PrimaryScreen.Bounds.Width)
                {
                    lx = Screen.PrimaryScreen.Bounds.Width - Width;
                }
                if (ly + Width <= 0)
                {
                    ly = 0;
                }
                if (ly >= Screen.PrimaryScreen.Bounds.Height)
                {
                    ly = Screen.PrimaryScreen.Bounds.Height - Height;
                }
                Location = new Point(lx, ly);
                panelButton.Dock = (DockStyle)int.Parse(doc.SelectSingleNode("Config/Setting/LabelLocation").InnerText);
                panelButton.BackColor = Color.FromArgb(int.Parse(doc.SelectSingleNode("Config/Setting/LabelBackColor1").InnerText));
                colorB2 = Color.FromArgb(int.Parse(doc.SelectSingleNode("Config/Setting/LabelBackColor2").InnerText));
                colorF1 = Color.FromArgb(int.Parse(doc.SelectSingleNode("Config/Setting/LabelForeColor1").InnerText));
                colorF2 = Color.FromArgb(int.Parse(doc.SelectSingleNode("Config/Setting/LabelForeColor2").InnerText));
                using (XmlNodeList tabs = doc.SelectNodes("Config/Pages/Page"))
                {
                    for (int i = 0; i < tabs.Count; i++)
                    {
                        AddPage(tabs[i].SelectSingleNode("Name").InnerText);
                        backimages[i] = tabs[i].SelectSingleNode("BackImage").InnerText;
                        if (bool.Parse(tabs[i].SelectSingleNode("BackImage").Attributes["On"].Value) && System.IO.File.Exists(backimages[i]))
                        {
                            try
                            {
                                listViews[i].BackgroundImage = Image.FromFile(backimages[i]);
                            }
                            catch (Exception)
                            { }
                        }
                        listViews[i].BackgroundImageTiled = bool.Parse(tabs[i].SelectSingleNode("BackImage").Attributes["Tiled"].Value);
                        listViews[i].ForeColor = Color.FromArgb(int.Parse(tabs[i].SelectSingleNode("ListForeColor").InnerText));
                        listViews[i].BackColor = Color.FromArgb(int.Parse(tabs[i].SelectSingleNode("ListBackColor").InnerText));
                        XmlNodeList items = tabs[i].SelectNodes("Data");
                        foreach (XmlNode item in items)
                        {
                            IcoFileInfo icoFileInfo = new IcoFileInfo(item.SelectSingleNode("FullPath").InnerText)
                            {
                                Name = item.SelectSingleNode("Name").InnerText,
                                Args = item.SelectSingleNode("Args").InnerText,
                                RunAsA = item.SelectSingleNode("RunAs").InnerText.ToLower() == "true"
                            };
                            AddFile(icoFileInfo, i);
                        }
                    }
                }
                tabControl.SelectedIndex = int.Parse(doc.SelectSingleNode("Config/Setting/PageIndex").InnerText);
            }
            catch (Exception)
            {
                LoadDefault();
            }
        }

        private void LoadDefault()
        {
            StartPosition = FormStartPosition.CenterScreen;
            Text = appname;
            notifyIcon.Text = appname;
        }
        #endregion

        #region Method
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

        private void AddLink(string item)
        {
            int i = tabControl.SelectedIndex;
            Type shellType = Type.GetTypeFromProgID("WScript.Shell");
            dynamic shell = Activator.CreateInstance(shellType);
            dynamic shortcut = shell.CreateShortcut(item);
            string path = shortcut.TargetPath;
            string args = shortcut.Arguments;
            IcoFileInfo icoFileInfolk = new IcoFileInfo(item)
            {
                Args = args
            };
            if (System.IO.File.Exists(path) || System.IO.Directory.Exists(path))
            {
                IcoFileInfo icoFileInfo = new IcoFileInfo(path)
                {
                    Name = icoFileInfolk.Name,
                    Args = args
                };
                AddFile(icoFileInfo, i);
            }
            else
            {
                AddFile(icoFileInfolk, i);
            }
        }

        private void AddFile(IcoFileInfo icoInfoFile, int i)
        {
            largeImageLists[i].Images.Add(FilesystemIcons.LargeIcon(icoInfoFile.FullName));
            smallImageLists[i].Images.Add(FilesystemIcons.SmallIcon(icoInfoFile.FullName));
            ListViewItem item = new ListViewItem
            {
                Text = icoInfoFile.Name,
                ImageIndex = largeImageLists[i].Images.Count - 1
            };
            //item.SubItems.Add(icoInfoFile.Type);
            item.SubItems.Add(icoInfoFile.FullName);
            item.SubItems.Add(icoInfoFile.Args);
            item.SubItems.Add(icoInfoFile.RunAsA.ToString());
            string tip = $"{item.Text}\n链接：{item.SubItems[1].Text}";
            if (!string.IsNullOrEmpty(item.SubItems[2].Text))
            {
                tip += $"\n参数：{item.SubItems[2].Text}";
            }
            item.ToolTipText = tip;
            listViews[i].Items.Add(item);
        }

        private void AddFile(string file)
        {
            IcoFileInfo fileinf = new IcoFileInfo(file);
            AddFile(fileinf, tabControl.SelectedIndex);
        }

        private void AddFiles(string[] files)
        {
            foreach (string item in files)
            {
                if (noReadLnk == (ModifierKeys == Keys.Control) && item.ToLower().EndsWith(".lnk"))
                {
                    try
                    {
                        AddLink(item);
                    }
                    catch (Exception)
                    {
                        AddFile(item);
                    }
                }
                else
                {
                    AddFile(item);
                }
            }
            WriteCfg();
        }

        private void AddPage(string pgname)
        {
            backimages.Add("");
            ImageList large = new ImageList
            {
                ImageSize = new Size(32, 32),
                ColorDepth = ColorDepth.Depth32Bit
            };
            ImageList small = new ImageList
            {
                ImageSize = new Size(16, 16),
                ColorDepth = ColorDepth.Depth32Bit
            };
            largeImageLists.Add(large);
            smallImageLists.Add(small);
            ListView listView = new ListView
            {
                LargeImageList = large,
                SmallImageList = small,
                AllowDrop = true,
                BorderStyle = BorderStyle.None,
                Dock = DockStyle.Fill,
                HideSelection = false,
                Location = new Point(0, 0),
                Margin = new Padding(0),
                Padding = new Padding(0),
                MultiSelect = false,
                ShowItemToolTips = true
                //UseCompatibleStateImageBehavior = false
            };
            listView.DragDrop += ListViews_DragDrop;
            listView.DragOver += ListView_DragOver;
            listView.ItemDrag += ListView_ItemDrag;
            listView.MouseClick += ListViews_MouseClick;
            listView.DoubleClick += ListView_DoubleClick;
            listView.MouseDown += ListView_MouseDown;
            listView.Columns.Add("名称", 100, HorizontalAlignment.Left);
            //listView.Columns.Add("类型", 60, HorizontalAlignment.Left);
            listView.Columns.Add("路径", 300, HorizontalAlignment.Left);
            listView.Columns.Add("参数", 100, HorizontalAlignment.Left);
            listView.Columns.Add("管理员权限", 100, HorizontalAlignment.Left);
            //listView.ArrangeIcons();
            listViews.Add(listView);
            TabPage tabPage = new TabPage
            {
                Location = new Point(0),
                Margin = new Padding(0),
                //tabPage.Size = new Size(652, 403);
                Padding = new Padding(0),
                Text = pgname
            };
            tabPage.Controls.Add(listView);
            tabControl.TabPages.Add(tabPage);
            Button button = new Button
            {
                //BackColor = Color.Transparent,// Color.White,
                FlatStyle = FlatStyle.Flat,
                Margin = new Padding(0),
                Padding = new Padding(0),
                //Location = new Point(tbwidth * buttons.Count, 0),
                Size = new Size(tbwidth, tbheight),
                Text = pgname,
                UseVisualStyleBackColor = false
            };
            //button.FlatAppearance.BorderColor = Color.LightBlue;
            button.Click += new EventHandler(Button_Click);
            //button.MouseDown += new MouseEventHandler(Button_MouseDown);
            buttons.Add(button);
            panelButton.Controls.Add(button);
        }

        private void RemovePage(int i)
        {
            backimages.RemoveAt(i);
            listViews.RemoveAt(i);
            largeImageLists.RemoveAt(i);
            smallImageLists.RemoveAt(i);
            tabControl.TabPages.RemoveAt(i);
            buttons.RemoveAt(i);
            FitButton();
        }

        public void FitButton()
        {
            panelButton.Width = tbwidth;
            panelButton.Height = tbheight;
            panelButton.Controls.Clear();
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Size = new Size(tbwidth, tbheight);
                if (panelButton.Dock == DockStyle.Top || panelButton.Dock == DockStyle.Bottom)
                {
                    buttons[i].Location = new Point(tbwidth * i, 0);
                }
                else
                {
                    buttons[i].Location = new Point(0, tbheight * i);
                }
                panelButton.Controls.Add(buttons[i]);
                if (i == tabControl.SelectedIndex)
                {
                    buttons[i].ForeColor = colorF2;
                    buttons[i].BackColor = colorB2;// Color.LightBlue;
                }
                else
                {
                    buttons[i].ForeColor = colorF1;
                    buttons[i].BackColor = Color.Transparent;// Color.White;
                }
                buttons[i].FlatAppearance.BorderColor = colorB2;
            }
            FormMain_Resize(null, null);
        }
        #endregion

        #region MENU
        private void ContextMenuStripMain_Opening(object sender, CancelEventArgs e)
        {
            bool b = listViews.Count > 0 && listViews[tabControl.SelectedIndex].SelectedItems.Count > 0;
            RunAsAdminToolStripMenuItem.Visible = b;
            RemoveToolStripMenuItem.Visible = b;
            ShowFileToolStripMenuItem.Visible = b;
            EditToolStripMenuItem.Visible = b;
            toolStripMenuItem1.Visible = tabControl.TabPages.Count > 0;
            RemovePageToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
            ViewToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
            AddToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
            ClearToolStripMenuItem.Visible = tabControl.TabPages.Count > 0 && listViews[tabControl.SelectedIndex].Items.Count > 0; ;
            EditPageToolStripMenuItem.Visible = tabControl.TabPages.Count > 0;
        }

        private void BigIconsToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.LargeIcon;
        private void SmallIconsToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.SmallIcon;
        private void DetailToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.Details;
        private void ListToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.List;
        private void TileToolStripMenuItem_Click(object sender, EventArgs e) => listViews[tabControl.SelectedIndex].View = View.Tile;

        private void AddFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    AddFiles(openFileDialog.FileNames);
                    WriteCfg();
                }
            }
        }

        private void AddDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog())
            {
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    AddFiles(new string[] { folder.SelectedPath });
                    WriteCfg();
                }
            }
        }

        private void AddNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditIco editIco = new EditIco(new IcoFileInfo("")))
            {
                editIco.TopMost = TopMost;
                if (editIco.ShowDialog() == DialogResult.OK)
                {
                    AddFile(editIco.f, tabControl.SelectedIndex);
                    WriteCfg();
                }
            }
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            int j = listViews[i].SelectedItems[0].Index;
            if (listViews[i].SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "确定要删除选择的项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
                listViews[i].Items.RemoveAt(j);
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

        private void ShowFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViews[tabControl.SelectedIndex].SelectedItems.Count > 0)
            {
                using (System.Diagnostics.Process p = new System.Diagnostics.Process())
                {
                    string ffull = listViews[tabControl.SelectedIndex].SelectedItems[0].SubItems[1].Text;
                    if (ffull.Contains(" "))
                    {
                        ffull = "\"" + ffull + "\"";
                    }
                    p.StartInfo.FileName = "Explorer.exe";
                    p.StartInfo.Arguments = "/e,/select," + ffull;
                    p.Start();
                    p.Close();
                }
            }
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViews[tabControl.SelectedIndex].Items.Count >= 1 && MessageBox.Show(this, "确定要删除所有项目？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                listViews[tabControl.SelectedIndex].Items.Clear();
                largeImageLists[tabControl.SelectedIndex].Images.Clear();
                smallImageLists[tabControl.SelectedIndex].Images.Clear();
            }
        }

        private void RunAsAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i1 = tabControl.SelectedIndex;
            int i = listViews[i1].SelectedItems[0].Index;
            if (listViews[i1].SelectedItems.Count == 1)
            {
                string path = listViews[i1].Items[i].SubItems[1].Text;
                string arg = listViews[i1].Items[i].SubItems[2].Text;
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

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i1 = tabControl.SelectedIndex;
            if (listViews[i1].SelectedItems.Count > 0)
            {
                int i = listViews[i1].SelectedItems[0].Index;
                IcoFileInfo f1 = new IcoFileInfo(listViews[i1].SelectedItems[0].SubItems[1].Text)
                {
                    Name = listViews[i1].SelectedItems[0].Text,
                    Args = listViews[i1].SelectedItems[0].SubItems[2].Text,
                    RunAsA = listViews[i1].SelectedItems[0].SubItems[3].Text.ToLower() == "true"
                };
                using (EditIco editIco = new EditIco(f1))
                {
                    editIco.TopMost = TopMost;
                    if (editIco.ShowDialog() == DialogResult.OK)
                    {
                        if (listViews[i1].Items[i].SubItems[1].Text != editIco.f.FullName)
                        {
                            largeImageLists[i1].Images[listViews[i1].Items[i].ImageIndex] = FilesystemIcons.LargeIcon(editIco.f.FullName).ToBitmap();
                            smallImageLists[i1].Images[listViews[i1].Items[i].ImageIndex] = FilesystemIcons.SmallIcon(editIco.f.FullName).ToBitmap();
                        }
                        listViews[i1].Items[i].Text = editIco.f.Name;
                        listViews[i1].Items[i].SubItems[1].Text = editIco.f.Name;
                        listViews[i1].Items[i].SubItems[2].Text = editIco.f.Args;
                        listViews[i1].Items[i].SubItems[3].Text = editIco.f.RunAsA.ToString();
                        string tip = $"{editIco.f.Name}\n链接：{editIco.f.Name}";
                        if (!string.IsNullOrEmpty(editIco.f.Args))
                        {
                            tip += $"\n参数：{editIco.f.Args}";
                        }
                        listViews[i1].Items[i].ToolTipText = tip;
                        WriteCfg();
                    }
                }
            }
        }

        private void EditPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (EditPage editPage = new EditPage(this, tabControl.SelectedIndex))
            {
                editPage.ShowDialog();
            }
        }

        private void AddPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (InputName nameTab = new InputName(null))
            {
                nameTab.TopMost = TopMost;
                if (nameTab.ShowDialog() == DialogResult.OK)
                {
                    AddPage(nameTab.name);
                    tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
                    FitButton();
                }
            }
        }

        private void RemovePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = tabControl.SelectedIndex;
            if (i > -1 && MessageBox.Show(this, "确定要删除选择的项目吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                RemovePage(i);
            }
        }

        private void SettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int w1 = tbwidth;
            int h1 = tbheight;
            using (Setting setting = new Setting(this))
            {
                if (sender == SettingToolStripMenuItem)
                {
                    setting.StartPosition = FormStartPosition.CenterParent;
                }
                setting.ShowDialog();
            }
            if (w1 != tbwidth || h1 != tbheight)
            {
                FitButton();
            }
            Activate();
            WriteCfg();
            notifyIcon.Text = Text;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            goexit = true;
            Close();
        }
        #endregion
    }

    public class IcoFileInfo
    {
        public IcoFileInfo(string filename)
        {
            FullName = filename;
            Args = "";
            RunAsA = false;
            NameWithEx = System.IO.Path.GetFileName(filename);
            Name = NameWithEx.Trim('.').Contains(".") ? NameWithEx.Substring(0, NameWithEx.LastIndexOf(".")) : NameWithEx;
            //Type = System.IO.Directory.Exists(filename) ? "<DIR>" : System.IO.Path.GetExtension(filename);
        }
        public string Name { get; set; }
        //public string Type { get; set; }
        public string NameWithEx { get; set; }
        public string FullName { set; get; }
        public string Args { set; get; }
        public bool RunAsA { set; get; }
    }
}
