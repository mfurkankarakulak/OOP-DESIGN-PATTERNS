using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandSample
{
    /// <summary>
    /// Bu sınıf örneğimizin biraz daha mantıklı olması için eklendi. Command deseni için zorunlu değil
    /// </summary>
    public class Kisi
    {
        public int ID { get; set; }
        public string Ad { get; set; }
    }

    /// <summary>
    /// Kisi üzerinde işlemler yapan nesne.
    /// </summary>
    public class ReceiverKisi
    {
        private Kisi _EntityKisi;

        public ReceiverKisi(Kisi entityKisi)
        {
            this._EntityKisi = entityKisi;
        }

        public void Ekle()
        {
            Console.WriteLine("{0} Eklendi.", _EntityKisi.Ad);
        }

        public void Sil()
        {
            Console.WriteLine("ID:{0} Silindi.", _EntityKisi.ID);
        }
    }

    /// <summary>
    /// ReceiverKisi deki ekle veya sil metotlarını çalıştıracak olan sınıfların uygulaması gereken abstract sınıf.
    /// </summary>
    public abstract class CommandKisi
    {
        protected ReceiverKisi _receiverKisi;
        public CommandKisi(ReceiverKisi receiverKisi)
        {
            this._receiverKisi = receiverKisi;
        }

        public abstract void Execute();
    }

    /// <summary>
    /// ReceiverKisi de Ekle metodunu çalıştıracak olan ConcreteCommand nesnesi.
    /// </summary>
    public class ConcreteCommandKisiEkle : CommandKisi
    {
        public ConcreteCommandKisiEkle(ReceiverKisi receiverKisi)
            : base(receiverKisi)
        {

        }

        public override void Execute()
        {
            _receiverKisi.Ekle();
        }
    }

    /// <summary>
    /// ReceiverKisi de Sil metodunu çalıştıracak olan ConcreteCommand nesnesi.
    /// </summary>
    public class ConcreteCommandKisiSil : CommandKisi
    {
        public ConcreteCommandKisiSil(ReceiverKisi receiverKisi)
            : base(receiverKisi)
        {

        }

        public override void Execute()
        {
            _receiverKisi.Sil();
        }
    }

    /// <summary>
    /// İşlemlerin çalıştırılacağı nesne.
    /// </summary>
    public class InvokerKisi
    {
        public List<CommandKisi> CommandKisiList { get; set; }

        public InvokerKisi()
        {
            CommandKisiList = new List<CommandKisi>();
        }

        public void ExecuteAll()
        {
            if (CommandKisiList.Count == 0)
                return;

            foreach (CommandKisi item in CommandKisiList)
            {
                item.Execute();
            }
        }
    }
}
