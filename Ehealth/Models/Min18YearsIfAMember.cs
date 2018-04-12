using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ehealth.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (User)validationContext.ObjectInstance;

            if (user.MembershipTypeId == MembershipType.Unknown || user.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (user.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - user.BirthDate.Value.Year;

            return (age >= 18 
                ? ValidationResult.Success
                : new ValidationResult("User should be at least 18 years old to go on a membership."));
        }
    }
}