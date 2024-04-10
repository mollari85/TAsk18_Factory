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
using System.Windows.Shapes;
using System.Xml.Linq;
using TAsk18_Factory.Presentor;

namespace TAsk18_Factory.View
{
    /// <summary>
    /// Interaction logic for AnimalView.xaml
    /// </summary>
    public partial class AnimalView : Window, IAnimalView
    {
        internal IAnimalPresenter Presenter;
        public List<string> Types { get; set; }
        public string SelectedType { get { return (cbType.SelectedItem is null)? null:cbType.SelectedItem.ToString(); } set{ cbType.SelectedItem = value;  }  }
        public List<string> Animals { get; set; } = new List<string>();
        
        public string AnimalName { get { return tbName.Text; } set { tbName.Text = value; } }
        public string AnimalBreed { get { return tbBreed.Text; } set { tbBreed.Text = value; } }
        public string AnimalDescription { get { return tbDescription.Text; } set { tbDescription.Text = value; } }
        public string AnimalAreaLive { get { return tbAreaLive.Text; } set { tbAreaLive.Text = value; } }
        public string AnimalWingColor { get { return tbWingsColor.Text; } set { tbWingsColor.Text = value; } }
        public string TailLong { get { return tbTailLong.Text; } set { tbTailLong.Text = value; } }
        public AnimalView()
        {
            InitializeComponent();
           // Presenter = new AnimalPresenter(this);

        }
        public void Save()
        { 
        }
        public void Cancel()
        {
            this.DialogResult = false;;
            
        }
        public void CloseView()
        {
            
            this.DialogResult = true;
           
        }
        private void BtnClickSave(object sender, RoutedEventArgs e) => Presenter.Save();

        private void BtnClickCancel(object sender, RoutedEventArgs e)=>Presenter.Cancel();

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Types = Presenter.GetAnimalTypes().ToList();
            cbType.ItemsSource = Types;
        }
    }
}
