using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismBI.Domain.Entities;
using TourismBI.Domain.Enums;

namespace TourismBI.Domain.Services
{
    public interface IUserDomainValidator
    {

        IEnumerable<ValidationError> ValidateUserName(User user);
            

    }
}
