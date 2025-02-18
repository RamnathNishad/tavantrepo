using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class AreaCalculator
    {
        public double CalculateArea(IShape shape)
        {
            double area=0;    
            area = shape.CalculateArea();
            return area;
        }
    }
}
