using System.ComponentModel.DataAnnotations;
using TourismBI.Domain.Common;
using TourismBI.Domain.Entities;
using TourismBI.Domain.Enums;

namespace TourismBI.Domain.Services
{
    public class DefaultUserDomainValidator : IUserDomainValidator
    {
        public IEnumerable<ValidationError> ValidateUserName(User user)
        {
            

            List<ValidationError> errors = new List<ValidationError>();

            // Username checks

            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add(ValidationError.EmptyUserName);
            }
            else if (user.UserName.Length > DomainValidationConstants.UserNameMaxLength)
            {
                errors.Add(ValidationError.UsernameTooLong);//$"Името не може да надвишава {DomainValidationConstants.UserNameMaxLength} символа");
            }
            else if (user.UserName.Length < DomainValidationConstants.UserNameMinLength)
            {
                errors.Add(ValidationError.UsernameTooShort);// $"Името трябва да е поне {DomainValidationConstants.UserNameMinLength} символа");
            }


            //E- mail checks

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                errors.Add(ValidationError.EmptyEmail);// "Моля въведете имейл адрес");

            }
            else
            {

                var emailAttribute = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();

                if (!emailAttribute.IsValid(user.Email))
                {
                    errors.Add(ValidationError.InvalidEmail);//"Моля въведете валиден имейл адрес");
                }
            
            }

            //role checks

            if (!Enum.IsDefined(typeof(UserRole), user.Role))
            {
                errors.Add(ValidationError.InvalidRole);// "Невалидна роля");
            }
            return errors;

        }

        
    }
}
