using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChachaDelice.Models
{
    [Table("FoodInfos")]
   public class infosFood
    {
        public int CartItemId { get; set; }
        public int ProductID { get; set; }
        public string Name { get; set; }
        public Decimal Prix { get; set; }
        public int Quantity { get; set; }
    }
}
