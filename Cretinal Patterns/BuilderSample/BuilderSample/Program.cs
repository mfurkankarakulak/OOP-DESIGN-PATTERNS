using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuilderSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ArabaBuilder araba_builder = new ArabaConcrete1();
            ArabaDirector araba_olusutucu = new ArabaDirector(araba_builder); 
            Console.WriteLine(araba_builder.araba.ToString());

            araba_builder = new ArabaConcrete2();
            araba_olusutucu = new ArabaDirector(araba_builder);
            Console.WriteLine(araba_builder.araba.ToString());

            Console.ReadKey();
        }
    }
}
