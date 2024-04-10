using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalType;

namespace TAsk18_Factory.Model
{
    public class AnimalToSerialize
    {
        public AnimalToSerialize()
        {

        }
        public AnimalToSerialize(IEnumerable<IGeneralAnimal> list)
        {
            Amphibians = new List<Amphibian>();
            Birds = new List<Bird>();
            Mammals = new List<Mammal>();
            foreach (var i in list)
            {
                if (i is Amphibian tmp) Amphibians.Add(tmp);
                if (i is Bird tmpBird) Birds.Add(tmpBird);
                if (i is Mammal tmpMammal) Mammals.Add(tmpMammal);

            }

        }
        //[Serializable]
        public List<Amphibian> Amphibians= new List<Amphibian>();
        public List<Bird> Birds= new List<Bird>();
        public List<Mammal> Mammals= new List<Mammal>();



    }
}
