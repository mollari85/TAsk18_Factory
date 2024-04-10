using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk18_Factory.View
{
    internal interface IMainView
    {

        public List<string> Types { get; set; }
        public List<string> Animals { get; set; }
        public string AnimalType { get; set; }
        public string AnimalName { get; set; }
        public string AnimalBreed { get; set; }
        public string AnimalDescription { get; set; }
        public string AnimalAreaLive { get; set; }
        public string AnimalWingColor { get; set; }
        
        public string TailLong { get; set; }

        public void UpdateType();

        public void UpdatelListAnimals();
        public void UpdateView();
    }
}
