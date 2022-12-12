using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Core
{
    using Contracts;
    using Repositories;
    using Models.Maps.Contracts;
    using Models.Cars.Contracts;
    using Models.Cars;
    using Models.Racers;
    using Models.Racers.Contracts;
    using Utilities.Messages;
    using Models.Maps;
    
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }
        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            switch (type)
            {
                case "SuperCar":
                    car = new SuperCar(make, model, VIN, horsePower);
                    break;
                case "TunedCar":
                    car = new TunedCar(make, model, VIN, horsePower);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }

            cars.Add(car);

            return string.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            ICar car = cars.FindBy(carVIN);

            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);
            }


            IRacer racer;

            switch (type)
            {
                case "ProfessionalRacer":
                    racer = new ProfessionalRacer(username, car);
                    break;
                case "StreetRacer":
                    racer = new StreetRacer(username, car);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
            }

            
            racers.Add(racer);

            return string.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racerOne = racers.FindBy(racerOneUsername);
            var racerTwo = racers.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            else if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            var orderedRacers = racers.Models
                .OrderByDescending(r => r.DrivingExperience)
                .ThenBy(r => r.Username);

            StringBuilder sb = new StringBuilder();

            foreach (var racer in orderedRacers)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
