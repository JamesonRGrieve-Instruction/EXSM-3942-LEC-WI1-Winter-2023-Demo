using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo
{
    internal abstract class WritingUtensil
    {
        public string Brand { get; set; }
        public abstract void Write(int letterCount);
    }
}
