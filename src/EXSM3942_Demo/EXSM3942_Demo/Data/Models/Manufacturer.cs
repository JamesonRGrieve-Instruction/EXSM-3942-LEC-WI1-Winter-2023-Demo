using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXSM3942_Demo.Data.Models
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
