using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            ICollection<IBuyer> people = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if(tokens.Length == 4)
                {
                    IBuyer citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                    people.Add(citizen);

                }
                else if(tokens.Length == 3)
                {
                    IBuyer rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    people.Add(rebel);

                }
            }
            string input = Console.ReadLine();
           
            while(input != "End")
            {
                var buyer = people.FirstOrDefault(p => p.Name == input);
                if(buyer != null)
                {
                    buyer.BuyFood();
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(people.Sum(p => p.Food));
        }
    }
}
