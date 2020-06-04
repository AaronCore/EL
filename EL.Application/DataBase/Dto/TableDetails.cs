using System;
using System.Collections.Generic;
using System.Text;

namespace EL.Application
{
    public class TableDetails
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string Pk { get; set; }
        public string FieldLength { get; set; }
        public string IsNullable { get; set; }
        public string ColumnDefault { get; set; }
        public string Remark { get; set; }
    }
}
