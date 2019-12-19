using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Entity
{
    public class RoleMenuEntity
    {
        public int RoleId { get; set; }
        public virtual RoleEntity Role { set; get; }
        public int MenuId { get; set; }
        public virtual MenuEntity Menu { set; get; }
    }
}
