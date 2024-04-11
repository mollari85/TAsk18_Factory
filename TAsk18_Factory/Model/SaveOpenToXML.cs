using AnimalType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace TAsk18_Factory.Model
{
    internal class SaveOpenToXML:ISaveOpen
    {
        public void Save(IEnumerable<IGeneralAnimal> Animals, string path)
        {
            if ((path == null))
                throw new ArgumentException("File path  is null");
            AnimalToSerialize ListToSerialize=new AnimalToSerialize(Animals);
            XmlSerializer serializer=new XmlSerializer(typeof(AnimalToSerialize));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, ListToSerialize);
            }
        }
        public IEnumerable<IGeneralAnimal> Open(string path)
        {
            if ((path == null) || (File.Exists(path) == false))
                throw new ArgumentException("File is not exists");

            List<IGeneralAnimal> lTmp=new List<IGeneralAnimal>();
           // AnimalToSerialize ListFromSerialize = new AnimalToSerialize(Animals);
            XmlSerializer serializer = new XmlSerializer(typeof(AnimalToSerialize));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                AnimalToSerialize? ListFromSerialize=serializer.Deserialize(fs) as AnimalToSerialize;
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
