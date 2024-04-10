using AnimalType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TAsk18_Factory.Model;
using TAsk18_Factory.View;

namespace TAsk18_Factory.Presentor
{
    internal class MainViewPresenter : IMainViewPresenter
    {
        private IAnimalModel _Model { get; set; }
        private IMainView _View { get; set; }
        // public ObservableCollection<string> TypeAnymal { get; set; } 
        IGeneralAnimal CurrentAnimal;

        public void CommandSave()
        {
            _Model.Save();
            MessageBox.Show("Saving compleated");
        }
        public void CommandLoad()
        {
            _Model.Open();
            _View.UpdateView();
            MessageBox.Show("Loading compleated");
        }
        public void CommandCreate()
        {

            AnimalView ViewAnimal = new AnimalView();
            AnimalPresenter PresenterAnimal = new AnimalPresenter(ViewAnimal,_Model);
            ViewAnimal.Presenter= PresenterAnimal;
            ViewAnimal.ShowDialog();
        }
        public void CommandUpdate()
        {
            if ((_View.AnimalName != null) && (_Model.GetAnimalByName(_View.AnimalName) != null))
            {
                AnimalView ViewAnimal = new AnimalView();
                AnimalPresenter PresenterAnimal = new AnimalPresenter(ViewAnimal, _Model);
                ViewAnimal.Presenter = PresenterAnimal;
                CurrentAnimal = _Model.GetAnimalByName(_View.AnimalName);
                PresenterAnimal.FulfillView(CurrentAnimal);
                ViewAnimal.ShowDialog();
                UpdateAnimalsFields(CurrentAnimal.Name);
            }
            else
                MessageBox.Show(_View.AnimalName + " not found");
        }
        public void CommandRemove(string AnimalName)
        {

            if (_Model.GetAnimalByName(AnimalName) == null)
                return;
            _Model.Remove(_Model.GetAnimalByName(AnimalName));
            _View.UpdateView();
        }
        public MainViewPresenter(IMainView view, IAnimalModel model) 
        {
            _Model = model;
            _View = view;

            //   View.Types=Model.
         //   TypeAnymal = new ObservableCollection<string>(GetAnimalsTypes());

        }
        public MainViewPresenter(IMainView view)
        {
            _Model = new AnimalModel();
            _View = view;
            _Model.AnimalModelChanged +=(obj, EventArgs) =>_View.UpdateView();
            //   View.Types=Model.
            // TypeAnymal = new ObservableCollection<string>(GetAnimalsTypes());

        }
        public IEnumerable<string> GetAnimalTypes()
        {
            List<string> types = new List<string>();
            var tmp = _Model.Animals.GroupBy(p => p.Type);
            foreach(var i in tmp)
                types.Add(i.Key);
            _View.Types=types;
            return types;
        }

        public IEnumerable<string> GetAnimals(string type) 
        {
            List<string> lTmp = new List<string>();
            var tmp = _Model.Animals.Where(x => x.Type == type);

            foreach (var i in tmp)
                lTmp.Add(i.Name);
            _View.Animals = lTmp;
            _View.UpdatelListAnimals();
            return lTmp;
        }
        public void UpdateAnimalsFields(string selectedAnimalName)
        {
            CurrentAnimal = _Model.GetAnimalByName(selectedAnimalName);
            if (CurrentAnimal != null)
            {
                _View.AnimalName = CurrentAnimal.Name;
                _View.AnimalAreaLive = CurrentAnimal.AreaLive;
                _View.AnimalType = CurrentAnimal.Type;
                _View.AnimalBreed = CurrentAnimal.Breed;
                _View.AnimalDescription = CurrentAnimal.Description;
            }
            else 
            {
                _View.AnimalName = null;
                _View.AnimalAreaLive = null;
                _View.AnimalType = null;
                _View.AnimalBreed = null;
                _View.AnimalDescription = null;
                _View.TailLong = null;
                _View.AnimalWingColor = null;
            }
            if (CurrentAnimal is Amphibian amphibian)
            {
                _View.TailLong = amphibian.TailLong.ToString();
            }
            if (CurrentAnimal is Bird bird)
            {
                _View.AnimalWingColor = bird.WingColor;
            }
        }
    }
}
