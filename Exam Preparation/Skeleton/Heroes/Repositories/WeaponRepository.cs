using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => weapons.AsReadOnly();

        public void Add(IWeapon model)
        => this.weapons.Add(model);

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            if (weapons.Any(w => w.Name == model.Name))
            {
                this.weapons.Remove(model);
                return true;
            }
            return false;
        }
    }
}
