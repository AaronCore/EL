using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Entity
{
    public class MenuEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        public int Id { get; set; }
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
