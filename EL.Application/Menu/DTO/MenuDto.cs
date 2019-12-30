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
    public class MenuTreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
        public bool Enabled { get; set; }
        public string CreateTime { get; set; }
        public List<MenuTreeDto> Children { get; set; }
    }
    public class MenuListDto
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public List<MenuListDto> Children { get; set; }
    }
}
