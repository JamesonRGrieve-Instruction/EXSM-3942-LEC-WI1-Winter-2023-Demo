using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Triangle
    {
        public Triangle(double bottom, double height)
        {
            Base = bottom;
            Height = height;
        }
        public double Base { get; set; }
        public double Height { get; set; }
        public double Area => Base*Height/2;

        public Rectangle ContainWithRectangle()
        {
            return new Rectangle(Base, Height);
        }
    }
}
