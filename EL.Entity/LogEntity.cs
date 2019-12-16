using System;

namespace EL.Entity
{
    /// <summary>
    /// 错误日志
    /// </summary>
    public class LogEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
