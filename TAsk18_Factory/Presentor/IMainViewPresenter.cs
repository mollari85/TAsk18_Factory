using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TAsk18_Factory.Presentor
{
    internal interface IMainViewPresenter
    {

        internal IEnumerable<string> GetAnimalTypes();
        internal IEnumerable<string> GetAnimals(string type);
        internal void UpdateAnimalsFields(string selectedAnimalName);

        internal void CommandSave();
        internal void CommandLoad();
        internal void CommandCreate();
        internal void CommandUpdate();
        internal void CommandRemove(string name);
    }

}
