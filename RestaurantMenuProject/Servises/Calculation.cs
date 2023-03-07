using RestaurantMenuProject.Enums;
using RestaurantMenuProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal class Calculation : ICalculation
    {
        public CurrencyEnum Currency { get; set; }
        public IIngredientList Ingredients { get; set; }
        public IPriceList Prices { get; set; }
        const int index = 1000; //const for convert weight in gr into kg

        public Calculation()
        {
            Ingredients = new IngredientList();
            Prices = new PriceListWrapper();
        }
        public Calculation(string ingrFilePath, string priceFilePath)
        {
            Ingredients = new IngredientList(ingrFilePath);
            Prices = new PriceListWrapper(priceFilePath);
        }
        public Calculation(IngredientList ingredients, PriceListWrapper priceList)
        {
            Ingredients = ingredients; 
            Prices = priceList;
        }
        public override string ToString()
        {
            return Ingredients.ToString();
        }
        public Dictionary<string, double> TotalAmount()
        {
            foreach (var ingr in Ingredients.Ingredients)
            {
                if(Ingredients.Ingredients.TryGetValue(ingr.Key, out double amount))
                {
                    Ingredients.Ingredients[ingr.Key] = amount / index;
                }
            }
            return Ingredients.Ingredients;
        }
        public Dictionary<string, double> TotalCost()
        {
           //to do step by step and check 
        }
       
        public string PrintTotalAmount()
        {
            Ingredients.Ingredients = TotalAmount();
            string str = "Ingredient's total amount in kg\n";
            str = str + "-----------------------\n" + Ingredients;

            return str;
        }
        public string PrintTotalCost()
        {
            Prices.PriceList = TotalCost();
            string str = "------------------------\n";
            str = str + "Ingredient's total cost in Polish złoty\n" + Prices;
            return str;
        }
    }
}
