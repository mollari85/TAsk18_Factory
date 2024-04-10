using System.Data.Common;

namespace AnimalType
{
    public interface IGeneralAnimal
    {
        public string Type { get; init; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string AreaLive { get; set; }
        public IGeneralAnimal CreateAnimal(string Breed, string Name, string Description, string AreaLive);
       
    }
    public class Mammal : IGeneralAnimal
    {
        
        public string Type { get; init; }
        public string Breed { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string AreaLive { get; set; }
        public string? FurColor { get; set; }

        public Mammal() { }
        public Mammal(string breed,string name, string description, string areaLive)
        {
            this.Type = "Mammal";
            Breed = breed;
            Name = name;
            Description = description;
            AreaLive = areaLive;
            FurColor = null;
        }

        public IGeneralAnimal CreateAnimal(string breed,string Name, string Description, string AreaLive) =>new  Mammal(Type, Name, Description, AreaLive);
 
    }
    public class Bird : IGeneralAnimal
    {

        public string Type { get; init; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Description { get; set; }
        public string AreaLive { get; set; }
        public string WingColor { get; set; }

        public Bird() { }
        public Bird(string breed,string name, string description, string areaLive, string wingColor="Black")
        {
            this.Type ="Bird" ;
            Breed = breed;
            Name = name;
            Description = description;
            AreaLive = areaLive;
            WingColor = wingColor;
        }

        public IGeneralAnimal CreateAnimal(string breed,string Name, string Description, string AreaLive) => new Bird(Type,Name, Description, AreaLive);

    }
    public class Amphibian : IGeneralAnimal
    {
        public string Type { get; init; }
        public string Breed { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string AreaLive { get; set; }
        public int TailLong { get; set; }

        public Amphibian() { }
        
            public  Amphibian(string breed,string name, string description, string areaLive, int tailLong=0)
        {
            this.Type = "Amphibian";
            Breed = breed;
            Name = name;
            Description = description;
            AreaLive = areaLive;
            TailLong = tailLong;
        }

        public IGeneralAnimal CreateAnimal(string Breed,string Name, string Description, string AreaLive) => new Amphibian(Type,Name, Description, AreaLive, 0);

    }
    public class GeneralAnimal : IGeneralAnimal
    {
        public string Type { get; init; }
        public string Breed { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string AreaLive { get; set; }

        public GeneralAnimal() { }
        public GeneralAnimal(string breed, string name, string description, string areaLive)
        {
            this.Type = "General";
            Breed = breed;
            Name = name;
            Description = description;
            AreaLive = areaLive;
        }

        public IGeneralAnimal CreateAnimal(string Breed, string Name, string Description, string AreaLive) => new GeneralAnimal(Type, Name, Description, AreaLive);

    }
    public enum TypeAnimal
    {
        Mammal,
        Bird,
        Amphibian
    }
}