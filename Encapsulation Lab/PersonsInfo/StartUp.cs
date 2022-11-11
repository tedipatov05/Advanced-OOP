using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for(int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                try
                {
                    Person person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                    people.Add(person);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
               

            }
            var percent = decimal.Parse(Console.ReadLine());
            people = people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList();
            people.ForEach(p => p.IncreaseSalary(percent));
            //people.ForEach(p => Console.WriteLine(p.ToString()));

            Team team = new Team("SoftUni");

            foreach(Person person in people)
            {
                team.AddPlayer(person);
            }
                

        }
    }
}
