using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Formula1.Repositories
{
    using Contracts;
    
    using Formula1.Models.Contracts;

    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> formulaOneCars;

        public FormulaOneCarRepository()
        {
            formulaOneCars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => (IReadOnlyCollection<IFormulaOneCar>)formulaOneCars; 

        public void Add(IFormulaOneCar model)
           => formulaOneCars.Add(model);

        public IFormulaOneCar FindByName(string name)
        => formulaOneCars.FirstOrDefault(f => f.Model == name);

        public bool Remove(IFormulaOneCar model)
        => formulaOneCars.Remove(model);
    }
}
