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
            IVehicle car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));

            string[] truckInput = Console.ReadLine()!.Split(" ");
            IVehicle truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));

            int linesOfCommands = int.Parse(Console.ReadLine()!);

            for (int i = 0; i < linesOfCommands; i++)
            {
                string[] command = Console.ReadLine()!.Split();

                string action = command[0];
                string typeOfVehicle = command[1];
                double quantity = double.Parse(command[2]);

                IVehicle vehicleType = GetVehicle(typeOfVehicle, car, truck);

                if(action == "Drive")
                {
                    Console.WriteLine(vehicleType.Drive(quantity));
                }
                else if (action == "Refuel")
                {
                    vehicleType.Refuel(quantity);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static IVehicle GetVehicle(string typeOfVehicle, IVehicle car, IVehicle truck)
        => typeOfVehicle switch
        {
            "Car" => car,
            "Truck" => truck,
            _ => throw new NotImplementedException("Invalid vehicle")
        };
    }
}
