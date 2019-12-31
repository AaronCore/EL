using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class MenuListDto
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public List<MenuListDto> Children { get; set; }
    }
}
