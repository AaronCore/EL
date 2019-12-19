using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class Menu_DTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creater { get; set; }
        public DateTime EditTime { get; set; }
        public string Editor { get; set; }
        public bool hasChildren { get; set; }
        public List<Menu_DTO> children { get; set; }
    }
}
