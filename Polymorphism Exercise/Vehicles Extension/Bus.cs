using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuel, double consumption, double tankCapacity)
        {
            this.FuelQuantity = fuel > tankCapacity ? 0 : fuel;
            this.ConsumprionPerKilometer = consumption;
            this.TankCapacity = tankCapacity;
        }

        public override void Drive(double distance)
        {
            double consumedFuel = distance * (this.ConsumprionPerKilometer + 1.4);
            if (this.FuelQuantity - consumedFuel >= 0)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= consumedFuel;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
            }
        }

        public void DriveEmpty(double distance)
        {
            double consumedFuel = distance * this.ConsumprionPerKilometer;
            if (this.FuelQuantity - consumedFuel >= 0)
            {
                Console.WriteLine($"Bus travelled {distance} km");
                this.FuelQuantity -= consumedFuel;
            }
            else
            {
                Console.WriteLine("Bus needs refueling");
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
