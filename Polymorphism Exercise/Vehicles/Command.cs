using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Command : ICommand
    {
        private string name;

        //--------------- Constructors -----------------
        protected Command(string name)
        {
            this.Name = name;
        }

        //---------------- Properties ------------------
        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        //------------- Abstract Methods ---------------
        public abstract void Run(string[] args);

        public abstract void Run(string[] args, ICollection<Vehicle> vehicles);
    }
}
