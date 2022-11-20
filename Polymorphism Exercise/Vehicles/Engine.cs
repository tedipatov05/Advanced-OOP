﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Engine
    {
        private ICollection<Vehicle> vehicles;
        private CommandInterperter commandInterpreter;

        //------------- Constructors ---------------
        public Engine()
        {
            this.vehicles = new List<Vehicle>();
            this.commandInterpreter = new CommandInterperter();
        }

        //--------------- Methods ------------------
        public void Run()
        {
            string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] busData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]), double.Parse(carData[3]));
                Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]), double.Parse(truckData[3]));
                Vehicle bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]), double.Parse(busData[3]));
                this.vehicles.Add(car);
                this.vehicles.Add(truck);
                this.vehicles.Add(bus);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            int n = int.Parse(Console.ReadLine());
            while (n-- > 0)
            {
                string[] args = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = args[0];

                try
                {
                    commandInterpreter.ExecuteCommand(command, args, vehicles);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, this.vehicles));
        }
    }
}
