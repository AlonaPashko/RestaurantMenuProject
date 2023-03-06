using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantMenuProject.Enums;

namespace RestaurantMenuProject.Interfaces
{
    internal interface ICalculation
    {
        public CurrencyEnum Currency { get; set; }
        public IIngredientList Ingredients { get; set; }
        public IPriceList Prices { get; set; }

        public Dictionary<string, double> TotalAmount();
        public Dictionary<string, double> TotalCost();
        



    }
}
