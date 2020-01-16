using System;
using System.Collections.Generic;
using System.Text;
using EL.Common;

namespace EL.Application
{
    public class MenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
        public bool Enabled { get; set; }
    }
}
