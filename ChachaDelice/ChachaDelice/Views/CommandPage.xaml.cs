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
    public partial class CommandPage : ContentPage
    {
        private FoodItem food;

        public CommandPage()
        {
            InitializeComponent();
        }

        public CommandPage(FoodItem selectedFood)
        {
            InitializeComponent();
            this.food = selectedFood;
            this.BindingContext = new CommandPageVM(food);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new HomePage());
        }

        private void MapsBut_Clicked(object sender, EventArgs e)
        {

        }

        

    }
}