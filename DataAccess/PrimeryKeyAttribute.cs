using System;
namespace SchoolDataAccess
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public class PrimeryKeyAttribute :Attribute
    {
    }
}
