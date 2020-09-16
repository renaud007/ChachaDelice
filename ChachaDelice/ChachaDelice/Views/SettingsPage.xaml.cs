using ChachaDelice.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChachaDelice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void buta_ddDataToDatabase_Clicked(object sender, EventArgs e)
        {
            var addFood = new AddFoodItem();
            await addFood.AddFoodItemsDataAsync();
        }
    }
}