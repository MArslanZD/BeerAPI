using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beer.Models
{
    public sealed class RatingsModel
    {
        [Key]
        public int RatingId { get; set; }
        public int BeerId { get; set; }
        public int Ratings { get; set; }
    }
}
