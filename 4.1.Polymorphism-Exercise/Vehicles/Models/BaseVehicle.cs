using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interfaces;

namespace Vehicles.Models;

public abstract class BaseVehicle : IVehicle
{
    public BaseVehicle(double fuelQuantity, double fuelConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity { get; private set; }
    public virtual double FuelConsumption { get; }

    public string Drive(double distance)
    {
        double requiredFuel = distance * this.FuelConsumption;

        if (this.FuelQuantity < requiredFuel) { return $"{this.GetType().Name} needs refueling"; };

        this.FuelQuantity -= requiredFuel;

        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}
