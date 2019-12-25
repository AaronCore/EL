using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EL.Entity
{
    public class AccountEntity : DefaultEntity
    {
        /// <summary>
        /// 账号名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 角色信息
        /// </summary>
        public virtual RoleEntity Role { set; get; }
    }
}
