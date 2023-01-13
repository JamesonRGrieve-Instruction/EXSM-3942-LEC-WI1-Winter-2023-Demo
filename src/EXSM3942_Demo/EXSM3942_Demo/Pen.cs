using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Pen
    {
        public Pen(string brand, string colour)
        {
            Brand = brand;
            Colour = colour;
        }

        public string Brand { get; set; }
        public string Colour { get; set; }
        private decimal _inkLevel = 100;
        public decimal InkLevel {
            get => _inkLevel;
            set
            {
                // If the incoming new value for InkLevel is to be less than 0.
                if (value < 0)
                {
                    throw new Exception("Ink level must not be below zero.");
                }
                else
                {
                    _inkLevel = value;  
                }
            }
        }

        public void Write(int letterCount)
        {
            InkLevel -= letterCount * 0.5m;
        }
    }
}
