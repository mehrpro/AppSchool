﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataAccess
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public class ComputedColumnAttribute:Attribute
    {
    }
}
