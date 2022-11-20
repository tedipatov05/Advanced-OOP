using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] busInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Car car = (Car)CreateVehicle(carInfo);
            Truck truck = (Truck)CreateVehicle(truckInfo);
            Bus bus = (Bus)CreateVehicle(busInfo);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string toDo = command[0];
                string type = command[1];

                try
                {
                    switch (toDo)
                    {
                        case "Drive":
                            double distance = double.Parse(command[2]);
                            if (type == "Car")
                            {
                                car.Drive(distance);
                            }
                            else if (type == "Truck")
                            {
                                truck.Drive(distance);
                            }
                            else if (type == "Bus")
                            {
                                bus.Drive(distance);
                            }
                            break;
                        case "Refuel":
                            double liters = double.Parse(command[2]);
                            if (type == "Car")
                            {
                                car.Refuel(liters);
                            }
                            else if (type == "Truck")
                            {
                                truck.Refuel(liters);
                            }
                            else if (type == "Bus")
                            {
                                bus.Refuel(liters);
                            }
                            break;
                        case "DriveEmpty":
                            double busDistance = double.Parse(command[2]);
                            bus.DriveEmpty(busDistance);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        public static Vehicle CreateVehicle(string[] vehicleInfo)
        {
            double initialFuelQuantity = double.Parse(vehicleInfo[1]);
            double litersPerKilometer = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            string type = vehicleInfo[0];

            switch (type)
            {
                case "Car":
                    Car car = new Car(initialFuelQuantity, litersPerKilometer, tankCapacity);
                    return car;
                case "Truck":
                    Truck truck = new Truck(initialFuelQuantity, litersPerKilometer, tankCapacity);
                    return truck;
                case "Bus":
                    Bus bus = new Bus(initialFuelQuantity, litersPerKilometer, tankCapacity);
                    return bus;
                default:
                    throw new Exception();
            }
        }
    }
    
}
