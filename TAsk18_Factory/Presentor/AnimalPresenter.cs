using AnimalType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using TAsk18_Factory.Model;
using TAsk18_Factory.View;

namespace TAsk18_Factory.Presentor
{
    internal class AnimalPresenter : IAnimalPresenter
    {
        IAnimalView _View;
        IAnimalModel _Model;
        internal FactoryManager AnimalFactoryManager = new FactoryManager();
        IGeneralAnimal GeneralAnimal;

        public AnimalPresenter(IAnimalView View, IAnimalModel Model)
        {
            _View = View;
            _Model = Model;

        }
        public IEnumerable<string> GetAnimalTypes() => _Model.GetAnimalTypes();
        public void FulfillView(IGeneralAnimal Animal)
        {
            if (Animal == null) throw new ArgumentNullException("Argument ANimal is null");
            GeneralAnimal = Animal;
            _View.AnimalAreaLive = Animal.AreaLive;
            _View.AnimalName = Animal.Name;
            _View.AnimalDescription = Animal.Description;
            _View.AnimalBreed = Animal.Breed;
            _View.SelectedType = Animal.Type;
            if (Animal is Bird tmpBird) _View.AnimalWingColor = tmpBird.WingColor;
            if (Animal is Mammal tmpMammal) { }
            if (Animal is Amphibian tmpAmphibian) _View.TailLong = tmpAmphibian.TailLong.ToString();


        }
        public void Create()
        {
            if ((_View.SelectedType == null) || (_View.AnimalBreed == null) || (_View.AnimalAreaLive == null) || (_View.AnimalName == null))
            {
                MessageBox.Show("Error. Fullfill necessary properties");
                return;
            }
            if  (AnimalFactoryManager.GetAnimalFactory(_View.SelectedType + "Factory") != null)
            {
                GeneralAnimal = AnimalFactoryManager.GetAnimalFactory(_View.SelectedType + "Factory").CreateAnimal(
                    _View.AnimalBreed, _View.AnimalName, _View.AnimalDescription, _View.AnimalAreaLive);
                SetPropertyForSpecificType(GeneralAnimal);
                _Model.Add(GeneralAnimal);
            }
            /*
            if (GeneralAnimal is Bird tmpBird)
            {
                tmpBird.WingColor = _View.AnimalWingColor;
                _Model.Add(tmpBird);
                
            }
            if (GeneralAnimal is Mammal tmpMammal)
            {
                //  tmpMammal.FurColor = _View.FurColor;
                _Model.Add(tmpMammal);
               
            }
            if (GeneralAnimal is Amphibian tmpAmphibian)
            {
                Int32.TryParse(_View.TailLong, out int tmpInt);
                tmpAmphibian.TailLong = tmpInt;
                _Model.Add(tmpAmphibian);
            }
            //error
            else _Model.Add(GeneralAnimal);
            */
            MessageBox.Show("Animal has been created");
            _View.Close();

        }
        private void SetPropertyForSpecificType(IGeneralAnimal Animal)
        {
            if (Animal is Bird )
            {
                ((Bird)Animal).WingColor = _View.AnimalWingColor;
            }
            if (Animal is Mammal tmpMammal)
            {

            }
            if (Animal is Amphibian )
            {
                Int32.TryParse(_View.TailLong, out int tmpInt);
                ((Amphibian)Animal).TailLong = tmpInt;
            }
          
        }
        private  void SetPropertyForGeneralType(IGeneralAnimal Animal)
        {
            Animal.Breed = _View.AnimalBreed;
            Animal.AreaLive = _View.AnimalAreaLive;
            Animal.Name = _View.AnimalName;
            Animal.Description = _View.AnimalDescription;
           
        }
        public void Cancel()
        { 
            _View.Cancel();
        }
        public void Save()
        {
            if (GeneralAnimal == null)
            {
                Create();
                
            }

            else
            {
            
                IGeneralAnimal tmpAnimal = _Model.GetAnimalByName(GeneralAnimal.Name);
                SetPropertyForGeneralType(tmpAnimal);
                SetPropertyForSpecificType(tmpAnimal);
                MessageBox.Show("Animal has been updated");
            }
            _View.Close();
        }
    }
}
