using RestaurantMenuProject.FileOperations;
using RestaurantMenuProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Servises
{
    internal class Currency : ICurrency
    {
        public string Name { get; set; }
        public double CourseRelZloty { get; set; }
        Dictionary<string, double> Courses { get; set; }

        public Currency()
        {
            Name = "polish zloty";
            CourseRelZloty = 1;
            Courses = new Dictionary<string, double>();
        }

        public Currency(string name, double course)
        {
            Name = name;
            CourseRelZloty = course;
            Courses = new Dictionary<string, double>();
        }
        public Currency(string filePath) 
        {
            FileParser fileParser = new FileParser(filePath);
            Courses = fileParser.Parse();
        }
        public override string ToString()
        {
            return "Available currencies:\n\npolish zloty\n" + PrintDictionary.PrintDict(Courses);
        }
    }
}
