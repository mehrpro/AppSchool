using System;
using System.Reflection;

namespace SchoolDataAccess
{
    class PropertyModel
    {
        public string PropertyName { get; set; }
        public string ColumnName { get; set; }
        public bool IsPrimeryKey { get; set; }
        public bool IsComputed { get; set; }
        public PropertyInfo Propertyinfo { get; set; }
    }
}
