using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double RaceMotorcycleFuelConsumption = 8;

        public RaceMotorcycle(int horsepower, double fuel)
            : base(horsepower, fuel)
        {

        }

        public override double FuelConsumption => RaceMotorcycleFuelConsumption;
    }
}
