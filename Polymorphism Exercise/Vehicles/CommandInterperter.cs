using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class CommandInterperter
    {
        private Dictionary<string, Command> commands;

        //--------------- Constructors -----------------
        public CommandInterperter()
        {
            this.commands = new Dictionary<string, Command>();
            this.AddCommand(new DriveCommand());
            this.AddCommand(new RefuelCommand());
        }

        //-------------- Public Methods ----------------
        public void ExecuteCommand(string command, string[] args)
        {
            if (this.commands.ContainsKey(command))
            {
                commands[command].Run(args);
            }
            else
            {
                throw new ArgumentException("Command not found.");
            }
        }

        public void ExecuteCommand(string command, string[] args, ICollection<Vehicle> vehicles)
        {
            if (this.commands.ContainsKey(command))
            {
                commands[command].Run(args, vehicles);
            }
            else
            {
                throw new ArgumentException("Command not found.");
            }
        }

        //-------------- Private Methods ---------------
        private void AddCommand(Command command)
        {
            if (!this.commands.ContainsKey(command.Name))
            {
                this.commands.Add(command.Name, command);
            }
        }
    }
}
