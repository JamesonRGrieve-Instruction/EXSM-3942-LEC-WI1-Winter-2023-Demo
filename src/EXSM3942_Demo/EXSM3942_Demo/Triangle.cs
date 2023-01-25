using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Triangle : Shape
    {
        public Triangle(double bottom, double height)
        {
            Base = bottom;
            Height = height;
        }
        public double Base { get; set; }
        public double Height { get; set; }
        public override double Area => Base * Height / 2;

        public override double Perimeter => Math.Sqrt(Math.Pow(Base / 2, 2) + Math.Pow(Height, 2)) * 2 + Base;

        public override Rectangle Contain()
        {
            return new Rectangle(Math.Max(Base, Height), Math.Max(Base, Height));
        }
    }
}
