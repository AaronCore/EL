using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class AccountDto
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { set; get; }
        public string RoleName { set; get; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? EditTime { get; set; }
        /// <summary>
        /// 编辑人
        /// </summary>
        public string Editor { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater { get; set; }
    }
    public class AccountMenDto
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public bool Show { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<AccountMenDto> Children { get; set; }
    }
}
