using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TAsk18_Factory.Presentor;

namespace TAsk18_Factory.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window,IMainView
    {
        internal IMainViewPresenter Presenter;
        public List<string> Types { get; set; }
        public List<string> Animals { get; set; } = new List<string>();
        public string AnimalType { get { return tbType.Text;  } set { tbType.Text = value; } }
        public string AnimalName { get { return tbName.Text; } set { tbName.Text = value; } }
        public string AnimalBreed { get { return tbBreed.Text; } set { tbBreed.Text = value; } }
        public string AnimalDescription { get { return tbDescription.Text; } set { tbDescription.Text = value; } }
        public string AnimalAreaLive { get {return tbAreaLive.Text; }set { tbAreaLive.Text = value; } }
        public string AnimalWingColor { get { return tbWingsColor.Text; } set { tbWingsColor.Text = value; } }
        public string TailLong { get { return tbTailLong.Text; } set { tbTailLong.Text = value; } }
        public MainView()
        {
            InitializeComponent();
           Presenter = new MainViewPresenter(this);
            Types=new List<string>(Presenter.GetAnimalTypes());
            //Animals

            cbType.ItemsSource=Types;
            listboxAnimals.ItemsSource=Animals;

               
        }

        public void UpdateView()
        {
            UpdateType();
            UpdatelListAnimals();
        }
        
        public void UpdateType()
        {
            Types = Presenter.GetAnimalTypes().ToList();
            cbType.ItemsSource = null;
            cbType.ItemsSource = Types;
           /* cbType.Items.Clear();
            foreach (var i in Types)
            {
                cbType.Items.Add(i);
            }
           */
        }
        public void UpdatelListAnimals() 
        {
            //listboxAnimals.Items.Clear();
            listboxAnimals.ItemsSource = null;
            listboxAnimals.ItemsSource = Animals;
          /*  foreach (var i in Animals)
            {
               listboxAnimals.Items.Add(i);
            }
          */
        }
    
        private void BtnClickCreate(object sender, RoutedEventArgs e)
        {
            Presenter.CommandCreate();
        }
        private void BtnClickSave(object sender, RoutedEventArgs e)
        {
            Presenter.CommandSave();
        }
        private void BtnClickLoad(object sender, RoutedEventArgs e)
        {
            Presenter.CommandLoad();
        }
        private void BtnClickDelete(object sender, RoutedEventArgs e)
        {
            if (listboxAnimals.SelectedItem == null) throw new ArgumentNullException("Argument Exception: Animal is not selected");
            Presenter.CommandRemove(listboxAnimals.SelectedItem.ToString());

        }
        private void BtnClickUpdate(object sender, RoutedEventArgs e)
        {

            Presenter.CommandUpdate();
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbType.SelectedItem != null)
            {
                string sTmp = cbType.SelectedItem.ToString();
                Animals = Presenter.GetAnimals(sTmp).ToList();
            }
            else Animals = null;

        }

        private void listboxAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listboxAnimals.SelectedItem!= null)
                Presenter.UpdateAnimalsFields(listboxAnimals.SelectedItem.ToString());
            else
                Presenter.UpdateAnimalsFields(null);
        }


    }
}
