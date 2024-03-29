﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CarRacing.Repositories
{
    using CarRacing.Models.Cars.Contracts;
    using Contracts;
    using Utilities.Messages;
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => models;

        public void Add(ICar model)
        {
            if (model is null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(c => c.VIN == property);
        }
    }
}
