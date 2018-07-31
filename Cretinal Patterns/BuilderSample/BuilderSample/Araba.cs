using System;

namespace BuilderSample
{
    // Araba sınıfı builder desenindeki Product yapısıdır.
    public class Araba
    {
        public string Marka { get; set; }
        public string Motor { get; set; }
        public string Lastik { get; set; }

        public override string ToString()
        {
            return String.Format("Marka:{0},Motor:{1},Lastik:{2}", Marka, Motor, Lastik);
        }
    }

    // ArabaBuilder arayüzü builder desenindeki Builder yapısıdır. 
    // Bir sınıfın Product ı oluşturan nesneleri oluşturması veya product ın özelliklerini setlemesi ile product ı oluşturan sınıflar bu arayüzü kullanmalıdır.
    public abstract class ArabaBuilder
    {
        protected Araba _araba;
        public Araba araba
        {
            get { return _araba; }
        }
        public abstract void MotorTak();
        public abstract void LastikTak();
    }

    // ArabaBuilder arayüzünden türeyen bütün sınıflar Builder desenindeki ConcreteBuilder yapısıdır.
    // ConcreteBuilder yapısı değişik product nesnelerinin oluşturulmasını sağlamaktır.
    public class ArabaConcrete1 : ArabaBuilder
    {
        public ArabaConcrete1()
        {
            _araba = new Araba { Marka = "Concrete1" };
        }

        public override void MotorTak()
        {
            _araba.Motor = "1.4 LPG";
        }

        public override void LastikTak()
        {
            _araba.Lastik = "15' Çelik jant";
        }
    }

    public class ArabaConcrete2 : ArabaBuilder
    {
        public ArabaConcrete2()
        {
            _araba = new Araba { Marka = "Concrete2" };
        }

        public override void MotorTak()
        {
            _araba.Motor = "1.8 Dizel";
        }

        public override void LastikTak()
        {
            _araba.Lastik = "17' Bor alaşımlı çelik jant";
        }
    }

    // ArabaBuilder arayüzündeki metodları çalıştırarak productın oluşturulmasını sağlar.
    // Builder desenindeki Director yapısıdır.
    public class ArabaDirector
    {
        public ArabaDirector(ArabaBuilder ArabaConcrete)
        {
            ArabaConcrete.MotorTak();
            ArabaConcrete.LastikTak();
        }
    }
}
