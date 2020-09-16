using ChachaDelice.Models;
using ChachaDelice.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChachaDelice.ViewModels
{
   public class CommandPageVM : BaseViewModel
    {
        private int _NombreDeCommand;

        public int NombreDeCommand
        {
            get { return _NombreDeCommand; }
            set { _NombreDeCommand = value; OnPropertyChanged(); }
        }


        public Command RetraitItem { get; set; }
        public Command AjoutItem { get; set; }
        public Command AjoutAchat { get; set; }
        public Command VoirList { get; set; }
        

        private FoodItem _SelectedFood;

        public FoodItem SelectedFood
        {
            get { return _SelectedFood; }
            set { _SelectedFood = value; OnPropertyChanged(); }
        }

        public CommandPageVM( FoodItem selectedFood)
        {
            SelectedFood = selectedFood;
            RetraitItem = new Command(async () => await RetraitItemAsync());
            
            AjoutItem = new Command(async () => AjoutItemItemAsync());
            AjoutAchat = new Command(() => AjoutAchatCart());
            VoirList = new Command(() => VoirListAsync());
        }

        private async void VoirListAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new ChachaDelice.Views.AchatPage());
        }

        private async void AjoutAchatCart()
        {
            if (NombreDeCommand == 0)
            {
                await Application.Current.MainPage.DisplayAlert(";)", "Votre commande ne peut pas être nulle", "Ajouter une command");
            }
            else
            {
                var AjoutAchat = new BDservices();
                AjoutAchat.AjoutCommand(SelectedFood, NombreDeCommand);
                await Application.Current.MainPage.DisplayAlert("Operation reussie", "Votre commande a bien  été enregistrée dans la liste d'achat", "ok");
            }
        }

        private async void AjoutItemItemAsync()
        {
            NombreDeCommand++;
            if (NombreDeCommand > 9) NombreDeCommand = 10;
           
        }

        private async Task RetraitItemAsync()
        {
            NombreDeCommand--;
            if (NombreDeCommand <= 1) NombreDeCommand = 0;
        }
    }
}
