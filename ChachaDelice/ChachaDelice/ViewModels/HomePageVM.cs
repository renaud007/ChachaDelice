using ChachaDelice.Models;
using ChachaDelice.Services;
using ChachaDelice.Views;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChachaDelice.ViewModels
{
   public class HomePageVM : BaseViewModel
    {
        public ObservableCollection<FoodItem> FoodItems { get; set; }
        FirebaseClient client;

        private int _NombreDelementDansLaList;

        public int NombreDelementDansLaList
        {
            get { return _NombreDelementDansLaList; }
            set { _NombreDelementDansLaList = value; OnPropertyChanged(); }
        }

        public Command GoToAchatList { get; set; }


        public HomePageVM()
        {
            client = new FirebaseClient("https://chachadelice-13c0e.firebaseio.com/");
            FoodItems = new ObservableCollection<FoodItem>();
            var BDs = new BDservices();
            NombreDelementDansLaList= BDs.countElementInBD();
            GetFoodItems();

            GoToAchatList = new Command( async() => await GoToAchatListAsync());
        }

        private async Task GoToAchatListAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new AchatPage());
        }

        private async void GetFoodItems()
        {
            var foods = new FoodItemService();
           var items= await foods.GetFoodItemsAsync();
            foreach(var item in items)
            {
                FoodItems.Add(item);
            }
        }
    }
}
