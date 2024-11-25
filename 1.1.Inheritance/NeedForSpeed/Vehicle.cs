using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NeedForSpeed;

public class Vehicle
{
    public Vehicle(int horsePower, double fuel)
    {
        Fuel = fuel;
        HorsePower = horsePower;   
    }

    public virtual double FuelConsumption { get; } = 1.25;
    public double Fuel { get; private set; }

    public int HorsePower { get; }

    public void Drive(double kilometers)
    {
        this.Fuel -= this.FuelConsumption * kilometers;
    }
}
