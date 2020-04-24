using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class DataBaseTableDto
    {
        public string Table_Schema { get; set; }
        public string Table_Name { get; set; }
        public string Table_Comment { get; set; }
        public int Table_Rows { get; set; }
        public string Create_Time { get; set; }
        public string Update_Time { get; set; }
    }
}
