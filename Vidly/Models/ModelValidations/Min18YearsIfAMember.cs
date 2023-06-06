using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.DbModels;

namespace Vidly.Models.ModelValidations
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.unknown || customer.MembershipTypeId == MembershipType.AsPerMembership)
                return ValidationResult.Success;
            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthday Is required!");
            }
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old to go on a membership");
        }
    }
}
