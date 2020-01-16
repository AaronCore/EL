using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public int RoleId { set; get; }
        public string RoleName { set; get; }
        public int Sort { get; set; }
        public bool Enabled { get; set; }
        public DateTime? EditTime { get; set; }
        public string Editor { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creater { get; set; }
    }
}
