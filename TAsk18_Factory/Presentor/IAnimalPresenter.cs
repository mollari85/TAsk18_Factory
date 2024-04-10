using AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk18_Factory.Presentor
{
    internal interface IAnimalPresenter
    {
        public void Save();
        public void Cancel();
        public void Create();
        public void FulfillView(IGeneralAnimal Animal);
        public IEnumerable<string> GetAnimalTypes();
    }
}
