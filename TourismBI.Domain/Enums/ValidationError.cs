using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismBI.Domain.Enums
{
    public enum ValidationError
    {
        //user validation errors
        EmptyUserName,
        UsernameTooLong,
        UsernameTooShort,
        EmptyEmail,
        InvalidEmail,
        InvalidRole,
        //password validation errors
        PasswordEmpty,
        PasswordTooLong,
        PasswordTooShort,
        PasswordNoDigit,
        PasswordNoUppercase,
        PasswordNoLowercase,
        PasswordSameAsPrevious,
        InvalidPreviousPasswordHash
          
    }
}
