using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFactorySamplePc
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory f = new Factory(new Concrete1Factory());
            f.Birlestir();

            Console.WriteLine();

            f = new Factory(new Concrete2Factory());
            f.Birlestir();

            Console.ReadKey();
        }
    }
}
