using AnimalType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Shapes;

namespace TAsk18_Factory.Model
{
    internal class SaveOpenToJson:ISaveOpen
    {
        public void Save(IEnumerable<IGeneralAnimal> Animals, string path)
        {
            if ((path == null) )
                throw new ArgumentException("File is null");
            AnimalToSerialize ListToSerialize = new AnimalToSerialize(Animals);
           
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                JsonSerializer.Serialize(fs, ListToSerialize);
            }
        }
        public IEnumerable<IGeneralAnimal> Open(string path)
        {
            if ((path == null) || (File.Exists(path) == false))
                throw new ArgumentException("File is not exists");
            List<IGeneralAnimal> lTmp = new List<IGeneralAnimal>();   
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
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
