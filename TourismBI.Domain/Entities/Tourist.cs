using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismBI.Domain.Enums;
using TourismBI.Domain.Interfaces;



namespace TourismBI.Domain.Entities
{
    public class Tourist : User
    {
        public Tourist(string username, string email, string passwordHash) : base(username, email, passwordHash, UserRole.Tourist)
        {
        }

        public void LeaveReview(string review)
        {
            if (string.IsNullOrWhiteSpace(review))
            {
                throw new ArgumentException("Review cannot be empty.");
            }
            //if (review.Length > 500)
            //{
            //    throw new ArgumentException("Review cannot exceed 500 characters.");
            //}
            // review logic here, e.g., save to a database or display
            // Console.WriteLine($"Review left by {UserName}: {review}");
        }
        public override void DescribePermissions()
        {
            Console.WriteLine("Може да търси обекти и да оставя ревюта");
        }
        public override void ChangePassword(string newPassword, IPasswordHasher hasher)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                throw new ArgumentException("Password cannot be empty.", nameof(newPassword));
            }

            PasswordHash = hasher.HashPassword(newPassword);
        }
        
            // Optionally, you can hash the email if needed
            // EmailHash = hasher.HashEmail(newEmail);

        }
    }
}
