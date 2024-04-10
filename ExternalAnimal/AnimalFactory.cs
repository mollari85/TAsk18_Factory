using AnimalType;
using System;

namespace ExternalAnimal
{
    public class AnimalFactory
    {
    }
    internal class FishFactory : IAnimalFactory
    {
        public string Name { get; init; } = "FishFactory";
        public IGeneralAnimal CreateAnimal(string breed, string name, string description, string ariaLive)
        {
            return (new Fish(breed, name, description, ariaLive,"Silver"));

        }
    }
}
