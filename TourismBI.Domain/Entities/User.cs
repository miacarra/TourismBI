using System.ComponentModel.DataAnnotations;
using System.IO.IsolatedStorage;
using TourismBI.Domain.Enums;
using TourismBI.Domain.Interfaces;




namespace TourismBI.Domain.Entities
{

    
    public abstract class User
    {
 
        
        [Key]
        public int UserId { get; private set; }
        
        
        [Required]
        [MaxLength(70)]
        public string UserName {get; private set; }

        [Required]
        [EmailAddress]
        public string Email { get; private set; }

        [Required]
        public string PasswordHash { get; private set; }

        [Required]
        public UserRole Role { get; private set; }
        
        public bool IsBanned { get; private set; }

        public DateTime DateCreated { get; private set; }= DateTime.UtcNow;


        protected User(string userName, string email, string passwordHash, UserRole role)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            
        }
        
        public void BanUser(User banInitiator)
        {
            if (banInitiator.Role != UserRole.Administrator)
            {
                throw new UnauthorizedAccessException("Only admins can ban users.");
            }
            if (IsBanned)
            {
                throw new InvalidOperationException("User is already banned.");
            }
            IsBanned = true;
        }
        public void UnBanUser(User unBanInitiator)
        {
            if (unBanInitiator.Role != UserRole.Administrator)
            {
                throw new UnauthorizedAccessException("Only admins can unban users.");

            }
            if (!IsBanned)
            {
                throw new InvalidOperationException("User is not banned.");
            }
            IsBanned = false;
        }
        public bool VerifyPassword(string plainPassword, IPasswordHasher passwordHasher)
        { 
        
        return passwordHasher.VerifyPassword(PasswordHash, plainPassword);
        }


        public abstract void ChangePassword(string newPassword, IPasswordHasher hasher);

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
            {
                throw new ArgumentException("Email cannot be empty.", nameof(newEmail));
            }
            Email = newEmail;
        }
            public abstract void DescribePermissions();
        
        public override string ToString()
        {
            return $"{UserName} ({Email}) - Role: {Role}, Banned: {IsBanned}, Created: {DateCreated}";
        }
    }
}
