using System.Linq.Expressions;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles
{
    public class Program
    {
        public static void Main()
        {
            string[] carInput = Console.ReadLine()!.Split(" ");
            IVehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), int.Parse(carInput[3]));

            string[] truckInput = Console.ReadLine()!.Split(" ");
            IVehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), int.Parse(truckInput[3]));

            string[] busInput = Console.ReadLine()!.Split(" ");
            IVehicle bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), int.Parse(busInput[3]));
            int linesOfCommands = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < linesOfCommands; i++)
            {
                string[] command = Console.ReadLine()!.Split();

                string action = command[0];
                string typeOfVehicle = command[1];
                double quantity = double.Parse(command[2]);

                IVehicle vehicleType = GetVehicle(typeOfVehicle, car, truck, bus);

                if (action == "Drive")
                {
                    Console.WriteLine(vehicleType.Drive(quantity, false));
                }
                else if (action == "DriveEmpty")
                {
                    Console.WriteLine(vehicleType.Drive(quantity, true));
                }
                else if (action == "Refuel")
                {
                    try
                    {
                        var liters = double.Parse(command[2]);
                        if (!vehicleType.Refuel(liters)) Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static IVehicle GetVehicle(string typeOfVehicle, IVehicle car, IVehicle truck, IVehicle bus)
        => typeOfVehicle switch
        {
            "Car" => car,
            "Truck" => truck,
            "Bus" => bus,
            _ => throw new NotImplementedException("Invalid vehicle")
        };
    }
}
