using ChachaDelice.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChachaDelice.Services
{
    public class OrderService
    {
        FirebaseClient client;
        public OrderService()
        {
            client = new FirebaseClient("https://chachadelice-13c0e.firebaseio.com/");

        }

        public async Task<string> PlaceOrderAsync()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<infosFood>().ToList();

            var orderId = Guid.NewGuid().ToString();
            decimal TotalCost = 0;

            foreach(var item in data)
            {
                var od = new OrderDetails
                {
                    OrderId = orderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductID = item.ProductID,
                    ProductName = item.Name,
                    Price = item.Prix,
                    Quantity = item.Quantity
                };

                TotalCost = item.Prix * item.Quantity;
                await client.Child("OrderDetails").PostAsync(od);
            }


            await client.Child("Orders").PostAsync(new Order { OrderId = orderId, TotalCost = TotalCost });
            return orderId;
        }
    }
}
