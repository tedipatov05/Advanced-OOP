using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Formula1.Repositories
{
    using Contracts;
    using Formula1.Models.Contracts;

    public class PilotRepository : IRepository<IPilot>
    {
        public readonly ICollection<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => (IReadOnlyCollection<IPilot>)pilots;
        public void Add(IPilot model)
        => pilots.Add(model);

        public IPilot FindByName(string name)
        => pilots.FirstOrDefault(f => f.FullName == name);

        public bool Remove(IPilot model)
        => pilots.Remove(model);
    }
}
