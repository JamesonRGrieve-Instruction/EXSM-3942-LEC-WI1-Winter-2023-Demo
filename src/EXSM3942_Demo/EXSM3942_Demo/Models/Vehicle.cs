using System;
using System.Collections.Generic;

namespace EXSM3942_Demo.Models;

public partial class Vehicle
{
    public string Vin { get; set; } = null!;

    public int Modelid { get; set; }

    public int DealershipId { get; set; }

    public string Trimlevel { get; set; } = null!;

    public virtual Dealership Dealership { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;
}
