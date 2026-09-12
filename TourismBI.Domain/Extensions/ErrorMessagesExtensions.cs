using System;
using System.Linq;
using System.Collections.Generic;
using TourismBI.Domain.Common;
using TourismBI.Domain.Enums;




namespace TourismBI.Domain.Extensions
{
    // The class is responsible for translating error messages from English to Bulgarian.

    public static class ValidationErrorTranslator
    {


        public static string TranslateSingle(this ValidationError error)
        {

            return error switch
            {
                ValidationError.EmptyUserName => "Потребителското име не може да е празно",
                ValidationError.UsernameTooLong => $"Потребителското име не може да надвишава {DomainValidationConstants.UserNameMaxLength} символа",
                ValidationError.UsernameTooShort => $"Потребителското име трябва да е поне {DomainValidationConstants.UserNameMinLength} символа",
                ValidationError.EmptyEmail => "Имейл адресът не може да е празен",
                ValidationError.InvalidEmail => "Моля, въведете валиден имейл адрес",
                ValidationError.InvalidRole => "Невалидна роля",
                //password validation errors
                ValidationError.PasswordEmpty => "Паролата не може да е празна",
                ValidationError.PasswordTooLong => $"Паролата не може да надвишава {DomainValidationConstants.MaxLengthPassword} символа",
                ValidationError.PasswordTooShort => $"Паролата трябва да бъде поне {DomainValidationConstants.MinLengthPassword} символа",
                ValidationError.PasswordNoDigit => "Паролата трябва да съдържа поне една цифра",
                ValidationError.PasswordNoUppercase => "Паролата трябва да съдържа поне една главна буква",
                ValidationError.PasswordNoLowercase => "Паролата трябва да съдържа поне една малка буква",
                ValidationError.PasswordSameAsPrevious => "Паролата трябва да е различна от предишната",
                ValidationError.InvalidPreviousPasswordHash => "Хешът на предишната парола е невалиден",
                _ => error.ToString(),
            };

        }
        public static IEnumerable<string> TranslateMany(IEnumerable<ValidationError> errors)
        {
            foreach (var error in errors)
            {
                yield return error.TranslateSingle();

            }


        }
    }
}