using System;
using System.ComponentModel.DataAnnotations;

namespace CarsRental.Models
{
    public class Min20YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            if(customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return age >= 20
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 20 years old to go on a Membership ");

        }
    }
}