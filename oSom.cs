using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z.Expressions;

namespace SimpleBindingDemo
{
    public class oSom
    {

        private string[] _operator = new string[] { "+", "-", "*" };

        private string _oplossing;

        public void generate()
        {

            Random rnd = new Random();
            int x = rnd.Next(1, 100);
            int y = rnd.Next(1, 100);
            int o = rnd.Next(0, 2);


            int result = Eval.Execute<int>("X" + _operator[o] + "Y", new { X = x, Y = y });
            _oplossing = result.ToString();

        }

    }
}
