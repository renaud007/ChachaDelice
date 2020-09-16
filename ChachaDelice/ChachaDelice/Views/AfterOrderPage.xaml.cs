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
    public partial class AfterOrderPage : ContentPage
    {
        public AfterOrderPage( string orderId)
        {
            InitializeComponent();
            LabelOrderID.Text = orderId;
        }

     
        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomePage());
        }

        private async void voirProduits_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}