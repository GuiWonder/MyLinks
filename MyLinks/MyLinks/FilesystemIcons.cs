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

        [DllImport("shell32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, int uFlags);
        [DllImport("shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion, out IntPtr piSmallVersion, int amountIcons);

        public static Icon GiveIcon(string pfad, bool IsSmall)
        {
            Icon defico = ExtractIconFromFileXIs16(@"C:\Windows\system32\shell32.dll", 0, IsSmall);
            if (string.IsNullOrEmpty(pfad))
            {
                return defico;
            }
            try
            {
                return GetIcon(pfad, IsSmall) ?? defico;
            }
            catch (Exception)
            {
                return defico;
            }
        }

        private static Icon GetIcon(string pfad, bool IsSmall)
        {
            int SHGFI_SLICON = IsSmall ? SHGFI_SMALLICON : SHGFI_LARGEICON;
            SHFILEINFO shinfo = new SHFILEINFO
            {
                szDisplayName = new string((char)0, 260),
                szTypeName = new string((char)0, 80)
            };
            SHGetFileInfo(pfad, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SLICON);
            return Icon.FromHandle(shinfo.hIcon);
        }

        private static Icon ExtractIconFromFileXIs16(string file, int iconindex, bool IsSmall)
        {
            try
            {
                ExtractIconEx(file, iconindex, out IntPtr large, out IntPtr small, 1);
                return IsSmall ? Icon.FromHandle(small) : Icon.FromHandle(large);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
