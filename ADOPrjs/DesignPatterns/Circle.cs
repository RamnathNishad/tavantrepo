using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Circle :IShape
    {
        public double Radius {  get; set; }

        public double CalculateArea()
        {
            return 3.14 * this.Radius * this.Radius;
        }
    }
}
