using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Entity
{
    public class MenuEntity : DefaultEntity
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        public virtual MenuEntity ParentMenu { set; get; }
        public virtual ICollection<MenuEntity> Menus { set; get; }
        /// <summary>
        /// 角色菜单
        /// </summary>
        public virtual ICollection<RoleMenuEntity> RoleMenus { set; get; }
    }
}
