using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace AquaShop.Core
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;
    using AquaShop.Models.Aquariums;
    using AquaShop.Models.Decorations;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Models.Fish;

    public class Controller : IController
    {
        private readonly IRepository<IDecoration> decorations;
        private readonly ICollection<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if(aquariumType == "FreshwaterAquarium" )
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if(aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            aquariums.Add(aquarium);
            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if(decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if(decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(decoration);
            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IDecoration decoration = decorations.FindByType(decorationType);

            if(decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);
            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
           
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            IFish fish;
            if(fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price) ;
            }
            else if(fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string aquariumType = aquarium.GetType().Name.Replace("Aquarium", string.Empty);
            string fishTypeWater = fish.GetType().Name.Replace("Fish", string.Empty);
            if(fishTypeWater != aquariumType)
            {
                return OutputMessages.UnsuitableWater;
            }
            else
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
        }

        public string CalculateValue(string aquariumName)
        {
           
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            decimal value = aquarium.Decorations.Sum(d => d.Price) + aquarium.Fish.Sum(f => f.Price);
            
            return string.Format(OutputMessages.AquariumValue, aquariumName, value);

        }

        public string FeedFish(string aquariumName)
        {
           IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();

            return String.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

       

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
