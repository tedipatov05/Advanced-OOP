using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Heroes.Repositories
{
    using Contracts;
    using Models.Contracts;
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public IReadOnlyCollection<IHero> Models => heroes.AsReadOnly();

        public void Add(IHero model) => this.heroes.Add(model);
       

        public IHero FindByName(string name)
        {
            return heroes.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            if (heroes.Any(h => h.Name == model.Name))
            {
                this.heroes.Remove(model);
                return true;
            }
            return false;
        }
    }
}
