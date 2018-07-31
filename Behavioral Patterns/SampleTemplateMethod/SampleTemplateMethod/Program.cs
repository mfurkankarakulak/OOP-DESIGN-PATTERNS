using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleTemplateMethod
{
    //Template yapısı
    abstract class Operation
    {
        private void OpenCon()
        {
            Console.WriteLine("Connection Open");
        }

        /*
            bu abstract sınıfı uygulayan sınıfların sadece Insert ve CheckData da yapılacak
            işlemleri overwrite etmesi gereklidir.
        */
        public abstract void Insert();

        public abstract bool CheckData();

        private void CloseCon()
        {
            Console.WriteLine("Connection Close");
        }

        //Bu sınıfı uygulayan sınıfların her işlemde connection u açmaya ve kapatmaya ihtiyacı kalmamıştır.
        //connection açma ve kapama işlemleri TemplateMethod larda yapılıyor.
        public void TemplateInsert()
        {
            OpenCon();
            Insert();
            CloseCon();
        }

        public bool TemplateCheckData()
        {
            OpenCon();
            bool Check = CheckData();
            CloseCon();
            return Check;
        }
    }

    //ConcreteTemplateMethod
    class OperationContact : Operation
    {
        //Insert işlemi bu sınıfa göre yazılması gerektiğinden overwrite ediliyor.
        public override void Insert()
        {
            Console.WriteLine("Contact Kayıt Eklendi.");
        }

        public override bool CheckData()
        {
            //Kontroller yapıldığını varsayalım...
            Console.WriteLine("Contact Kayıt Bulundu.");
            return true;
        }

    }

    //ConcreteTemplateMethod
    class OperationProduct : Operation
    {
        public override void Insert()
        {
            Console.WriteLine("Product Kayıt Eklendi.");
        }

        public override bool CheckData()
        {
            //Kontroller yapıldığını varsayalım...
            Console.WriteLine("Product Kayıt Bulundu.");
            return true;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            OperationContact o = new OperationContact();
            o.TemplateInsert();

            OperationProduct op = new OperationProduct();
            o.TemplateCheckData();

            Console.ReadKey();
        }
    }
}
