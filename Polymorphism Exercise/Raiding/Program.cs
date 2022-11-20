using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            ICollection<BaseHero> heroes = new List<BaseHero>();
            int countHeroes = int.Parse(Console.ReadLine());

            for(int i = 0; i < countHeroes; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                BaseHero hero = null;

                if(type == nameof(Druid))
                {
                    hero = new Druid(name);
                }
                else if(type == nameof(Paladin))
                {
                    hero = new Paladin(name);
                }
                else if(type == nameof(Rogue))
                {
                    hero = new Rogue(name);
                }
                else if(type == nameof(Warrior))
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }
                heroes.Add(hero);
                
            }
            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = heroes.Sum(h => h.Power);

            foreach (var h in heroes)
            {
                Console.WriteLine(h.CastAbility());
            }

            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
