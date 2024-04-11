using AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk18_Factory.Model
{
    internal interface ISaveOpen
    {
        public void Save(IEnumerable<IGeneralAnimal> tmp, string s);
        public IEnumerable<IGeneralAnimal> Open(string s);
    }
}
