using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst1.Models.Annotations 
{
    public class MyDateFormatAttribute : DisplayFormatAttribute
    {
        public MyDateFormatAttribute()
            : base()
        {
            base.DataFormatString = "{0:dd/MM/yyyy}";
        }
    }
}