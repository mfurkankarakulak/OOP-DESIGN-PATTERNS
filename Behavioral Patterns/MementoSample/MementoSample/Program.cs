using System;

namespace MementoSample
{
    //Originator
    //Tamamının veya bazı özelliklerinin kopyasının alınacağı sınıf
    class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public KisiMemento CreateMemento()
        {
            return new KisiMemento { 
                Ad = this.Ad
                ,Soyad = this.Soyad
                ,Yas = this.Yas
            };
        }

        public void BindMemento(KisiMemento kisi)
        {
            this.Ad = kisi.Ad;
            this.Soyad = kisi.Soyad;
            this.Yas = kisi.Yas;
        }
    }

    //Memento
    //Originator nesnesinin kopyasının tutulacağı özelliklerin tanımlı olduğu sınıf
    class KisiMemento
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

    }

    //Caretaker 
    //kopyası tutulacak Memento sınıfının tutulacağı sınıf
    class KisiMemory
    {
        public KisiMemento KisiKopya { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //bazı özelliklerinin yedeği tutulacak olan Originator sınıfı oluşturuyoruz.
            Kisi k = new Kisi
            {
                Ad = "Ahmet",
                Soyad = "Yılmaz",
                Yas = 95
            };
            Console.WriteLine(k.Ad);

            //Originator sınıfının özelliklerini Memento olarak saklayacak Caretaker sınıfını oluşturuyoruz.
            //Oluşturduğumuz Originator sınıfının özelliklerini Memento cinsinden elde edip saklıyoruz.
            KisiMemory km = new KisiMemory();
            km.KisiKopya = k.CreateMemento();

            //kopyası alındıktan sonra Originator sınıfının özelliğini değiştiriyoruz
            k.Ad = "Mehmet";

            Console.WriteLine(k.Ad);

            //sakladığımız kopyayı Originator sınıfına yükleyip nesneyi eski haline getiriyoruz.
            k.BindMemento(km.KisiKopya);

            Console.WriteLine(k.Ad);
            Console.ReadKey();
        }
    }
}
