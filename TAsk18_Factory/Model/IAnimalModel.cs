using AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk18_Factory.Model
{
    public interface IAnimalModel
    {
        public List<IGeneralAnimal> Animals { get; set; }
        
        public void Save(string path);
        public void Open(string path);
        public void Add(IGeneralAnimal animal);
        public void Change(IGeneralAnimal animal);
        public void Remove(IGeneralAnimal animal);
        public IEnumerable<IGeneralAnimal> GetAnimals();
        public IGeneralAnimal GetAnimalByName(string Name);
        public IEnumerable<string> GetAnimalTypes();
        public void  CreateAnimal(IGeneralAnimal animal);
        public event EventHandler AnimalModelChanged;
    }
}
