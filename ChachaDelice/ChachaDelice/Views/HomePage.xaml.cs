using ChachaDelice.Models;
using ChachaDelice.ViewModels;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChachaDelice.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            
            InitializeComponent();
          //  HPVM = Resources["vm"] as HomePageVM;
        }
      

        private async void CVFoods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedFood = e.CurrentSelection.FirstOrDefault() as FoodItem;
            if (selectedFood == null) return;
            await Navigation.PushModalAsync(new FoodDetailsPage(selectedFood));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}