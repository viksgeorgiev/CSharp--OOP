﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models;

public class Car : BaseVehicle
{
    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption)
    {       
    }

    public override double FuelConsumption => base.FuelConsumption + 0.9;

    public override void Refuel(double liters)
    {
        base.Refuel(liters);
    }
}
