using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace PlanetWars.Core
{
    using Contracts;
    using Repositories;
    using Models.Planets;
    using Models.Planets.Contracts;
    using Models.Weapons.Contracts;
    using Models.Weapons;
    using Models.MilitaryUnits;
    using Models.MilitaryUnits.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private readonly PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {

            IPlanet planet;

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            planet = planets.FindByName(planetName);

            IMilitaryUnit unit = null;

            switch (unitTypeName) 
            {
                case "StormTroopers":
                    unit = new StormTroopers();
                    break;
                case "SpaceForces":
                    unit = new SpaceForces();
                    break;
                case "AnonymousImpactUnit":
                    unit = new AnonymousImpactUnit();
                    break;
                default:
                    throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

           
            

            if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);

        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet;

            if( planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            planet = planets.FindByName(planetName);
            IWeapon weapon;

            switch (weaponTypeName) 
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
                default:
                    throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
                    


            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
           

            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }

        public string CreatePlanet(string name, double budget)
        {
           
            if(planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            List<IPlanet> planets = this.planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name).ToList();

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (IPlanet planet in planets)
            {
                stringBuilder.AppendLine(planet.PlanetInfo());
            }

            return stringBuilder.ToString().TrimEnd();

        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            double firsPlanetMilitaryPower = firstPlanet.MilitaryPower;
            double secondPlanetMilitaryPower = secondPlanet.MilitaryPower;

            string winnerPlanet;
            string losePlanet;

            if (firsPlanetMilitaryPower == secondPlanetMilitaryPower) 
            {
                
                if(firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winnerPlanet = firstPlanet.Name;
                    losePlanet = secondPlanet.Name;
                }
                else if(secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winnerPlanet= secondPlanet.Name;
                    losePlanet = firstPlanet.Name;
                }
                else 
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);

                    return OutputMessages.NoWinner;
                }
            }
            else if(firsPlanetMilitaryPower > secondPlanetMilitaryPower)
            {
                winnerPlanet = firstPlanet.Name;
                firstPlanet.Spend(firstPlanet.Budget / 2);
                double profit = secondPlanet.Budget / 2 ;

                firstPlanet.Profit(profit);
                firstPlanet.Profit(secondPlanet.Weapons.Sum(w => w.Price) + secondPlanet.Army.Sum(a => a.Cost));
                this.planets.RemoveItem(secondPlanet.Name);

                losePlanet = secondPlanet.Name;
            }
            else
            {
                winnerPlanet = secondPlanet.Name;
                secondPlanet.Spend(secondPlanet.Budget / 2);
                double profit = firstPlanet.Budget / 2 ;

                secondPlanet.Profit(profit);
                secondPlanet.Profit(firstPlanet.Weapons.Sum(w => w.Price) + firstPlanet.Army.Sum(a => a.Cost));

                this.planets.RemoveItem(firstPlanet.Name);

                losePlanet = firstPlanet.Name;
            }


            return string.Format(OutputMessages.WinnigTheWar, winnerPlanet, losePlanet);
        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if(planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if(planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            planet.Spend(1.25);
            planet.TrainArmy();
            

            return String.Format(OutputMessages.ForcesUpgraded, planetName);
           
            
        }
    }
}
