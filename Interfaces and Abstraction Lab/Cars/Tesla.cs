using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IELectricCar
    {
        public string Model { get; private set; }

        public string Color { get; private set; }
        public int Battery { get; private set; }

        public Tesla(string model, string color, int batery)
        {
            Model = model;
            Color = color;
            Battery = batery;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Tesla {this.Model} with {this.Battery} Batteries ");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }// override string ToString()


    }
}
