using System;
using System.Collections.Generic;

namespace ProductReview.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? LastLoginDate { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public User(string username, string email, string password, DateTime? lastLoginDate, bool? isAdmin)
        {
            Username = username;
            Email = email;
            Password = password;
            LastLoginDate = lastLoginDate;
            IsAdmin = isAdmin;
        }
    }
}
