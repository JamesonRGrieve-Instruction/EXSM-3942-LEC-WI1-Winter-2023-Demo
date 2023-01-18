using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Circle
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get; set; }
        public double Diameter => Radius*2;
        public double Area => Math.PI*Math.Pow(Radius, 2);
        public double Circumference => Math.PI*Diameter;
    }
}
