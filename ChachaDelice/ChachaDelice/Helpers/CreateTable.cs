using ChachaDelice.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChachaDelice.Helpers
{
   public class CreateTable
    {
        public bool CreationDeLaBaseDeDonnee()
        {
            try
            {
                var connection = DependencyService.Get<ISQLite>().GetConnection();

                connection.CreateTable<infosFood>();
                connection.Close();
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
