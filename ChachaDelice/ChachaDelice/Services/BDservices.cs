using ChachaDelice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChachaDelice.Services
{
  public class BDservices
    {
       public void AjoutCommand( FoodItem SelectedFood , int nomDeCommand)
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                var fi = new infosFood() {
                    ProductID = SelectedFood.ProductID,
                    Name = SelectedFood.Name,
                    Prix = SelectedFood.Prix,
                    Quantity = nomDeCommand
                };

              
                var item = cn.Table<infosFood>().ToList().FirstOrDefault(c => c.ProductID == SelectedFood.ProductID);
                if (item == null)
                {
                    cn.Insert(fi);
                    cn.Commit();
                    cn.Close();
                }
            }catch(Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("ERREUR", ex.Message, "ok");
            }
            finally
            {
                cn.Close();
            }
        }

        public int countElementInBD()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var nmbre= cn.Table<infosFood>().Count();
            cn.Close();
            return nmbre;
        }

        public void removeElementInBD()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<infosFood>();
            cn.Commit();
            cn.Close();

        }
    }
}
