using AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalAnimal
{
    internal class AnimalType
    {
    }
    public class Fish : IGeneralAnimal
    {

        public string Type { get; init; }
        public string Breed { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string AreaLive { get; set; }
        public string? Scale { get; set; }

        public Fish() { }
        public Fish(string breed, string name, string description, string areaLive, string scale)
        {
            this.Type = "Fish";
            Breed = breed;
            Name = name;
            Description = description;
            AreaLive = areaLive;
            Scale = scale;
        }

        public IGeneralAnimal CreateAnimal(string breed, string Name, string Description, string AreaLive) => new Fish(Type, Name, Description, AreaLive, Scale);

    }
}
