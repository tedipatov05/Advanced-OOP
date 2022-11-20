using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<IAnimal> listWithAnimals;
        private FoodCreator foodCreator;

        private Engine()
        {
            this.listWithAnimals = new List<IAnimal>();
            this.foodCreator = new FoodCreator();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] inputArguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = null;
                string animalType = inputArguments[0];
                if (animalType == "Owl")
                {
                    animal = new Owl(inputArguments[1], double.Parse(inputArguments[2]), double.Parse(inputArguments[3]));
                }

                else if (animalType == "Hen")
                {
                    animal = new Hen(inputArguments[1], double.Parse(inputArguments[2]), double.Parse(inputArguments[3]));
                }

                else if (animalType == "Mouse")
                {
                    animal = new Mouse(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3]);
                }

                else if (animalType == "Cat")
                {
                    animal = new Cat(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3], inputArguments[4]);
                }

                else if (animalType == "Dog")
                {
                    animal = new Dog(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3]);
                }

                else if (animalType == "Tiger")
                {
                    animal = new Tiger(inputArguments[1], double.Parse(inputArguments[2]), inputArguments[3], inputArguments[4]);
                }

                this.writer.WriteLine(animal.ProduceSound());
                try
                {
                    this.listWithAnimals.Add(animal);
                    string[] foodArguments = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string foodType = foodArguments[0];
                    int quantity = int.Parse(foodArguments[1]);
                    Food food = foodCreator.Create(foodType, quantity);
                    animal.FeedIt(food);
                }

                catch (ArgumentException exception)
                {
                    this.writer.WriteLine(exception.Message);
                }
            }

            foreach (var animal in listWithAnimals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
