﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPCursus3.Attributes
{
    public class VerledenAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if (!(value is DateTime))
                return false;
            return ((DateTime)value) < DateTime.Today;
        }
    }
}