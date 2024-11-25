using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Interfaces;

public interface IVehicle
{
    public double FuelQuantity { get; }
    public double FuelConsumption { get; }
    public int TankCapacity { get; }

    string Drive(double distance, bool empty);

    bool Refuel(double liters);
}
