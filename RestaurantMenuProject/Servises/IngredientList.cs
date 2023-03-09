using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal class IngredientList : IIngredientList
    {
        public Dictionary<string, double> Ingredients { get; set; }

        public IngredientList()
        {
            Ingredients = new Dictionary<string, double>();
        }
        public IngredientList(Dictionary<string, double> ingrs)
        {
            Ingredients = ingrs;
        }
        public IngredientList(string filePath)
        {
            FileParser fileParser = new FileParser(filePath);
            Ingredients = fileParser.Parse();
        }
        public override string ToString()
        {
            return "Ingredients list:\n\n" + PrintDictionary.PrintDict(Ingredients);
        }
        

        public void AddIngredient(string name, double weight)
        {
            Ingredients.Add(name, weight);
        }

        public void RemoveIngredient(string name)
        {
            Ingredients.Remove(name);
        }

      
    }
}
