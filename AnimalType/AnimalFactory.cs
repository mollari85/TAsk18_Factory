using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AnimalType;


namespace AnimalType
{
    public class FactoryManager 
    {
        List<IAnimalFactory> Factories = new List<IAnimalFactory>();
        public FactoryManager() 
        {
            string libraryPath = "ExternalAnimal.dll";
            if (File.Exists(libraryPath))
                LoadFactoryFromAssembly(libraryPath);
            AddFactory(new MammalFactory());
            AddFactory(new AmphibianFactory());
            AddFactory(new BirdFactory());
        }

        public void AddFactory(IAnimalFactory factory)
        {
            if (Factories.FirstOrDefault(x => x.Name.ToUpper() == factory.Name.ToUpper()) != null)
                throw new ArgumentException($"the factory name {factory} is already in the list");

            Factories.Add(factory);


        }

        public IAnimalFactory? GetAnimalFactory(string factoryName)
        {
            if (string.IsNullOrEmpty(factoryName))
                throw new ArgumentNullException("Factory name can't be null or empty");
           return Factories.FirstOrDefault(x => x.Name.ToUpper() == factoryName.ToUpper());
       
        }
        public IEnumerable<IAnimalFactory> GetAnimalFactories() => Factories;

        public void LoadFactoryFromAssembly(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            Type[] types = assembly.GetTypes();
            foreach (Type t in types)
            
                if (typeof(IAnimalFactory).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                {
                    IAnimalFactory factory = Activator.CreateInstance(t) as IAnimalFactory;
                    if ((factory != null))
                        Factories.Add(factory);
                        
                }
            }
        }
        
    

    public interface IAnimalFactory
    {
        public string Name { get; init; }
        public IGeneralAnimal CreateAnimal(string breed, string name, string description, string ariaLive);
    }

    internal class MammalFactory:IAnimalFactory
    {
        public string Name { get; init; } = "MammalFactory";
        public IGeneralAnimal CreateAnimal(string breed, string name, string description, string ariaLive)
        {
            return(new Mammal(breed, name, description,ariaLive));
            
        }
    }
    internal class BirdFactory : IAnimalFactory
    {
        public string Name { get; init; } = "BirdFactory";
        public IGeneralAnimal CreateAnimal(string breed, string name, string description, string ariaLive)
        {
            return (new Bird(breed, name, description, ariaLive));

        }
    }
    internal class AmphibianFactory : IAnimalFactory
    {
        public string Name { get; init; } = "AmphibianFactory";
        public IGeneralAnimal CreateAnimal(string breed, string name, string description, string ariaLive)
        {
            return (new Amphibian(breed, name, description, ariaLive,0));

        }
    }
}

