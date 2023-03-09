using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal static class PrintDictionary
    {
        public static string PrintDict(Dictionary<string, double> dict)
        {
            string line = "";
            foreach (var item in dict)
            {
                line += item.Key + " - " + item.Value.ToString() + "\n";
            }
            return line;
        }
    }
}
