using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class AccountMenDto
    {
        public string Title { get; set; }
        public string Key { get; set; }
        public bool Show { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<AccountMenDto> Children { get; set; }
    }
}
