using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLinks
{
    public static class FilesystemIcons
    {
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_LARGEICON = 0x0;

        #region PublicIcons
        public static Icon ICON_DIRECTORY_16x = ExtractIconFromFileX16(@"C:\Windows\system32\shell32.dll", 3); //Icon auch in Shell32.dll,3
        public static Icon ICON_DIRECTORY_32x = ExtractIconFromFileX32(@"C:\Windows\system32\shell32.dll", 3); //Icon auch in Shell32.dll,3
        public static Icon ICON_FILE_16x = ExtractIconFromFileX16(@"C:\Windows\system32\shell32.dll", 0);
        public static Icon ICON_FILE_32x = ExtractIconFromFileX32(@"C:\Windows\system32\shell32.dll", 0);
        //public static Icon ICON_NETWORK_16x = ExtractIconFromFileX16(@"C:\Windows\system32\shell32.dll", 17);
        //public static Icon ICON_NETWORK_32x = ExtractIconFromFileX32(@"C:\Windows\system32\shell32.dll", 17);
        //public static Icon ICON_COMPUTER_16x = ExtractIconFromFileX16(@"C:\Windows\system32\shell32.dll", 15);
        //public static Icon ICON_COMPUTER_32x = ExtractIconFromFileX32(@"C:\Windows\system32\shell32.dll", 15);
        //public static Icon ICON_NETWORKFOLDER_16x = ExtractIconFromFileX16(@"C:\Windows\system32\shell32.dll", 275);
        //public static Icon ICON_NETWORKFOLDER_32x = ExtractIconFromFileX32(@"C:\Windows\system32\shell32.dll", 275);
        #endregion

        //public static Icon ICON_MY_16x = ExtractIconFromFileX16(@"C:\Windows\system32\imageres.dll", 101); //Icon auch in Shell32.dll,3
        public static Icon SmallIcon(string pfad)
        {
            if (string.IsNullOrEmpty(pfad))
            {
                return ICON_FILE_16x;
            }
            Icon icon;
            try
            {
                icon = GetSmallIcon(pfad);
            }
            catch (Exception)
            {
                icon = ICON_FILE_16x;
            }
            if (icon == null)
            {
                return ICON_FILE_16x;
            }
            return icon;
        }

        public static Icon LargeIcon(string pfad)
        {
            if (string.IsNullOrEmpty(pfad))
            {
                return ICON_FILE_32x;
            }

            Icon icon;
            try
            {
                icon = GetLargeIcon(pfad);
            }
            catch (Exception)
            {
                icon = ICON_FILE_32x;
            }
            if (icon == null)
            {
                return ICON_FILE_32x;
            }
            return icon;
        }


        [DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
        public struct SHFILEINFO
        {
            // : icon
            public IntPtr hIcon;
            // : icondex
            public int iIcon;
            // : SFGAO_ flags
            public int dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }


        #region PrivateMethods
        private static Icon ExtractIconFromFileX16(string file, int iconindex)
        {
            IntPtr large;
            IntPtr small;
            try
            {
                ExtractIconEx(file, iconindex, out large, out small, 1);
                return Icon.FromHandle(small);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Icon ExtractIconFromFileX32(string file, int iconindex)
        {
            IntPtr large;
            IntPtr small;
            try
            {
                ExtractIconEx(file, iconindex, out large, out small, 1);
                return Icon.FromHandle(large);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PublicMethods
        /// <summary>
        /// Gibt das kleine Icon des Pfades aus
        /// </summary>
        /// <param name="pfad">Der Pfad zu einem Ordner oder Datei</param>
        /// <returns></returns>
        public static Icon GetSmallIcon(string pfad)
        {
            IntPtr hImgSmall = default(IntPtr);
            //The handle to the system image list.
            SHFILEINFO shinfo = new SHFILEINFO();
            shinfo.szDisplayName = new string((char)0, 260);
            shinfo.szTypeName = new string((char)0, 80);
            hImgSmall = SHGetFileInfo(pfad, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            return myIcon;
        }

        /// <summary>
        /// Gibt das große Icon des Pfades aus
        /// </summary>
        /// <param name="pfad">Der Pfad zu einem Ordner oder Datei</param>
        /// <returns></returns>
        public static Icon GetLargeIcon(string pfad)
        {
            IntPtr hImgSmall = default(IntPtr);
            //The handle to the system image list.
            SHFILEINFO shinfo = new SHFILEINFO();
            shinfo.szDisplayName = new string((char)0, 260);
            shinfo.szTypeName = new string((char)0, 80);
            hImgSmall = SHGetFileInfo(pfad, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            System.Drawing.Icon myIcon = System.Drawing.Icon.FromHandle(shinfo.hIcon);
            return myIcon;
        }

        /// <summary>
        /// Gibt das Icon anhand der Extension aus
        /// </summary>
        /// <param name="extension">Die Erweiterung im Format '.extension'</param>
        /// <returns></returns>
        public static Icon GetIconByExtension_x16(string extension)
        {
            RegistryKey rk = Registry.ClassesRoot.OpenSubKey(extension);
            //Extension-Key wird geöffnet
            string assockey = (string)rk.GetValue("", "");
            rk = Registry.ClassesRoot.OpenSubKey(assockey);
            //Wechseln auf anderen Key
            //Wert aus Default-Wert wird in das Textfeld geschrieben
            Icon imgicon = null;
            try
            {
                RegistryKey di = rk.OpenSubKey("DefaultIcon");
                //Ruft den SubKey für das DefaultIcon auf
                string defaulticon = (string)di.GetValue("", "");
                //Wert wird in TextBox geschrieben
                if (defaulticon.Length > 0)
                {
                    try
                    {
                        int komma = defaulticon.IndexOf(",");
                        //Wenn kein Komma enthalten ist, wird -1 zurückgegeben
                        if (komma != -1)
                        {
                            int ii = Convert.ToInt32(defaulticon.Substring(komma + 1).Trim());
                            //Imageindex wird ermittelt
                            imgicon = ExtractIconFromFileX16(defaulticon.Substring(0, komma), ii);
                        }
                        else
                        {
                            imgicon = ExtractIconFromFileX16(defaulticon, 0);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            return imgicon;
        }

        /// <summary>
        /// Gibt das Icon anhand der Extension aus
        /// </summary>
        /// <param name="extension">Die Erweiterung im Format '.extension'</param>
        /// <returns></returns>
        public static Icon GetIconByExtension_x32(string extension)
        {
            RegistryKey rk = Registry.ClassesRoot.OpenSubKey(extension);
            //Extension-Key wird geöffnet
            string assockey = (string)rk.GetValue("", "");
            rk = Registry.ClassesRoot.OpenSubKey(assockey);
            //Wechseln auf anderen Key
            //Wert aus Default-Wert wird in das Textfeld geschrieben
            Icon imgicon = null;
            try
            {
                RegistryKey di = rk.OpenSubKey("DefaultIcon");
                //Ruft den SubKey für das DefaultIcon auf
                string defaulticon = (string)di.GetValue("", "");
                //Wert wird in TextBox geschrieben
                if (defaulticon.Length > 0)
                {
                    try
                    {
                        int komma = defaulticon.IndexOf(",");
                        //Wenn kein Komma enthalten ist, wird -1 zurückgegeben
                        if (komma != -1)
                        {
                            int ii = Convert.ToInt32(defaulticon.Substring(komma + 1).Trim());
                            //Imageindex wird ermittelt
                            imgicon = ExtractIconFromFileX32(defaulticon.Substring(0, komma), ii);
                        }
                        else
                        {
                            imgicon = ExtractIconFromFileX32(defaulticon, 0);
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            return imgicon;
        }

        #endregion
    }
}
