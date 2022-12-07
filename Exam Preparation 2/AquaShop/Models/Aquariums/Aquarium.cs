using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using Contracts;
    using Utilities.Messages;
    public abstract class Aquarium : IAquarium
    {
        private string name;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Decorations = new HashSet<IDecoration>();
            Fish = new HashSet<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get;  }

        public int Comfort => Decorations.Sum(d => d.Comfort);

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get;}

        public void AddDecoration(IDecoration decoration)
        => Decorations.Add(decoration);
          

        public void AddFish(IFish fish)
        {
            if(Fish.Count + 1 > Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            
            Fish.Add(fish);
            
        }

        public void Feed()
        {
            foreach(var fish in Fish)
            {
                fish.Eat();
            }
        }
       

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({this.GetType().Name}): ");

            string fishs = Fish.Count > 0 ? string.Join(", ", Fish.Select(f => f.Name)) : "none";
                
            sb.AppendLine($"Fish: {fishs}");             
            sb.AppendLine($"Decorations: {Decorations.Count()}");
            sb.Append($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
            => Fish.Remove(fish);
       
    }
}
