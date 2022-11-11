using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public double Length
        {
            get { return length; }
            private set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get { return width; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get { return this.height; }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }

                this.height = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
          
        }

        public double SurfaceArea()
        {
            return 2 * (length*width + length*height + height*width);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (length * height + width * height);
        }
        public double Volume()
        {
            return length * width * height;
        }
    }
}
