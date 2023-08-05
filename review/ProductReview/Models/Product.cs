using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductReview.Models
{
    public partial class Product
    {
        public Product()
        {
            Reviews = new HashSet<Review>();
        }

        public int? ProductId { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="chua nhap ten")]
        public string ProductName { get; set; } = null!;
        [Required(AllowEmptyStrings = false)]
        public string? Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string? Category { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string? Brand { get; set; }
        [Required(AllowEmptyStrings = false)]
        public decimal? Price { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime ReleaseDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string? Image { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
