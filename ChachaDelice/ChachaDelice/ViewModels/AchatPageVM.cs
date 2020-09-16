using ChachaDelice.Models;
using ChachaDelice.Services;
using ChachaDelice.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChachaDelice.ViewModels
{
  public  class AchatPageVM : BaseViewModel
    {
        public ObservableCollection<Achat> AchatsList { get; set; }

        private decimal _TotalCost;

        public decimal TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; OnPropertyChanged(); }
        }

        public Command PlaceOrdersCommand { get; set; }

        public AchatPageVM()
        {
            AchatsList = new ObservableCollection<Achat>();
            GetFoodInBD();
            PlaceOrdersCommand = new Command(async () => await PlaceOrdersCommandAsync());
        }

        private async Task PlaceOrdersCommandAsync()
        {
            var od = new OrderService();
         var orderIdString=  await od.PlaceOrderAsync();
            removeItemInBD() ;
            await Application.Current.MainPage.Navigation.PushModalAsync(new AfterOrderPage(orderIdString));
        }

        void removeItemInBD()
        {
            var BS = new BDservices();
            BS.removeElementInBD();
        }
        private void GetFoodInBD()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<infosFood>().ToList();
            AchatsList.Clear();
            foreach(var item in data)
            {
               var a= new Achat()
                {
                    Name=item.Name,
                    ProductID= item.ProductID,
                    Prix= item.Prix,
                    Quantity=item.Quantity,
                    Cost= item.Prix* item.Quantity

                };
                TotalCost += item.Prix * item.Quantity;
                AchatsList.Add(a);
            }
        }
    }
}
