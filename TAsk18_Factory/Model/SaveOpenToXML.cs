using AnimalType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TAsk18_Factory.Model
{
    internal class SaveOpenToXML:ISaveOpen
    {
        public void Save(IEnumerable<IGeneralAnimal> Animals)
        {
            AnimalToSerialize ListToSerialize=new AnimalToSerialize(Animals);
            XmlSerializer serializer=new XmlSerializer(typeof(AnimalToSerialize));
            using (FileStream fs = new FileStream("Animlas.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, ListToSerialize);
            }
        }
        public IEnumerable<IGeneralAnimal> Open()
        {
            List<IGeneralAnimal> lTmp=new List<IGeneralAnimal>();
           // AnimalToSerialize ListFromSerialize = new AnimalToSerialize(Animals);
            XmlSerializer serializer = new XmlSerializer(typeof(AnimalToSerialize));
            using (FileStream fs = new FileStream("Animlas.xml", FileMode.OpenOrCreate))
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
