using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Pencil : WritingUtensil
    {
        public Pencil(string brand)
        {
            Brand = brand;
        }
        private double _length = 100;
        public double Length {
            get => _length;
            set
            {
                if (value < 0)
                {
                    throw new Exception("The pencil has insufficient length!");
                }
                else
                {
                    _length = value;
                }
            }

        }
        public override void Write(int letterCount)
        {
            Length -= letterCount * 0.25;
        }
    }
}
