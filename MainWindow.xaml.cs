using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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

        private string[] _maanden = new string[12];

        private oMaand[] _zodiacs = new oMaand[12];

        private List<string> _maandenGL = new List<string>();

        private ObservableCollection<oSom> _Sommen = new ObservableCollection<oSom>();    

        private string _selectedMonth;

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
            OnPropertyChanged("Tijd");

            cmbSommen.SelectionChanged += CmbSommen_SelectionChanged;


            _maanden[0] = "januari";
            _maanden[1] = "februari";
            _maanden[2] = "maart";
            _maanden[3] = "april";
            _maanden[4] = "mei";
            _maanden[5] = "juni";
            _maanden[6] = "juli";
            _maanden[7] = "augustust";
            _maanden[8] = "september";
            _maanden[9] = "oktober";
            _maanden[10] = "november";
            _maanden[11] = "december";

            for (int i=0;i < _maanden.Length; i++)
            {
                Debug.WriteLine(_maanden[i]);

            }

            foreach(string m in _maanden)
            {
                Debug.WriteLine(m);
            }

            fill_zodiacs();
            fill_GL();

            // voeg 10 sommen toe

            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                addSom(r);
            }
            
        }

        private void CmbSommen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           oSom s = (oSom)e.AddedItems[0];
           Oplossing = s.Oplossing.ToString();
           OnPropertyChanged("Oplossing");
        }

        private void addSom(Random r)
        {
            
            GeneratedSum = new oSom(r);
            GeneratedSum.generate();
            Sommen.Add(GeneratedSum);
            OnPropertyChanged("Sommen");
            
        }

        private void fill_GL()
        {

            for (int i = 0; i<12; i++)
            {
                _maandenGL.Add(i.ToString());
            }
            
        }

        private void fill_zodiacs()
        {
            for (int i = 0; i < _zodiacs.Length; i++)
            {
                oMaand NewZodiac = new oMaand();
                NewZodiac.name = "sterrebeeld " + i;
                NewZodiac.zodiac = "zodiac " + i;
                _zodiacs[i] = NewZodiac; 

            }
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
        
        public string[] maanden
        {
            get
            {
                return _maanden;
            }
            set
            {
                _maanden = value;
                OnPropertyChanged("maanden");
            }
        }

        public string SelectedMonth { 
            get 
            { 
                return _selectedMonth;
            }
            
            set 
            { 
                _selectedMonth = value;
                OnPropertyChanged("SelectedMonth");
            }
        }

        public oSom GeneratedSum { get; set; }

        public string Oplossing { get; set; }

        public ObservableCollection<oSom> Sommen { 
            get 
            { return _Sommen; } 
            set 
            { 
                _Sommen = value;
                OnPropertyChanged("Sommen");
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
