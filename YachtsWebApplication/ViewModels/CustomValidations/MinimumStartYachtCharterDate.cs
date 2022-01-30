using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YachtsWebApplication.ViewModels.CustomValidations
{
    public class MinimumStartYachtCharterDate : ValidationAttribute
    {
        public DateTime SelectedDateTime { get; set; }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            var MinStartDate = DateTime.Today.AddDays(2);
            SelectedDateTime = (DateTime)value;
            if (SelectedDateTime <= MinStartDate)
            {
                return false;
            }
            return true;
        }
    }
}