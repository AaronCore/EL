using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Entity
{
    public class MenuEntity : DefaultEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public virtual MenuEntity ParentMenu { set; get; }
        public virtual ICollection<MenuEntity> Menus { set; get; }
    }
}
