using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VisitorSample
{
    //Visitor yapısı
    interface ITelVisitor
    {
        void Visit(TelModel1 tel);
        void Visit(TelModel2 tel);
    }

    //ConcreteVisitor yapısı
    class MesajModulVisitor : ITelVisitor
    {
        public void Visit(TelModel1 tel)
        {
            Console.WriteLine("TelModel1 mesaj gönderebileceğinden mesaj gönderiliyor...");
        }

        public void Visit(TelModel2 tel)
        {
            Console.WriteLine("TelModel2 mesaj gönderme özelliğine sahip değildir...");
        }
    }

    //ConcreteVisitor yapısı
    class MmsModulVisitor : ITelVisitor
    {
        public void Visit(TelModel1 tel)
        {
            Console.WriteLine("TelModel1 MMS gönderemez...");
        }

        public void Visit(TelModel2 tel)
        {
            Console.WriteLine("TelModel2 MMS gönderebileceğinden gönderiyor...");
        }
    }

    //Element
    interface ITelefon
    {
        void Ara(string No);
        void ModuluYukle(ITelVisitor t);
    }

    //ConcreteElement
    class TelModel1 : ITelefon
    {
        public void Ara(string No)
        {
            Console.WriteLine("TelModel1 " + No + " nosunu aranıyor...");
        }


        public void ModuluYukle(ITelVisitor t)
        {
            t.Visit(this);
        }
    }

    //ConcreteElement
    class TelModel2 : ITelefon
    {
        public void Ara(string No)
        {
            Console.WriteLine("TelModel2 " + No + " nosunu aranıyor...");
        }

        public void ModuluYukle(ITelVisitor t)
        {
            t.Visit(this);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //İlk başta sadece ITelefon arayüzü ve bunu uygulayan sınıflar var
            //ITelefon arayüzünde ise sadece ara metodu var

            ITelefon Model1 = new TelModel1();
            ITelefon Model2 = new TelModel2();

            Model1.Ara("0212-111-22-33");
            Model2.Ara("0212-444-55-66");

            //Sonra ITelefon arayüzünü uygulayan sınıfların bazılarına yeni özellikler eklemek gerekti.
            //İlk olarak ITelefon arayüzünü uygulayan sınıflara göre Visitor Interface yi tanımlıyoruz.
            //Ardından ekleyeceğimiz her özellik için bu arayüzü uygulayan ConcreteVisitor sınıflarını yazıyoruz.
            //Mesaj Gönderim için MesajModulVisitor sınıfını oluşturuyoruz
            ITelVisitor MesajVisitor = new MesajModulVisitor();
            Model1.ModuluYukle(MesajVisitor);
            Model2.ModuluYukle(MesajVisitor);

            //Ve sonrada MMS gönderimi icat oldu ve MMS için MmsModulVisitor sınıfını oluşturuyoruz.
            ITelVisitor MmsVisitor = new MmsModulVisitor();

            Model1.ModuluYukle(MmsVisitor);
            Model2.ModuluYukle(MmsVisitor);

            Console.ReadKey();
        }
    }
}
