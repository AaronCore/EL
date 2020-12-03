using System;
using System.IO;

namespace EL.Common
{
    /// <summary>
    /// Log帮助类
    /// </summary>
    public class LogHelper
    {
        private static object lockObj = new object();
        /// <summary>
        /// 日志写入
        /// </summary>
        /// <param name="message">内容</param>
        /// <param name="folder">文件夹名称</param>
        public static void Write(string message, string folder = "folder")
        {
            WriteLog(message, folder);
        }
        private static void WriteLog(string message, string folder)
        {
            lock (lockObj)
            {
                var dt = DateTime.Now;
                var baseDir = AppDomain.CurrentDomain.BaseDirectory; //Environment.CurrentDirectory;
                try
                {
                    var dir = Path.Combine(baseDir, "Logs", dt.ToString("yyyy-MM-dd"), folder);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    using (var sw = new StreamWriter(Path.Combine(dir, dt.ToString("yyyy-MM-dd HH") + ".log"), true))
                    {
                        sw.WriteLine("时间：{0}\n内容：{1}\n", dt.ToString("yyyy-MM-dd HH:mm:ss"), message);
                        sw.Close();
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
    }
}
