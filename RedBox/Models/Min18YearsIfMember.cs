using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedBox.Models
{
    public class Min18YearsIfMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerModel)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.DOB == null)
                return new ValidationResult("* Required");
            int age = DateTime.Now.Year - customer.DOB.Value.Year;
            return (age >= 18) ? ValidationResult.Success
                : new ValidationResult("Should be 18 years or more for this Membership");
        }
    }
}