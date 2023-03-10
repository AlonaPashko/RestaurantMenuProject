using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Interfaces
{
    internal interface ICurrency
    {
        public string Name { get; set; }
        public double CourseRelZloty { get; set; }
    }
}
