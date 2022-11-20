using System;

namespace Square_Root
{
    public class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            try
            {
               
                Console.WriteLine(Sqrt(num));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
            
        }
        public static double Sqrt(double num)
        {
            if(num < 0)
            {
                throw new Exception("Invalid number.");
            }
            return Math.Sqrt(num);
        }

    }
}
