using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeSample
{
    //yardımcı enum
    enum enPozisyon
    {
        GenelMudur = 1,
        Mudur = 2,
        DepartmanSorumlusu = 3,
        Isci = 4,
    }

    //component yapısı
    abstract class Calisan
    {
        protected string Ad;
        protected enPozisyon Pozisyon;
        public Calisan(string Ad, enPozisyon Pozisyon)
        {
            this.Ad = Ad;
            this.Pozisyon = Pozisyon;
        }

        public abstract void Goster(); //Leaf ve Composite de uygulanacak metot
    }

    //Leaf yapısı
    class LeafCalisan : Calisan
    {
        public LeafCalisan(string Ad, enPozisyon Pozisyon)
            : base(Ad, Pozisyon)
        {

        }

        public override void Goster()
        {
            Console.WriteLine("{0} {1}", base.Pozisyon.ToString(), base.Ad);
        }
    }


    //Composite  yapısı
    class CompositeCalisan : Calisan
    {
        List<Calisan> Calisanlari;
        public CompositeCalisan(string Ad, enPozisyon Pozisyon)
            : base(Ad, Pozisyon)
        {
            Calisanlari = new List<Calisan>();
        }

        public void Ekle(Calisan c)
        {
            Calisanlari.Add(c);
        }

        public override void Goster()
        {
            Console.WriteLine("{0} {1}", base.Pozisyon.ToString(), base.Ad);
            foreach (Calisan item in Calisanlari)
            {
                item.Goster();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //İlk olarak Root Composite yi oluşturuyoruz
            CompositeCalisan GenelMudur = new CompositeCalisan("Kemalettin", enPozisyon.GenelMudur);

            //Genel müdürün altında çalışan diğer çalışanları hiyerarşik olarak ekliyoruz
            //Altında eleman olmayan çalışanlar LeafCalisan sınıfı ile ifade edilir.
            CompositeCalisan Mudur = new CompositeCalisan("Ahmet ", enPozisyon.Mudur);
            Mudur.Ekle(new LeafCalisan("mehmet ", enPozisyon.Isci));
            Mudur.Ekle(new LeafCalisan("ayşe ", enPozisyon.Isci));

            //Root komposite altındaki Composite yi ekliyoruz.
            GenelMudur.Ekle(Mudur);

            //Composite için döngü ile altındaki Calisan sınıfları, Leaf için sadece kendisi
            GenelMudur.Goster();

            Console.ReadKey();

        }
    }
}
