using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Pen
    {
        public Pen(string brand, string colour, decimal inkLevel)
        {
            Brand = brand;
            Colour = colour;
            InkLevel = inkLevel;
            MaxInk = inkLevel;
        }

        public string Brand { get; set; }
        public string Colour { get; set; }
        public decimal MaxInk { get; set; }
        private decimal _inkLevel;
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
            InkLevel -= letterCount * 0.1m;
        }
        public string SummarizeInkLevel()
        {
            return $"Of the maximum {MaxInk}ml, the pen contains {InkLevel}ml of ink, which is {Math.Round(InkLevel/MaxInk*100,2)}%.";
        }
    }
}
