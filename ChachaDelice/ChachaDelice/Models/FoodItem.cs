using System;
using System.Collections.Generic;
using System.Text;

namespace ChachaDelice.Models
{
    public class FoodItem
    {
        public string Name { get; set; }
        public decimal Prix { get; set; }
        public string  ImageUrl { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string RatingDetail { get; set; }
        public int CategoryID { get; set; }
        public int ProductID { get; set; }

    }
}
