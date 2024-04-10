using AnimalType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TAsk18_Factory.Model
{
    internal class SaveOpenToJson
    {
        public void Save(IEnumerable<IGeneralAnimal> Animals)
        {
            AnimalToSerialize ListToSerialize = new AnimalToSerialize(Animals);
           
            using (FileStream fs = new FileStream("Animlas.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, ListToSerialize);
            }
        }
        public IEnumerable<IGeneralAnimal> Open()
        {
            List<IGeneralAnimal> lTmp = new List<IGeneralAnimal>();   
            using (FileStream fs = new FileStream("Animlas.json", FileMode.OpenOrCreate))
            {
                AnimalToSerialize? ListFromSerialize = JsonSerializer.Deserialize<AnimalToSerialize>(fs);
                if (ListFromSerialize != null)
                    foreach (var i in ListFromSerialize.Birds)
                        lTmp.Add(i);
                foreach (var i in ListFromSerialize.Mammals)
                    lTmp.Add(i);
                foreach (var i in ListFromSerialize.Amphibians)
                    lTmp.Add(i);
                return lTmp;
            }
        }
    }

}
