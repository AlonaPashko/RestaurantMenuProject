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
        public IIngredientList Ingredients { get; set; }
        public IPriceList Prices { get; set; }
        public CurrencyEnum Currency { get; set; }

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
            Currency = CurrencyEnum.Hryvnia;
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
                "\nTOTAL COST\n\n" + PrintDictionary.PrintDict(TotalCost()) +
                "\nTOTAL COST IN HRYVNIA\n\n" + PrintDictionary.PrintDict(TotalCostWithCurrency());
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

        public Dictionary<string, double> TotalCostWithCurrency()
        {
            switch (Currency)
            {
                case CurrencyEnum.Hryvnia:
                    {
                        double course = 8.41;
                        return GetCurrDictionary(course);
                    }
                case CurrencyEnum.Dolar:
                    {
                        double course = 0.21;
                        return GetCurrDictionary(course);
                    }
                case CurrencyEnum.Euro:
                    {
                        double course = 0.23;
                        return GetCurrDictionary(course);
                    }
                default:  return TotalCost();
            }
            //add a value of curr from file (fix value change to variable)
        }
        private Dictionary<string, double> GetCurrDictionary(double course)
        {
            List<KeyValuePair<string, double>> totalCost = TotalCost().ToList<KeyValuePair<string, double>>();
            Dictionary<string, double> currDict = new Dictionary<string, double>();
            double currDictValue = 0;

            for (int i = 0; i < totalCost.Count; i++)
            {
                currDictValue = Math.Round((totalCost[i].Value * course), 4);
                currDict.Add(totalCost[i].Key, currDictValue);
                currDictValue = 0;
            }
            return currDict;
        }
    }
}
