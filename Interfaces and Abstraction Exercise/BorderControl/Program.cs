using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICollection<IBirthable> ibirthable = new List<IBirthable>();

            string input = Console.ReadLine();

            while(input != "End")
            {
                string[] inpArgs = input.Split();
                if(inpArgs.Length == 5)
                {
                    IBirthable citizen = new Citizen(inpArgs[1], int.Parse(inpArgs[2]), inpArgs[3], inpArgs[4]);
                    ibirthable.Add(citizen);
                }
                else if(inpArgs.Length == 3)
                {
                    if (inpArgs[0] == "Robot")
                    {
                        IIdenticable robot = new Robot(inpArgs[1], inpArgs[2]);
                        
                    }
                    else if (inpArgs[0] == "Pet")
                    {
                        IBirthable pet = new Pet(inpArgs[1], inpArgs[2]);
                        ibirthable.Add(pet);
                    }
                }
                input = Console.ReadLine();
            }

            string detainedDigits = Console.ReadLine();

            string[] detrained = ibirthable.Where(i => i.BirthDate.EndsWith(detainedDigits))
                .Select(i => i.BirthDate)
                .ToArray();
            foreach(string d in detrained)
            {
                Console.WriteLine(d);
            }
                

            
        }
    }
}
