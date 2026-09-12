using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismBI.Domain.Enums;

namespace TourismBI.Domain.Extensions
{
    public static class UserRoleExtensions
    {
        public static string ToDisplayRole(this UserRole role)
        {
            return role switch
            {
                UserRole.Tourist => "Турист",
                UserRole.Business => "Бизнес",
                UserRole.PublicAuthorities => "Публични Власти",
                UserRole.Administrator => "Администратор",  
                _ => "Неизвестна роля"

            };

        }
    }
}
