using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data.Models
{
    public class Vehicle
    {
        public string VIN { get; set; }
        public int ModelYear { get; set; }
        public string Colour { get; set; }
        public int ModelID { get; set; }

        public virtual Model Model { get; set; }
    }
}
