using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vehicles
{
    public class RefuelCommand : Command
    {
        public RefuelCommand() : base("Refuel")
        {

        }

        //----------------- Methods --------------------
        public override void Run(string[] args)
        {
            Console.WriteLine("For testing purposes");
            //throw new NotImplementedException(); -> Liskov Substitution Violation if thrown...
        }

        public override void Run(string[] args, ICollection<Vehicle> vehicles)
        {
            foreach (Vehicle vehicle in vehicles.Where(v => v.GetType().Name == args[1]))
            {
                vehicle.Refuel(double.Parse(args[2]));
            }
        }
    }
}
