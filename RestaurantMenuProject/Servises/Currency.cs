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
        

        public Currency()
        {
            Name = "Polish ZL";
            CourseRelZloty = 1;
        }

        public Currency(string name, double course)
        {
            Name = name;
            CourseRelZloty = course;
        }

        public override string ToString()
        {
            return "Currency: " + Name + "Course relatively polish zloty: " 
                + CourseRelZloty.ToString();
        }
    }
}
