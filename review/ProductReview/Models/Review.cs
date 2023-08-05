using System;
using System.Collections.Generic;

namespace ProductReview.Models
{
    public partial class Review
    {
        public Review()
        {
            Comments = new HashSet<Comment>();
        }

        public Review(int? productId, int? userId, int? rating, string? reviewText, DateTime? reviewDate)
        {
            ProductId = productId;
            UserId = userId;
            Rating = rating;
            ReviewText = reviewText;
            ReviewDate = reviewDate;
        }

        public int ReviewId { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public int? Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime? ReviewDate { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
