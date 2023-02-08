using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data.Models
{
    public class Model
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
