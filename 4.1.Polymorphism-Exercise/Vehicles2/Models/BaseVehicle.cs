using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interfaces;

namespace Vehicles.Models;

public abstract class BaseVehicle : IVehicle
{
    public BaseVehicle(double fuelQuantity, double fuelConsumption, int tankCapacity)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;

        if (fuelQuantity > tankCapacity)
        {
            TankCapacity = 0;
        }
        else { TankCapacity = tankCapacity; }

    }

    public double FuelQuantity { get; private set; }
    public virtual double FuelConsumption { get; }
    public int TankCapacity { get; }

    protected virtual double ConsumptionIncrease { get; }

    public string Drive(double distance, bool empty)
    {
        double fuelConsumption = this.FuelConsumption;
        if (!empty) { fuelConsumption += ConsumptionIncrease; }

        double requiredFuel = distance * fuelConsumption;
       
        if (this.FuelQuantity < requiredFuel) { return $"{this.GetType().Name} needs refueling"; };

        this.FuelQuantity -= requiredFuel;

        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual bool Refuel(double liters)
    {
        if (liters <= 0) throw new ArgumentException("Fuel must be a positive number");

        var newFuelQuantity = this.FuelQuantity + liters;
        if (newFuelQuantity > this.TankCapacity) return false;

        this.FuelQuantity += liters;
        return true;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
    }
}
