using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models.Cars
{
    using Utilities;
    public class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsepower;
        private double enginedisplacement;

        protected FormulaOneCar(string model, int horsepower, double enginedisplacement)
        {
            Model = model;
            Horsepower = horsepower;
            EngineDisplacement = enginedisplacement;
        }

        public string Model
        {
            get => model;
            private set
            {
                if(string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get => horsepower;
            private set
            {
                if(value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                horsepower = value;
            }
        }

        public double EngineDisplacement
        {
            get => this.enginedisplacement;
            private set
            {
                if (value < 1.6 || value < 2.00)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                enginedisplacement = value;
            }
        }


        public double RaceScoreCalculator(int laps)
        => (double)EngineDisplacement / Horsepower * laps;
    }
}
