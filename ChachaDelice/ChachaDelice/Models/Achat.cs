using System;
using System.Collections.Generic;
using System.Text;

namespace ChachaDelice.Models
{
   public class Achat
    {
        public int CartItemId { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Prix { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}
