using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodExample
{
    /// <summary>
    /// Product Interface
    /// </summary>
    public interface IRapor
    {
        void Olustur();
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class RaporTablo : IRapor
    {
        public void Olustur()
        {
            Console.WriteLine("Tablo şeklinde rapor");
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class RaporGrafik : IRapor
    {
        public void Olustur()
        {
            Console.WriteLine("Grafik şeklinde rapor");
        }
    }
}
