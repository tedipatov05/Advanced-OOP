using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar: Car
    {
        private const double DefaultSportCarFuelConsumption = 10;

        public SportCar(int horsepower, double fuel)
            : base(horsepower, fuel)
        {
                
        }

        public override double FuelConsumption => DefaultSportCarFuelConsumption;
    }
}
