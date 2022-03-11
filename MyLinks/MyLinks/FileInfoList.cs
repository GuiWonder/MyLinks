using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyLinks
{
    public class FileInfoList
    {
        public List<FileInfoWithIcon> list;
        public ImageList imageListLargeIcon;
        public ImageList imageListSmallIcon;

        /// <summary>
        /// 根据文件路径获取生成文件信息，并提取文件的图标
        /// </summary>
        /// <param name="filespath"></param>
        public FileInfoList(string[] filespath)
        {
            list = new List<FileInfoWithIcon>();
            imageListLargeIcon = new ImageList
            {
                ImageSize = new Size(32, 32)
            };
            imageListSmallIcon = new ImageList
            {
                ImageSize = new Size(16, 16)
            };
            foreach (string path in filespath)
            {
                AddFile(path);
            }
        }

        public void AddFile(string fileName)
        {
            FileInfoWithIcon file = new FileInfoWithIcon(fileName);
            list.Add(file);
            imageListLargeIcon.Images.Add(file.largeIcon);//
            imageListSmallIcon.Images.Add(file.smallIcon);
            file.iconIndex = imageListLargeIcon.Images.Count - 1;
        }
        public void RemoveFileAt(int index)
        {
            list.RemoveAt(index);
        }

        public void RemoveAll()
        {
            list.Clear();
            imageListLargeIcon.Images.Clear();
            imageListSmallIcon.Images.Clear();
        }
    }
    public class FileInfoWithIcon
    {
        public FileInfo fileInfo;
        public Icon largeIcon;
        public Icon smallIcon;
        public int iconIndex;
        public string tp;
        public string Arg { get; set; }
        public string Name { get; set; }
        public bool RunAsA { set; get; }

        public FileInfoWithIcon(string path)
        {
            Arg = "";
            RunAsA = false;
            fileInfo = new FileInfo(path);
            largeIcon = GetSystemIcon.GetIconByFileName(path, true);
            tp = Directory.Exists(path) ? "folder" : Path.GetExtension(path);
            if (largeIcon == null)
                largeIcon = GetSystemIcon.GetIconByFileType(tp, true);
            smallIcon = GetSystemIcon.GetIconByFileName(path, false);
            if (smallIcon == null)
                smallIcon = GetSystemIcon.GetIconByFileType(tp, false);
            string fna = fileInfo.Name;
            if (fna.Contains(".") && !fna.StartsWith("."))
            {
                Name = fna.Substring(0, fna.LastIndexOf("."));
            }
            else
            {
                Name = fna;
            }
        }
    }

    public static class GetSystemIcon
    {
        /// <summary>  
        /// 定义调用的API方法  
        /// </summary>  
        [System.Runtime.InteropServices.DllImport("shell32.dll")]
        public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);

        /// <summary>
        /// 依据文件名读取图标，若指定文件不存在，则返回空值。  
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="isLarge">是否返回大图标</param>
        /// <returns></returns>
        public static Icon GetIconByFileName(string fileName, bool isLarge = true)
        {
            int[] phiconLarge = new int[1];
            int[] phiconSmall = new int[1];
            //文件名 图标索引 
            ExtractIconEx(fileName, 0, phiconLarge, phiconSmall, 1);
            IntPtr IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
            if (IconHnd.ToString() == "0")
                return null;
            return Icon.FromHandle(IconHnd);
        }

        /// <summary>  
        /// 根据文件扩展名（如:.*），返回与之关联的图标。
        /// 若不以"."开头则返回文件夹的图标。  
        /// </summary>  
        /// <param name="fileType">文件扩展名</param>  
        /// <param name="isLarge">是否返回大图标</param>  
        /// <returns></returns>  
        public static Icon GetIconByFileType(string fileType, bool isLarge)
        {
            string regIconString = null;
            string systemDirectory = Environment.SystemDirectory + "\\";
            if (string.IsNullOrEmpty(fileType))
            {
                regIconString = systemDirectory + "shell32.dll,0";
            }
            else if (fileType == "folder")
            {
                regIconString = systemDirectory + "shell32.dll,3";
            }
            else if (fileType[0] == '.')
            {
                //读系统注册表中文件类型信息  
                Microsoft.Win32.RegistryKey regVersion = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(fileType, false);
                if (regVersion != null)
                {
                    string regFileType = regVersion.GetValue("") as string;
                    regVersion.Close();
                    regVersion = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(regFileType + @"\DefaultIcon", false);
                    if (regVersion != null)
                    {
                        regIconString = regVersion.GetValue("") as string;
                        regVersion.Close();
                    }
                }
                if (regIconString == null)
                {
                    //没有读取到文件类型注册信息，指定为未知文件类型的图标  
                    regIconString = systemDirectory + "shell32.dll,0";
                }
            }
            else
            {
                regIconString = systemDirectory + "shell32.dll,0";
                //直接指定为文件夹图标  
                //regIconString = systemDirectory + "shell32.dll,3";
            }
            string[] fileIcon = regIconString.Split(new char[] { ',' });
            if (fileIcon.Length != 2)
            {
                //系统注册表中注册的标图不能直接提取，则返回可执行文件的通用图标  
                fileIcon = new string[] { systemDirectory + "shell32.dll", "2" };
            }
            Icon resultIcon = null;
            try
            {
                //调用API方法读取图标  
                int[] phiconLarge = new int[1];
                int[] phiconSmall = new int[1];
                uint count = ExtractIconEx(fileIcon[0], Int32.Parse(fileIcon[1]), phiconLarge, phiconSmall, 1);
                IntPtr IconHnd = new IntPtr(isLarge ? phiconLarge[0] : phiconSmall[0]);
                resultIcon = Icon.FromHandle(IconHnd);
            }
            catch //(Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            if (resultIcon == null)
            {
                resultIcon = GetIconByFileType("", isLarge);
            }
            return resultIcon;
        }
    }
}