using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Entity
{
    public class RoleEntity : DefaultEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MenuEntity> Menus { set; get; }
    }
}
