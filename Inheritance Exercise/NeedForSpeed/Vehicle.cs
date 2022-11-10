using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        const double DefaultFuelConsumption = 1.25;
        virtual public double FuelConsumption { get { return DefaultFuelConsumption; } }

        public double Fuel{ get; set; }

        public int HorsePower { get; set; }
        virtual public void Drive(double km)
        {
            Fuel -= FuelConsumption * km;
        }

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

    }
}
