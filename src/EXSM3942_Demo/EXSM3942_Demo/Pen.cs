﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal class Pen : WritingUtensil
    {
        public Pen(string brand, string colour)
        {
            Brand = brand;
            Colour = colour;
        }


        public string Colour { get; set; }
        private double _inkLevel = 100;
        public double InkLevel
        {
            get => _inkLevel; 
            set
            {
                if (value < 0)
                {
                    throw new Exception("The pen has insufficient ink!");
                }
                else
                {
                    _inkLevel = value;
                }
            }

        }
        public override void Write(int letterCount)
        {
            InkLevel -= letterCount * 0.5;
        }
    }
}
