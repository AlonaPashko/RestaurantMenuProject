using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal class Menu
    {
        public Dictionary<string, double> Products { get; set; }

        public Menu()
        {
            Products = new Dictionary<string, double>();
        }
        public string PrintDictionary()
        {
            string line = "";
            foreach (var item in Products)
            {
                line += item.Key + " - "
                    + item.Value.ToString() + "\n";
            }
            return line;
        }
        public override string ToString()
        {
            return "Total amount products for restaurant: \n\n" + PrintDictionary();
        }
        private List<string> GetProducts(List<string> listFromFile)
        {
            List<string> productsList = new List<string>();
            for (int i = 0; i < listFromFile.Count; i++)
            {
                if (IsDigit(listFromFile[i]) == true)
                {
                    productsList.Add(listFromFile[i]);
                }
            }
            return productsList;
        }
        private bool IsDigit(string str)
        {
            if (str.Any(char.IsDigit))
            {
                return true;
            }
            return false;
        }
        private bool IsPunctuation(string str)
        {
            if (str.Any(char.IsPunctuation))
            {
                return true;
            }
            return false;
        }
        private bool IsSameKey(string str)
        {
            foreach (var product in Products)
            {
                if (Products.ContainsKey(str))
                {
                    return true;
                }
            }
            return false;
        }
        private Dictionary<string, double> AddValuesForSameProduct(string str, double num)
        {
            foreach (var product in Products)
            {
                if (product.Key == str)
                {
                    double newValue = product.Value + num;
                    Products.Remove(product.Key);
                    Products.Add(str, newValue);
                    break;
                }
            }
            return Products;
        }

        public Dictionary<string, double> MakeDictionaryFromList(List<string> listFromFile)
        {
            List<string> productsList = GetProducts(listFromFile);

            for (int i = 0; i < productsList.Count; i++)
            {
                string[] arr = productsList[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                string position = arr[0].ToLower();
                double value = double.Parse(arr[1]);

                if (!IsSameKey(position))
                {
                    Products.Add(position, value);
                }
                else
                {
                    Products = AddValuesForSameProduct(position, value);
                }
            }
            return Products;
        }

    }
}
