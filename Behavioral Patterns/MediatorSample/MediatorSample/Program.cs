using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorSample
{
    //mediator yapısı
    interface IKule
    {
        //Kulenin gerçekleştirmesi gereken operasyonlar
        void UcakKayit(AbsUcak _ucak); 
        void InisIzniCevap(string UcusNo);
    }

    //Colleague yapısı
    abstract class AbsUcak
    {
        //Uçağın hangi kule ile irtibata geçmesi gerektiğini tutması gerekir.
        public IKule IliskiliKule { get; set; }
        public string UcusNo { get; set; }
        public bool InisIzni { get; set; }

        public void InisIzniIste()
        {
            //uçağın bağlı olduğu kuleden iniş izni istiyor
            IliskiliKule.InisIzniCevap(UcusNo);
        }

        public virtual void SetInisIzni(bool Izin)
        {
            //kule iniş izni isteyen uçağa bu metot ile cevap verir.
            InisIzni = Izin;
            if (InisIzni)
                Console.WriteLine("İniş izni verildi.");
            else
                Console.WriteLine("İniş izni red edildi.");
        }
    }

    //ConcreteMediator yapısı
    class EsenbogaKule : IKule
    {
        //Kule kendisine bağlı olan uçakların bilgisini tutmak zorunda ki isteklere buna göre cevap verebilsin.
        private List<AbsUcak> _UcakListe = new List<AbsUcak>();

        public void UcakKayit(AbsUcak _ucak)
        {
            _UcakListe.Add(_ucak);
            //Listeye eklenen AbsUcak nesnesine yöneticisinin bu sınıf olduğunu bildiriyoruz.
            _ucak.IliskiliKule = this; 
        }

        public void InisIzniCevap(string UcusNo)
        {
            bool izin = true;
            // eğer başka bir uçağa iniş izni verilmedi ise ilk izin isteyen uçağa izin ver
            if (_UcakListe.Where(u => u.InisIzni == true).Count() > 0)
                izin = false;
            //uçağın cevap alması için barındırdığı metoda cevap verilir.
            _UcakListe.Where(u => u.UcusNo == UcusNo).Single().SetInisIzni(izin);
        }
    }

    //ConcreteColleague1
    class ThyUcak : AbsUcak
    {
        //InisIzniIste metotu AbsUcak abstract sınıfından gelir.
        //Kule cevabı mu metot ile verir.
        public override void SetInisIzni(bool Izin)
        {
            Console.WriteLine("Thy Uçuş No:{0} iniş izni istiyor...", UcusNo );
            base.SetInisIzni(Izin);
        }
    }

    //ConcreteColleague2
    class UsaUcak : AbsUcak
    {
        //ConcreteColleague1 yapısı için geçerli olanlar bu yapı için de geçerlidir.
        public override void SetInisIzni(bool Izin)
        {
            Console.WriteLine("Usa Uçuş No:{0} iniş izni istiyor...", UcusNo);
            base.SetInisIzni(Izin);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //ilk olarak uçakların bağlı olacağı kule oluşturulur
            IKule kule = new EsenbogaKule();

            //Uçak nesneleri oluşturulur.
            AbsUcak ThyTK001 = new ThyUcak { UcusNo = "ThyTK001"};
            AbsUcak ThyTK002 = new ThyUcak { UcusNo = "ThyTK002"};
            AbsUcak UsaUS001 = new ThyUcak { UcusNo = "UsaUS001"};
            
            //uçak nesneleri kule nesnesine kayıt ettirilir.
            //Uçak nesnesindeki IliskiliKule nesnesi kule nesnesindeki UcakKayit metodunda yapılır.
            kule.UcakKayit(ThyTK001);
            kule.UcakKayit(ThyTK002);
            kule.UcakKayit(UsaUS001);

            //sadece ilk izin isteyen uçağa iniş izni true verilir.
            ThyTK001.InisIzniIste();
            ThyTK002.InisIzniIste();

            ThyTK001.InisIzni = false;

            //ThyTK001 nesnesinin iniş izni iptal edildiği için ThyTK002 nesnesine iniş izni verilir.
            ThyTK002.InisIzniIste();

            Console.ReadKey();
        }
    }
}
