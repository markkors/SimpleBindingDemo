using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace SimpleBindingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private string _Tijd;

        public MainWindow()
        {
            InitializeComponent();
            Supermarkt = "Jumbo";
            Snackbar = "Het haasje";
            this.DataContext = this;

            MyButton.Click += MyButton_Click;
            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(1000);
            
            Tijd = DateTime.Now.ToString("h:mm:ss tt");
            //OnPropertyChanged("Tijd");
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Tijd = DateTime.Now.ToString("h:mm:ss tt");
            //OnPropertyChanged("Tijd");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            Supermarkt = "Albert Heijn";
            OnPropertyChanged("Supermarkt");
        }

        public string Supermarkt { get; set; }
        public string Snackbar  { get; set; }
        public string Tijd { 
            get { return _Tijd; } 
            set { 
                _Tijd = value;
                OnPropertyChanged("Tijd");
            } 
        }
        

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
