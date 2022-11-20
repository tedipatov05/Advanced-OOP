using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double CAR_CONSUMPTION_DURING_SUMMER = 0.9;

        public Car(double fuel, double consumption, double tankCapacity)
        {
            this.FuelQuantity = fuel > tankCapacity ? 0 : fuel;
            this.ConsumprionPerKilometer = consumption + CAR_CONSUMPTION_DURING_SUMMER;
            this.TankCapacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            double consumedFuel = distance * this.ConsumprionPerKilometer;
            if (this.FuelQuantity - consumedFuel >= 0)
            {
                Console.WriteLine($"Car travelled {distance} km");
                this.FuelQuantity -= consumedFuel;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }
    }
}
