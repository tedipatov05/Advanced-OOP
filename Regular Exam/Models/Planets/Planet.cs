using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Models.Planets
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Weapons.Contracts;
    using Utilities.Messages;
    using Repositories;
    using Models.Weapons;

    public class Planet : IPlanet
    {

        private string name;
        private double budget;
        private readonly UnitRepository army;
        private readonly WeaponRepository weapons;


        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            army = new UnitRepository();
            weapons = new WeaponRepository();

        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get => this.budget;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        private double CalculatePower()
        {
            double power = Army.Sum(m => m.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel);
            if(weapons.FindByName("AnonymousImpactUnit") != null)
            {
                power += power * 0.3;
            }
            else if(weapons.FindByName("NuclearWeapon") != null)
            {
                power += power * 0.45;
            }

            return Math.Round(power, 3);
        }


        public double MilitaryPower
        {
            get => this.CalculatePower();
            private set => this.CalculatePower();
           
        }


        public IReadOnlyCollection<IMilitaryUnit> Army => army.Models;
        public IReadOnlyCollection<IWeapon> Weapons => weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        => army.AddItem(unit);

        public void AddWeapon(IWeapon weapon)
        => weapons.AddItem(weapon);

        public string PlanetInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Planet: {Name}");
            stringBuilder.AppendLine($"--Budget: {Budget} billion QUID");
            string forces = Army.Count != 0 ? string.Join(", ", Army.Select(a => a.GetType().Name)) : "No units";
            stringBuilder.AppendLine($"--Forces: {forces}");
            string weapons = Weapons.Count != 0 ? string.Join(", ", Weapons.Select(w => w.GetType().Name)) : "No weapons";
            stringBuilder.AppendLine($"--Combat equipment: {weapons}");
            stringBuilder.Append($"--Military Power: {MilitaryPower}");

            return stringBuilder.ToString().TrimEnd();
        }

        public void Profit(double amount)
        => Budget += amount;

        public void Spend(double amount)
        {
            if(Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach(IMilitaryUnit military in Army)
            {
                military.IncreaseEndurance();
            }
        }
    }
}
