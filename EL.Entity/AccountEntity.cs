using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Entity
{
    public class AccountEntity : DefaultEntity
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual RoleEntity Role { set; get; }
    }
}
