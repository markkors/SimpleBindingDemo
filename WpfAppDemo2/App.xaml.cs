using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppDemo2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static MainWindow mw;
        public static string DBConnection;


        public App()
        {
            Debug.WriteLine("Ik start op");
            DBConnection = "Nieuwe connectie hier....";

        }

    }
}
