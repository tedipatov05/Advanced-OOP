using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    internal interface ICommand
    {
        string Name { get; }

        void Run(string[] args);
    }
}
