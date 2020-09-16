using ChachaDelice.Models;
using ChachaDelice.ViewModels;
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
    public partial class FoodDetailsPage : ContentPage
    {
       

        public FoodDetailsPage()
        {
            InitializeComponent();
        }
        public FoodItem food;
        public FoodDetailsPage(FoodItem selectedFood)
        {
            InitializeComponent();
            BindingContext = new FoodDetailsVM(selectedFood);
            food = selectedFood;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CommandPage(food));
        }
    }
}