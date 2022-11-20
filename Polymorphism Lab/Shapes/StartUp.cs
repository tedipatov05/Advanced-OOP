using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(5, 19);
            Shape circle = new Circle(5);

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine($"Perimeter: {rectangle.CalculatePerimeter():F2}");
            Console.WriteLine($"Area: {rectangle.CalculateArea():F2}");
            Console.WriteLine(circle.Draw());
            Console.WriteLine($"Perimeter: {circle.CalculatePerimeter():F2}");
            Console.WriteLine($"Area: {circle.CalculateArea():F2}");
        }
    }
}
