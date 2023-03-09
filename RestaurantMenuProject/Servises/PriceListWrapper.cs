using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal class PriceListWrapper : IPriceList
    {
        public Dictionary<string, double> PriceList { get; set; }

        public PriceListWrapper()
        {
            PriceList = new Dictionary<string, double>();
        }
        public PriceListWrapper(Dictionary<string, double> price)
        {
            PriceList = price;
        }
        public PriceListWrapper(string filePath)
        {
            FileParser fileParser = new FileParser(filePath);
            PriceList = fileParser.Parse();
        }
        public override string ToString()
        {
            return "Price list:\n\n" + PrintDictionary.PrintDict(PriceList);
        }

        public void AddPosition(string name, double price)
        {
            PriceList.Add(name, price);
        }

        public void RemovePosition(string name)
        {
            PriceList.Remove(name);
        }

    }
}
