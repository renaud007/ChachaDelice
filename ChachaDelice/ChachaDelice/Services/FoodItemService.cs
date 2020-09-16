using ChachaDelice.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChachaDelice.Services
{
   public class FoodItemService
    {
        FirebaseClient client;
        public FoodItemService()
        {
            client = new FirebaseClient("https://chachadelice-13c0e.firebaseio.com/");
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
          var products=   (await client.Child("FoodItems").OnceAsync<FoodItem>()).Select(f=> new FoodItem {

              ProductID = f.Object.ProductID,
              CategoryID = f.Object.CategoryID,
              Name = f.Object.Name,
              Prix = f.Object.Prix,
              ImageUrl = f.Object.ImageUrl,
              Description = f.Object.Description,
              Rating = f.Object.Rating,
              RatingDetail = f.Object.RatingDetail


          }).ToList();
            return products;
        }
    }
}
