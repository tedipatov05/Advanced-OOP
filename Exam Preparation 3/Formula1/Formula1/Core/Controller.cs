using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Core
{
    using Contracts;
    using Repositories;
    using Models.Cars;
    using Models.Contracts;
    using Models.Pilots;
    using Models.Race;
    using Utilities;
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car;

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            if (carRepository.Models.Any(x => x.Model == model))
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            carRepository.Add(car);
            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            var pilot = new Pilot(fullName);

            if (pilotRepository.Models.Any(x => x.FullName == fullName))
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = new Race(raceName, numberOfLaps);

            if (raceRepository.Models.Any(x => x.RaceName == raceName))
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            var builder = new StringBuilder();
            var pilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();

            foreach (var pilot in pilots)
            {
                builder.AppendLine(pilot.ToString());
            }

            return builder.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var builder = new StringBuilder();

            foreach (var race in raceRepository.Models.Where(x => x.TookPlace == true))
            {
                builder.AppendLine(race.RaceInfo().TrimEnd());
            }

            return builder.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            var topDrivers = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();

            var first = topDrivers[0];
            var second = topDrivers[1];
            var third = topDrivers[2];
            first.WinRace();

            race.TookPlace = true;

            var builder = new StringBuilder();

            builder.AppendLine($"Pilot {first.FullName} wins the {race.RaceName} race.");
            builder.AppendLine($"Pilot {second.FullName} is second in {race.RaceName} race.");
            builder.AppendLine($"Pilot {third.FullName} is third in {race.RaceName} race.");

            return builder.ToString().TrimEnd();
        }
    }
}
