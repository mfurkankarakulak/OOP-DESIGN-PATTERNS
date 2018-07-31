using System;
using System.Collections.Generic;

namespace ObserverSample
{
    //Subject
    abstract class absUrun
    {
        public string UrunAdi { get; set; }
        private decimal _Fiyat;

        /*Direkt erişim yerine private tanımlanıp, tanımlanacak metotlar ile yapılabilir.*/
        //Observer nesne listesi
        public List<IUye> TakipList = new List<IUye>();

        public absUrun(string UrunAd, decimal UrunFiyat)
        {
            this.UrunAdi = UrunAd;
            this._Fiyat = UrunFiyat;
        }

        public decimal Fiyat
        {
            get { return _Fiyat; }
            set
            {
                //fiaytı düşmüş ise üyelere haber ver
                if (_Fiyat > value)
                    NotifyUrun();
                _Fiyat = value;
            }
        }

        public void NotifyUrun()
        {
            foreach (IUye item in TakipList)
            {
                item.Update(this);
            }
        }
    }

    //ConcreteSubject
    class Urun : absUrun
    {
        public Urun(string UrunAd, decimal Fiyat)
            : base(UrunAd, Fiyat)
        {

        }
    }

    //Observer
    interface IUye
    {
        void Update(absUrun urun);
    }

    //ConcreteObserver
    class Uye : IUye
    {
        public string E_Mail { get; set; }

        public void Update(absUrun u)
        {
            Console.WriteLine("{0} ın fiyatı {1} oldu {2} adresine gönderildi.", u.UrunAdi, u.Fiyat.ToString("C2"), E_Mail);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //İlk olarak Subject nesnemizi oluşturuyoruz.
            absUrun Kitap = new Urun("Kitap", 10.25M);

            //Subject nesnemiz ile ilgili olan Uye (observer) listesine nesne ekliyoruz.
            Kitap.TakipList.Add(new Uye { E_Mail = "a@a.com" });
            Kitap.TakipList.Add(new Uye { E_Mail = "b@b.com" });

            //Subject yani ürün fiyatını değiştirdiğimizde listedeki 
            //observer nesnelerinin ilgili metodu çalıştırılacak
            Kitap.Fiyat = 8.99M;

            Console.ReadKey();
        }
    }
}
