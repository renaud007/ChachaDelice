using ChachaDelice.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChachaDelice.Helpers
{
    class AddFoodItem 
    {
        FirebaseClient client;

        List<FoodItem> FoodItems { get; set; }
        public AddFoodItem()
        {
            client = new FirebaseClient("https://chachadelice-13c0e.firebaseio.com/");
            FoodItems = new List<FoodItem>()
            {
                new FoodItem
                {
                    ProductID=1,
                    CategoryID=1,
                    Name="Attieke (Poisson/Poulet)",
                    Prix= 50,
                    ImageUrl="ATTIEKE2.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"                    
                },
                 new FoodItem
                {
                    ProductID=2,
                    CategoryID=1,
                    Name="Tchièp (Poisson/Poulet)",
                    Prix= 50,
                    ImageUrl="TCHIEP.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
                new FoodItem
                {
                    ProductID=3,
                    CategoryID=1,
                    Name="Riz au curry (Poisson/Poulet)",
                    Prix= 45,
                    ImageUrl="RizAuCurry.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
                new FoodItem
                {
                    ProductID=4,
                    CategoryID=1,
                    Name="Djekoumé au poulet",
                    Prix= 45,
                    ImageUrl="Dzekoume.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
                 new FoodItem
                {
                    ProductID=5,
                    CategoryID=1,
                    Name="Riz blanc au jus de tomate (Poisson)",
                    Prix= 40,
                    ImageUrl="RizBlancSauceTomate.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
                 new FoodItem
                {
                    ProductID=6,
                    CategoryID=1,
                    Name="Ayimolou (Poisson)",
                    Prix= 50,
                    ImageUrl="ayimolou.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
                 new FoodItem
                {
                    ProductID=7,
                    CategoryID=1,
                    Name="Smida à la sauce arachide (Poulet)",
                    Prix= 45,
                    ImageUrl="akoume_sauce_Arachide.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                }, new FoodItem
                {
                    ProductID=8,
                    CategoryID=1,
                    Name="Smida à la sauce tomate (Poulet)",
                    Prix= 35,
                    ImageUrl="akoume_sauce_tomate.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=10,
                    CategoryID=1,
                    Name="Akoumey avec yebessessi (Poisson)",
                    Prix= 45,
                    ImageUrl="",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=11,
                    CategoryID=1,
                    Name="Salade de pâte (Coquillete,legumes,thon,maïs,oeuf)",
                    Prix= 30,
                    ImageUrl="salade_coquillette.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=12,
                    CategoryID=1,
                    Name="Salade de laitue (laitue,legumes,thon,spaghettis,oeuf)",
                    Prix= 30,
                    ImageUrl="salade_laitue.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=13,
                    CategoryID=1,
                    Name="Spaghetti blanc (Poulet)",
                    Prix= 35,
                    ImageUrl="spaghetti_blanc.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=14,
                    CategoryID=1,
                    Name="Spaghetti rouge (Poulet)",
                    Prix= 35,
                    ImageUrl="spaghetti_rouge.jpeg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=15,
                    CategoryID=1,
                    Name="Frittes au poulet",
                    Prix= 30,
                    ImageUrl="fritte_au_poulet.jpg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
                 new FoodItem
                {
                    ProductID=16,
                    CategoryID=1,
                    Name="Couscous au poulet",
                    Prix= 40,
                    ImageUrl="",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },new FoodItem
                {
                    ProductID=17,
                    CategoryID=1,
                    Name="Fufu au manioc",
                    Prix= 40,
                    ImageUrl="fufu.jpeg",
                    Description="sfsgdgqefsffdg",
                    Rating="4.8",
                    RatingDetail="(121 raitings)"
                },
            };
        }

        public async Task AddFoodItemsDataAsync()
        {
            try
            {
                foreach(var item in FoodItems)
                {
                    await client.Child("FoodItems").PostAsync(new FoodItem
                    {
                        ProductID = item.ProductID,
                        CategoryID =item.CategoryID,
                        Name = item.Name,
                        Prix = item.Prix,
                        ImageUrl = item.ImageUrl,
                        Description = item.Description,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail
                    });
                }

            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ERROR LORS DE L'ENREGISTREMENT DANS LA BASE DE DONNEES", ex.Message, "ok");
            }
        }
    }
}
