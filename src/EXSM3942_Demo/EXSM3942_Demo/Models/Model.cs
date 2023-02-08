using System;
using System.Collections.Generic;

namespace EXSM3942_Demo.Models;

public partial class Model
{
    public int Id { get; set; }

    public int Manufacturerid { get; set; }

    public string Name { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
