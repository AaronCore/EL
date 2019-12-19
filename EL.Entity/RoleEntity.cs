using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EL.Entity
{
    public class RoleEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        public int Id { get; set; }
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
}
