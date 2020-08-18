using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataAccess
{
    class PropertyModel
    {
        public string PropertyName { get; set; }
        public string ColumnName { get; set; }
        public bool IsPrimeryKey { get; set; }
        public bool IsComputed { get; set; }
    }
}
