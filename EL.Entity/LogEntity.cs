using System;

namespace EL.Entity
{
    public class LogEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 信息
        /// </summary>
        public string Message { get; set; }
        public string Callsite { get; set; }
        /// <summary>
        /// 异常
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Logged { get; set; }
    }
}
