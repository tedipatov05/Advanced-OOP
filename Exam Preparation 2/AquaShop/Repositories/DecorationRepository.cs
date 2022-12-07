using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquaShop.Repositories
{
    using Contracts;
    using Models.Decorations.Contracts;
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly ICollection<IDecoration> decorations;

        

        public DecorationRepository()
        { 
            decorations = new HashSet<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => (IReadOnlyCollection<IDecoration>)decorations;

        public void Add(IDecoration model) => decorations.Add(model);


        public IDecoration FindByType(string type)
        => decorations.FirstOrDefault(d => d.GetType().Name == type);
        public bool Remove(IDecoration model)
        => decorations.Remove(model);
    }
}
