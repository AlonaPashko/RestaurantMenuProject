using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantMenuProject.Interfaces
{
    internal interface ICalculation
    {
        public IIngredientList Ingredients { get; set; }
        public IPriceList Prices { get; set; }

        public Dictionary<string, double> TotalAmount();
        public Dictionary<string, double> TotalCost();
        public Dictionary<string, double> TotalCostWithCurrency(ICurrency currency);
    }
}
