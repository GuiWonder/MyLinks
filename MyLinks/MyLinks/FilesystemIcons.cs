using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MyLinks
{
    public static class FilesystemIcons
    {
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_LARGEICON = 0x0;

        #region PublicIcons
        public static Icon ICON_FILE_16x = ExtractIconFromFileX16(@"C:\Windows\system32\shell32.dll", 0);
        public static Icon ICON_FILE_32x = ExtractIconFromFileX32(@"C:\Windows\system32\shell32.dll", 0);
        #endregion

        public static Icon SmallIcon(string pfad)
        {
            if (string.IsNullOrEmpty(pfad))
            {
                return ICON_FILE_16x;
            }
            try
            {
                return GetSmallIcon(pfad) ?? ICON_FILE_16x;
            }
            catch (Exception)
            {
                return ICON_FILE_16x;
            }
        }

        public static Icon LargeIcon(string pfad)
        {
            if (string.IsNullOrEmpty(pfad))
            {
                return ICON_FILE_32x;
            }
            try
            {
                return GetLargeIcon(pfad) ?? ICON_FILE_32x;
            }
            catch (Exception)
            {
                return ICON_FILE_32x;
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        #region PrivateMethods
        private static Icon ExtractIconFromFileX16(string file, int iconindex)
        {
            try
            {
                ExtractIconEx(file, iconindex, out IntPtr large, out IntPtr small, 1);
                return Icon.FromHandle(small);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Icon ExtractIconFromFileX32(string file, int iconindex)
        {
            try
            {
                ExtractIconEx(file, iconindex, out IntPtr large, out IntPtr small, 1);
                return Icon.FromHandle(large);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region PublicMethods
        public static Icon GetSmallIcon(string pfad)
        {
            SHFILEINFO shinfo = new SHFILEINFO
            {
                szDisplayName = new string((char)0, 260),
                szTypeName = new string((char)0, 80)
            };
            SHGetFileInfo(pfad, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            return Icon.FromHandle(shinfo.hIcon);
        }

        public static Icon GetLargeIcon(string pfad)
        {
            SHFILEINFO shinfo = new SHFILEINFO
            {
                szDisplayName = new string((char)0, 260),
                szTypeName = new string((char)0, 80)
            };
            SHGetFileInfo(pfad, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_LARGEICON);
            return Icon.FromHandle(shinfo.hIcon);
        }

        #endregion
    }
}
