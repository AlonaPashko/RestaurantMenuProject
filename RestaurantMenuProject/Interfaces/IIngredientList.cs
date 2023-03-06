using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Interfaces
{
    internal interface IIngredientList
    {
        public Dictionary<string, double> Ingredients { get; set; }

        public void AddIngredient(string name, double weight);
        public void RemoveIngredient(string name);
    }
}
