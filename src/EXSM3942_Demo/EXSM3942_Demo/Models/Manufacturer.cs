using System;
using System.Collections.Generic;

namespace EXSM3942_Demo.Models;

public partial class Manufacturer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Dealership> Dealerships { get; } = new List<Dealership>();

    public virtual ICollection<Model> Models { get; } = new List<Model>();
}
