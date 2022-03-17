using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfAppDemo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public string naam;

        public MainWindow()
        {
            
            InitializeComponent();
            OpenWindow2.Click += OpenWindow2_Click;
            App.mw = this;
            Debug.WriteLine(App.DBConnection);
        }

        private void OpenWindow2_Click(object sender, RoutedEventArgs e)
        {
            naam = "waarde x";
            SecondWindow sw = new SecondWindow();
            sw.ShowDialog();


        }
    }
}
