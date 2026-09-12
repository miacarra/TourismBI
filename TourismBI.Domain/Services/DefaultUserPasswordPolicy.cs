using System;
using System.Collections.Generic;
using System.Linq;
using TourismBI.Domain.Enums;
using TourismBI.Domain.Interfaces;
using static TourismBI.Domain.Common.DomainValidationConstants;


namespace TourismBI.Domain.Services
{
    public class DefaultUserPasswordPolicy : IUserPasswordPolicy
    {
        public IEnumerable<ValidationError> ValidatePassword(string password, string? previousPasswordHash)
        {
        
        
        var errors = new List<ValidationError>();



            if (string.IsNullOrWhiteSpace(password))
            {
                errors.Add(ValidationError.PasswordEmpty);
            }
            if (password.Length < MinLengthPassword)
            {
                errors.Add(ValidationError.PasswordTooShort);
            }
            if (password.Length > MaxLengthPassword)
            {
                errors.Add(ValidationError.PasswordTooLong); 
            }
            if (!password.Any(c => char.IsDigit(c)))
            {
                errors.Add(ValidationError.PasswordNoDigit);
            }
            if (!password.Any(c => char.IsLower(c)))
            {
                errors.Add(ValidationError.PasswordNoLowercase);
            }
            if (!password.Any(c => char.IsUpper(c)))
            {
                errors.Add(ValidationError.PasswordNoUppercase);
            }

            if (!string.IsNullOrWhiteSpace(previousPasswordHash))
            {
                try
                {
                    if (BCrypt.Net.BCrypt.Verify(password, previousPasswordHash))
                    {

                        errors.Add(ValidationError.PasswordSameAsPrevious);

                    }
                }
                catch 
                {
                    errors.Add(ValidationError.InvalidPreviousPasswordHash);
                }
            }

            return errors;

        }

        
    }
}