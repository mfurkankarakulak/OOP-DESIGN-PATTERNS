using System;

    namespace StateSample
    {
    //State
    interface ISoketState
    {
        void Handle(Soket s);
    }

    //ConcreteState
    class SoketStateAc:ISoketState
    {
        public void Handle(Soket s)
        {
            Console.WriteLine("{0} Port soket açıldı.",s.Port);
            /*Context birdahaki çalışmasında SoketStateDinle nesnesine göre çalışacak*/
            s.State = new SoketStateDinle(); 
        }
    }

    //ConcreteState
    class SoketStateDinle : ISoketState
    {
        public void Handle(Soket s)
        {
            Console.WriteLine("{0} Port soket Dinleniyor.",s.Port);
            /*Context birdahaki çalışmasında SoketStateKapat nesnesine göre çalışacak*/
            s.State = new SoketStateKapat();
        }
    }

    //ConcreteState
    class SoketStateKapat:ISoketState
    {
        public void Handle(Soket s)
        {
            Console.WriteLine("{0} Port soket Kapatıldı.", s.Port);
            /*Context birdahaki çalışmasında SoketStateAc nesnesine göre çalışacak*/
            s.State = new SoketStateAc();
        }
    }

    //Context
    class Soket
    {
        public int Port { get; set; }
        public Soket(int Port)
        {
            this.Port = Port;
            State = new SoketStateAc();
          
        }

        private ISoketState _State { get; set; }
        public ISoketState State 
        {
            get { return _State; }
            set {
                _State = value;
                /*Senaryoya göre Handle burada da çalıştırılabilir.*/
            }
        }
     


        public void Do()
        {
            State.Handle(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Soket nesnesini oluşturuyoruz 
            her Do metodunu çalıştırdığımızda farklı işlemler çalışacaktır.
            */ 
            Soket s = new Soket(8080);
            s.Do();
            s.Do();
            s.Do();
            Console.ReadKey();
        }
    }
}
