using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EL.Common
{
    public class Logger
    {
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
            var dt = DateTime.Now;
            var baseDir = Environment.CurrentDirectory;//AppDomain.CurrentDomain.BaseDirectory;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
