using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorSample
{

    //Component
    interface IUyeOperation
    {
        void Ekle();
        void Sil();
    }

    //ConcreteComponent
    class UyeOperation : IUyeOperation
    {
        public void Ekle()
        {
            Console.WriteLine("üye eklendi.");
        }

        public void Sil()
        {
            Console.WriteLine("üye silindi.");
        }
    }

    //Decorator
    abstract class UyeOperationDecorator : IUyeOperation
    {
        IUyeOperation uOperation;

        public UyeOperationDecorator(IUyeOperation uOperation)
        {
            this.uOperation = uOperation;
        }

        public void Ekle()
        {
            uOperation.Ekle();
        }

        public void Sil()
        {
            uOperation.Sil();
        }
    }

    //ConcreteDecorator
    class UyeMesajOperation : UyeOperationDecorator
    {
        public UyeMesajOperation(IUyeOperation uOperation)
            : base(uOperation)
        {

        }

        public void MesajGonder(string mesaj)
        {
            Console.WriteLine("{0} mesajı gönderildi.", mesaj);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //decorator uygulanacak component nesnesi
            UyeOperation oUye = new UyeOperation();

            //mesaj decorator nesnesine component i veriyoruz
            UyeMesajOperation dUye = new UyeMesajOperation(oUye);

            //decorator üzerinden component yeni metotlara sahip oluyor.
            dUye.Ekle();

            dUye.MesajGonder("decorator mesaj");

            Console.ReadKey();
        }
    }
}
