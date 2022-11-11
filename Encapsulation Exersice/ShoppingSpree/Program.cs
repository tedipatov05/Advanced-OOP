using System;
using System.Linq;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] peopleInfo = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                for (int i = 0; i < peopleInfo.Length; i++)
                {
                    string[] currentPersonInfo = peopleInfo[i].Split('=');
                    string name = currentPersonInfo[0];
                    double money = double.Parse(currentPersonInfo[1]);
                    Person person = new Person(name, money);
                    people[name] = person;
                }

                string[] productsInfo = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productsInfo.Length; i++)
                {
                    string[] currentProductInfo = productsInfo[i].Split('=');
                    string name = currentProductInfo[0];
                    double cost = double.Parse(currentProductInfo[1]);
                    Product product = new Product(name, cost);
                    products[name] = product;
                }

                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] arguments = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = arguments[0];
                    string product = arguments[1];
                    double personMoney = people[name].Money;
                    double cost = products[product].Cost;
                    if (personMoney - cost < 0)
                    {
                        Console.WriteLine($"{name} can't afford {product}");
                    }
                    else
                    {
                        people[name].Money -= cost;
                        Console.WriteLine($"{name} bought {product}");
                        people[name].Products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            foreach (var person in people)
            {
                Console.Write($"{person.Key} - ");
                if (person.Value.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", person.Value.Products));
                }
            }
        }
    }
}
