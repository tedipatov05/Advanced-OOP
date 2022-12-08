using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Repositories
{
    using Contracts;
    using Formula1.Models.Contracts;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> roles;

        public RaceRepository()
        {
            roles = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => (IReadOnlyCollection<IRace>)roles;  

        public void Add(IRace model)
        => roles.Add(model);

        public IRace FindByName(string name)
        => roles.FirstOrDefault(r => r.RaceName == name);

        public bool Remove(IRace model)
        => roles.Remove(model);
    }
}
