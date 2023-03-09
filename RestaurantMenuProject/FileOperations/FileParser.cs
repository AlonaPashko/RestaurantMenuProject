using RestaurantMenuProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.FileOperations
{
    internal class FileParser : IParser
    {
        public IExpressionReader Reader { get; set; }

        public FileParser(string path)
        {
            Reader = new FileReader(path);
        }

        public Dictionary<string, double> Parse() //add a TryParse scenarium
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            List<string> list = Reader.ReadExpression();

            for (int i = 0; i < list.Count; i++)
            {
                if (IsDigit(list[i]))
                {
                    string[] seperators = { ",", "-", ":", " " };
                    string[] arr = list[i].Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                    string key = arr[0].ToLower();
                    double value = double.Parse(arr[1]);
                    
                    if (!dict.ContainsKey(key))
                    {
                        dict.Add(key, value);
                    }
                    else
                    {
                        foreach (var item in dict)
                        {
                            if (item.Key == key)
                            {
                                value += item.Value;
                            }
                        }
                        dict.Remove(key);
                        dict.Add(key, value);
                    }
                }
            }
            return dict;

        }
        private bool IsDigit(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    return true;
                }
            }
            return false;
        }
       
    }
}
