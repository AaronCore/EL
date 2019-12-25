using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EL.Entity
{
    public class RoleEntity : DefaultEntity
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 账号集合
        /// </summary>
        public virtual ICollection<AccountEntity> Accounts { set; get; }
        /// <summary>
        /// 角色菜单关联
        /// </summary>
        public virtual ICollection<RoleMenuEntity> RoleMenus { set; get; }
    }
}
