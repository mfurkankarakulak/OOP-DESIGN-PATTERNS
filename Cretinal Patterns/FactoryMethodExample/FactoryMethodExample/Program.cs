using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethodExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Yöntem 1
            Creator1 RaporCreator = new Creator1();

            IRapor rapor = RaporCreator.RaporFactory(RaporTip.Grafik);
            rapor.Olustur();

            rapor = RaporCreator.RaporFactory(RaporTip.Tablo);
            rapor.Olustur();

            Console.WriteLine("");

            // Yöntem 2
            IRaporCreator[] Creators = { 
                                          new CreatorTabloRapor()
                                        , new CreatorGrafikRapor()
                                       };

            foreach (IRaporCreator item in Creators)
            {
                IRapor _rapor = item.CreateRapor();
                _rapor.Olustur();
            }
            Console.ReadKey();
        }
    }
}
