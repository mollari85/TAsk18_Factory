using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using AnimalType;

namespace TAsk18_Factory.Model
{
    public class AnimalModel : IAnimalModel
    {
        public event EventHandler AnimalModelChanged;
        internal FactoryManager AnimalFactoryManager = new FactoryManager();
        public List<IGeneralAnimal> Animals { get; set; }

        public AnimalModel()
        {
            Animals = new List<IGeneralAnimal>();
            if (AnimalFactoryManager.GetAnimalFactory("MammalFactory") != null)
                Animals.Add(AnimalFactoryManager.GetAnimalFactory("MammalFactory").CreateAnimal(
                    "NewMammal", "MyMammal", "This mammal was found in Africa, it is big and strong", "Africa"));
            if (AnimalFactoryManager.GetAnimalFactory("AmphibianFactory") != null)
                Animals.Add(AnimalFactoryManager.GetAnimalFactory("AmphibianFactory").CreateAnimal(
                "NewAmphibian", "MyAmphibian", "This Amphibian was found in Eroupe, it is little and weak", "Europe"));
            if (AnimalFactoryManager.GetAnimalFactory("BirdFactory") != null)
                Animals.Add(AnimalFactoryManager.GetAnimalFactory("BirdFactory").CreateAnimal(
                "NewBird", "MyBird", "This Bird was found in America, it is big and can't fly", "America"));

        }
        public IEnumerable<string> GetAnimalTypes()
        {
            List<string> lTmp = new List<string>();
            foreach (var i in AnimalFactoryManager.GetAnimalFactories())
                lTmp.Add(i.Name.Replace("Factory", null));
            return lTmp;
        }
        public void CreateAnimal(IGeneralAnimal animal)
        {
            AnimalFactoryManager.GetAnimalFactory(animal.Type).CreateAnimal(animal.Breed, animal.Name, animal.Description, animal.AreaLive);
        }
        public void Save()
        {
            ISaveOpen SaveData = new SaveOpenToXML();
            SaveData.Save(Animals);
        }
        public void Open()
        {
            ISaveOpen GetData = new SaveOpenToXML();
            Animals=GetData.Open().ToList();
        }
        public void Remove(IGeneralAnimal animal)
        {
            Animals.Remove(animal);
        }
        public void Add(string breed, string name, string description, string areaLive)
        {
            Animals.Add(new GeneralAnimal(breed, name, description, areaLive));
            AnimalModelChanged?.Invoke(this, new EventArgs());
        }
        public void Add(IGeneralAnimal animal)
        {
            Animals.Add(animal);
            AnimalModelChanged?.Invoke(this, new EventArgs());
            
        }
        public void Change(IGeneralAnimal Animal)
        {
            
        }

        public IEnumerable<IGeneralAnimal> GetAnimals() => Animals;
        public IGeneralAnimal GetAnimalByName(string Name)
        {
            return Animals.FirstOrDefault(p => p.Name == Name);
        }

    }
}

