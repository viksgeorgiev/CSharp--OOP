using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models;

public class Bus : BaseVehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, int tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    protected override double ConsumptionIncrease => 1.4;

    
}
