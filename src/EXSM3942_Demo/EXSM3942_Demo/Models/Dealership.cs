using System;
using System.Collections.Generic;

namespace EXSM3942_Demo.Models;

public partial class Dealership
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Manufacturerid { get; set; }

    public string Address { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public virtual Manufacturer Manufacturer { get; set; } = null!;

    public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
}
