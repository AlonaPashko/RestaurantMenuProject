
using RestaurantMenuProject.FileOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal class StartCalculation
    {
        public Currency Currency { get; set; }
        Dictionary<string, double> Courses { get; set; }
        public Calculation Calculation { get; set; }

        public StartCalculation()
        {
            Currency = new Currency();
            Calculation = new Calculation();
        }

        public StartCalculation(string currFilePath, string ingrFilePath, string priceFilePath)
        {
            FileParser fileParser = new FileParser(currFilePath);
            Courses = fileParser.Parse();
            Calculation = new Calculation(ingrFilePath, priceFilePath);
            Currency = CurrencyChoice();
        }
        public StartCalculation(Currency curr, Calculation calc)
        {
            Calculation = calc;
            Currency = curr;
        }

        public Currency CurrencyChoice()
        {
            Console.WriteLine("Please, choose the currency:\n\n" + PrintDictionary.PrintDict(Courses));

            string userInput = Console.ReadLine().ToLower();

            if (userInput != null)
            {
                switch (userInput)
                {
                    case "hryvnia":
                        {
                            foreach (var item in Courses)
                            {
                                if (item.Key == "hryvnia")
                                {
                                    Console.WriteLine("Hryvnia UKR is selected");
                                    return new Currency(item.Key, item.Value);
                                }
                            }
                            break;
                        }
                    case "dolar":
                        {
                            foreach (var item in Courses)
                            {
                                if (item.Key == "dolar")
                                {
                                    Console.WriteLine("Dolar USA is selected");
                                    return new Currency(item.Key, item.Value);
                                }
                            }
                            break;
                        }
                    case "euro":
                        {
                            foreach (var item in Courses)
                            {
                                if (item.Key == "euro")
                                {
                                    Console.WriteLine("Euro is selected");
                                    return new Currency(item.Key, item.Value);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Polish ZL is a default value of currency");
                            return new Currency();
                        }
                        
                        
                }

            }
            return CurrencyChoice();
        }
        public override string ToString()
        {
            return Calculation.ToString() + "\nTOTAL COST IN " + Currency.Name +":\n\n"
                + PrintDictionary.PrintDict(Calculation.TotalCostWithCurrency(Currency));
        }
    }
}
