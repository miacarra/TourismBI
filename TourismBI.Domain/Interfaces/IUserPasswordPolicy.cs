using System;
using System.Collections.Generic;
using TourismBI.Domain.Enums;



namespace TourismBI.Domain.Interfaces
{
          public interface IUserPasswordPolicy
            {
              IEnumerable<ValidationError> ValidatePassword(string password, string? previousPasswordHash = null);
            }
}
