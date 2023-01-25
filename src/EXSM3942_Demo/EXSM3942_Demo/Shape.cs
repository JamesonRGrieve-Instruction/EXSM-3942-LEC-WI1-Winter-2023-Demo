using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal abstract class Shape
    {
        public abstract double Area { get; }
        public abstract double Perimeter { get; }
        public abstract Rectangle Contain();
    }
}
