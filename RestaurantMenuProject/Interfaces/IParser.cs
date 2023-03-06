using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.Interfaces
{
    internal interface IParser
    {
        public IExpressionReader Reader { get; set; }

        public Dictionary<string, double> Parse();
    }
}
