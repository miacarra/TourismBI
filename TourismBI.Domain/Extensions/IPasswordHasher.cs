using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismBIApplication.Interfaces
{
    public interface IPasswordHasher 

    {
        string HashPassword(string password);
        bool VerifyPassword(string plainPassword, string hashedPassword);

    }
}
