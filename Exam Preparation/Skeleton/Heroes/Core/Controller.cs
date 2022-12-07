using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Core
{
    using Contracts;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;
    using Repositories;
    using Models.Heroes;
    using Models.Weapons;
    using Heroes.Models.Map;

    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IWeapon> weapons;
        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();

        }
        public string AddWeaponToHero(string weaponName, string heroName)
        {
            var hero = heroes.FindByName(heroName);
            var weapon = weapons.FindByName(weaponName);
            if (hero == null)
            {
                throw new InvalidOperationException($"Hero {heroName} does not exist.");
            }
            if(weapon == null)
            {
                throw new InvalidOperationException($"Weapon {weaponName} does not exist.");
            }
            if(hero.Weapon != null)
            {
                throw new InvalidOperationException($"Hero {heroName} is well-armed.");
            }
            hero.AddWeapon(weapon);
            this.weapons.Remove(weapon);
            var weaponType = weapon.GetType().Name.ToLower();
            return $"Hero {heroName} can participate in battle using a {weaponType}.";
        }

        public string CreateHero(string type, string name, int health, int armour)
        {
            if(heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The hero {name} already exists.");
            }
            IHero hero = type switch 
            {
                nameof(Knight) => new Knight(name, health, armour),
                nameof(Barbarian) => new Barbarian(name, health, armour),
                _ => throw new InvalidOperationException("Invalid hero type.")
            };

            heroes.Add(hero);
            var heroAlias = type == nameof(Knight)
                ? $"Sir {hero.Name}"
                : $"{nameof(Barbarian)} {hero.Name}";
            return $"Successfully added {heroAlias} to the collection.";
           
        }

        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException($"The weapon {name} already exists.");
            }
            IWeapon weapon = type switch
            {
                nameof(Mace) => new Mace(name, durability),
                nameof(Claymore) => new Claymore(name, durability),
                _ => throw new InvalidOperationException("Invalid weapon type.")
            };
            weapons.Add(weapon);

            return $"A {type.ToLower()} {name} is added to the collection.";
        }

        public string HeroReport()
        {

            var result = new StringBuilder();
            var sortedheroes = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);
            foreach(var hero in sortedheroes)
            {
                result.AppendLine(hero.ToString());
            }

            return result.ToString().Trim();
        }

        public string StartBattle()
        {
            var map = new Map();

            var heroesReadyForBattle = heroes
                .Models        
                .Where(h => h.IsAlive && h.Weapon != null)
                .ToList();
            return map.Fight(heroesReadyForBattle);
        }

    }
}
