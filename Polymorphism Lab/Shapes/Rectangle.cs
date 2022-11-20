using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public double Height { get; private set; }
        public double Width { get; private set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {
           return 2*(Height + Width);
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }

}
