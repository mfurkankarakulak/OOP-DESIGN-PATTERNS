using System;

namespace CommandSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Kisi Kisi = new Kisi { ID = 1, Ad = "Ahmet" };

            ReceiverKisi rk1 = new ReceiverKisi(Kisi);
            
            CommandKisi ckAdd = new ConcreteCommandKisiEkle(rk1);
            CommandKisi ckSil = new ConcreteCommandKisiSil(rk1);

            InvokerKisi ik = new InvokerKisi();

            ik.CommandKisiList.Add(ckAdd);
            ik.CommandKisiList.Add(ckSil);

            ik.ExecuteAll();

            Console.ReadKey();
        }
    }
}