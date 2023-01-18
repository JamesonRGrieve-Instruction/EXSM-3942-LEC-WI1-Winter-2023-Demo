using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Rectangle
    {
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;  
        }
        public double Length { get; set; }
        public double Width { get; set; }

        public bool IsSquare => Length == Width;
        public double Area => Length * Width;
        public double Perimeter => Length*2+Width*2;

        public Rectangle ContainWithSquare()
        {
           return new Rectangle(Math.Max(Length, Width), Math.Max(Length, Width));
        }
    }
}
