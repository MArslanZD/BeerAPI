using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Beer.Models
{
    public sealed class BeerModel
    {
        [Key]
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal AverageRatings { get; set; }
    }
    
}
