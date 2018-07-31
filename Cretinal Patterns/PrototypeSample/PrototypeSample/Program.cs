using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Kisi k = new Kisi { Ad = "Ahmet", DogumTarihi = DateTime.Now };
            Kisi k2 = k.Clone() as Kisi;
            k2.Ad = "Mehmet";

            Console.WriteLine(k.Ad);
            Console.WriteLine(k2.Ad);

            Urun u = new Urun { Name = "Cep Telefonu XWZ19", Price = 100.00f };
            Urun u2 = u.Clone() as Urun;
            u2.Name = "Buzdolabı X999";

            Console.WriteLine(u.Name);
            Console.WriteLine(u2.Name);

            Console.ReadKey();
        }
    }
}
