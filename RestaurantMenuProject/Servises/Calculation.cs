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
            return "TOTAL AMOUNT\n\n" + PrintDictionary.PrintDict(TotalAmount()) +
                "\nPRICE LIST\n\n" + PrintDictionary.PrintDict(Prices.PriceList) +
                "\nTOTAL COST\n\n" + PrintDictionary.PrintDict(TotalCost());
        }
        public Dictionary<string, double> TotalAmount()
        {
            foreach (var ingr in Ingredients.Ingredients)
            {
                if (Ingredients.Ingredients.TryGetValue(ingr.Key, out double amount))
                {
                    Ingredients.Ingredients[ingr.Key] = amount / index;
                }
            }
            return Ingredients.Ingredients;
        }
        public Dictionary<string, double> TotalCost()
        {
            List<KeyValuePair<string, double>> ingrList = Ingredients.Ingredients.ToList<KeyValuePair<string, double>>();
            List<KeyValuePair<string, double>> prList = Prices.PriceList.ToList<KeyValuePair<string, double>>();
            Dictionary<string, double> totalCost = new Dictionary<string, double>();
            double totalCostValue = 0;

            for (int i = 0, j = 0; i < ingrList.Count; i++, j++)
            {
                if (ingrList[i].Key == prList[j].Key)
                {
                    totalCostValue = Math.Round((ingrList[i].Value * prList[j].Value), 4);
                    totalCost.Add(ingrList[i].Key, totalCostValue);
                    totalCostValue = 0;
                }
            }
            return totalCost;
        }

    }
}
