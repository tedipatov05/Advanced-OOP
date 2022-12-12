using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    using Contracts;
    using PlanetWars.Models.MilitaryUnits.Contracts;

    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly HashSet<IMilitaryUnit> army;

        public UnitRepository()
        {
            army = new HashSet<IMilitaryUnit>();
            
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => army;

        public void AddItem(IMilitaryUnit model)
        => army.Add(model);

        public IMilitaryUnit FindByName(string name)
        => army.FirstOrDefault(a => a.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit military = this.FindByName(name);
            return army.Remove(military);
        }
    }
}
