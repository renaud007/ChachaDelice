using ChachaDelice.Helpers;
using ChachaDelice.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChachaDelice
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new string[] { "Shapes_Experimental", "CarouselView_Experimental", "MediaElement_Experimental", "SwipeView_Experimental" });

            InitializeComponent();

            var hasKey = Preferences.ContainsKey("BdCreated");

            if(!hasKey)
            {
                var bd = new CreateTable();
                var result =  bd.CreationDeLaBaseDeDonnee();
               

                if (result)
                {
                    Preferences.Set("BdCreated", true);
                }
                else
                {
                    MainPage = new NavigationPage(new Lottie());
                }
            }



            //MainPage = new NavigationPage(new Lottie());
             MainPage = new NavigationPage(new HomePage());
            // MainPage = new NavigationPage(new SettingsPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
