using ChachaDelice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChachaDelice.ViewModels
{
   public class FoodDetailsVM : BaseViewModel
    {

        private FoodItem _SelectedFood;

        public FoodItem SelectedFood
        {
            get { return _SelectedFood; }
            set { _SelectedFood = value; OnPropertyChanged(); }
        }


        public FoodDetailsVM(FoodItem selectedFood)
        {
            SelectedFood = selectedFood;   
        }
    }
}
