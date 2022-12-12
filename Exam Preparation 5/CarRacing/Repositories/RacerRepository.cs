using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories
{
    using Contracts;
    using Models.Racers.Contracts;
    using Utilities.Messages;
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> models;

        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models;

        public void Add(IRacer model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(model);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(r => r.Username == property);
        }
    }
}
