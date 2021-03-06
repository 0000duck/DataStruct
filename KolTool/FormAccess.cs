using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows;

namespace KolTool
{
    /// <summary>
    /// 窗口访问类
    /// </summary>
    public static class FormAccess
    {
        #region 应用退出程序函数 ExitApp()

        /// <summary>
        /// 应用退出程序函数
        /// </summary>
        public static void ExitApp()
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill(); //强制杀进程结束程序
            try
            {
                Application.Exit();
            }
            catch
            {
            }
        }

        #endregion


        public static void KillPhantProcess()
        {
            try
            {
                string str = "";
                Process[] processes;
                //Get the list of current active processes.
                processes = System.Diagnostics.Process.GetProcesses();
                //Grab some basic information for each process.
                for (int i = 0; i < processes.Length - 1; i++)
                {
                    if (processes[i].ProcessName.Equals("phantomjs", StringComparison.OrdinalIgnoreCase)/* && processes[i].StartTime > FormAccess.appStarTime*/)
                    {
                        processes[i].Kill();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #region 计算时间差

        /// <summary>
        /// 计算时间差
        /// </summary>
        /// <param name="DateTime1">开始时间</param>
        /// <param name="DateTime2">结束时间</param>
        /// <returns></returns>
        public static int DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            int dateDiff = 0;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                dateDiff = ts2.Subtract(ts1).Seconds;
            }
            catch
            {
            }
            return dateDiff;
        }

        #endregion

        #region 播放声音

        /// <summary>
        /// 播放声音
        /// </summary>
        /// <param name="file">要播放的文件名及路径</param>
        public static void palySound(string file)
        {
            try
            {
                SoundPlayer _palySound = new SoundPlayer();
                _palySound.SoundLocation = Application.StartupPath + @"\sound\" + file + ".wav";
                _palySound.Play();
            }
            catch
            {
            }
        }

       

        #endregion

        #region 获取文件图标
        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        /// <summary>  
        /// 返回系统设置的图标  
        /// </summary>  
        /// <param name="pszPath">文件路径 如果为""  返回文件夹的</param>  
        /// <param name="dwFileAttributes">0</param>  
        /// <param name="psfi">结构体</param>  
        /// <param name="cbSizeFileInfo">结构体大小</param>  
        /// <param name="uFlags">枚举类型</param>  
        /// <returns>-1失败</returns>  
        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public enum SHGFI
        {
            SHGFI_ICON = 0x100,
            SHGFI_LARGEICON = 0x0,
            SHGFI_USEFILEATTRIBUTES = 0x10
        }


        /// <summary>  
        /// 获取文件图标 zgke@sina.com qq:116149  
        /// </summary>  
        /// <param name="p_Path">文件全路径</param>  
        /// <returns>图标</returns>  
        public static Icon GetFileIcon(string p_Path)
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            IntPtr _IconIntPtr = SHGetFileInfo(p_Path, 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON | SHGFI.SHGFI_USEFILEATTRIBUTES));
            if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }
        /// <summary>  
        /// 获取文件夹图标  zgke@sina.com qq:116149  
        /// </summary>  
        /// <returns>图标</returns>  
        public static Icon GetDirectoryIcon()
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            IntPtr _IconIntPtr = SHGetFileInfo(@"", 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), (uint)(SHGFI.SHGFI_ICON | SHGFI.SHGFI_LARGEICON));
            if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }
        #endregion
    }
}

