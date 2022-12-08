using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Pilots
{
    using Formula1.Models.Cars;
    using Utilities;
    public class Pilot : IPilot
    {
        private string fullname;
        private IFormulaOneCar car;

        public Pilot(string fullname)
        {
            FullName = fullname;
            CanRace = false;
        }
        public string FullName 
        {
            get => this.fullname;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullname = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this.car;
            private set
            {
                if(value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.car = value;
            }
        }


        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; } 

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
        public override string ToString()
        => $"Pilot {FullName} has {NumberOfWins} wins.";
    }
}
