using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Interfaces
{
    internal interface IPriceList
    {
        Dictionary<string, double> PriceList { get; set; }

        public void AddPosition(string name, double price);
        public void RemovePosition(string name);
    }
}
