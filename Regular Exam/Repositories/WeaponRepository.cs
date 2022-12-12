using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.Weapons.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly HashSet<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new HashSet<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon model)
        => weapons.Add(model);

        public IWeapon FindByName(string name)
        => weapons.FirstOrDefault(w => w.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weapon = FindByName(name);

            return weapons.Remove(weapon);
        }
    }
}
