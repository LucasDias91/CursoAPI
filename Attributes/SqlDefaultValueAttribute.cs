﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlDefaultValueAttribute : Attribute
    {
        public string DefaultValue { get; set; }
    }
}