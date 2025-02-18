using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Square : IShape
    {
        public double Side { get; set; }        

        public double CalculateArea()
        {
            return this.Side * this.Side;
        }
    }


}
