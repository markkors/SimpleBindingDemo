using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Z.Expressions;

namespace SimpleBindingDemo
{
    public class oSom: INotifyPropertyChanged

    {

        private string[] _operator = new string[] { "+", "-", "*","/" };
        private Random _rnd;

        public event PropertyChangedEventHandler PropertyChanged;

        public oSom(Random r)
        {
            _rnd = r;
           
        }

        public void generate()
        {


            // instelling voor de EVAL functie zodat ook doubles werken
            EvalManager.DefaultContext.DefaultNumberType = DefaultNumberType.Double;


            int x = _rnd.Next(1, 100);
            int y = _rnd.Next(1, 100);
            int o =_rnd.Next(0, 4);
            

            Question = String.Format("{0} {1} {2}", x, _operator[o], y);
            double result = Eval.Execute<double>(Question);
            Debug.WriteLine(result);
            Oplossing = result.ToString();


            OnPropertyChanged("Oplossing");
            OnPropertyChanged("Question");
        }


        public string Oplossing { get; set; }
        public string Question { get; set; }


        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
