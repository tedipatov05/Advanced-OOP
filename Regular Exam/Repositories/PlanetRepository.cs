using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlanetWars.Repositories
{
    using Contracts;
    using Models.Planets.Contracts;
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly HashSet<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new HashSet<IPlanet>();
        }
        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)
        => planets.Add(model);

        public IPlanet FindByName(string name)
        => planets.FirstOrDefault(p => p.Name == name);

        public bool RemoveItem(string name)
        {
            IPlanet planet = this.FindByName(name);
            return planets.Remove(planet);
        }
        
    }
}
