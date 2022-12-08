using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NavalVessels.Repositories
{
    using Contracts;
    using Models.Contracts;
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> models;

        public VesselRepository()
        {
            models = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => models.AsReadOnly();


        public void Add(IVessel model)
        {
            models.Add(model);
        }

        public bool Remove(IVessel model)
        {
            return models.Remove(model);
        }

        public IVessel FindByName(string name)
        {
            return models.FirstOrDefault(v => v.Name == name);
        }
    }
}
