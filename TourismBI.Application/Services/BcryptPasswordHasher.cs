using BCrypt.Net;
using TourismBI.Domain.Interfaces;


namespace TourismBIApplication.Services
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string plainPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
           return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
