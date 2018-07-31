using System;

namespace AdapterSample
{
    //Target
    interface IIO
    {
        void CreateTextFile(string Path);
        void CreateFolder(string Path);
        void Copy(string Source, string Destination);
    }

    class NoBufferIO : IIO
    {
        public void CreateTextFile(string Path)
        {
            Console.WriteLine("{0} CreateTextFile(NetIOClass)", Path);
        }

        public void CreateFolder(string Path)
        {
            Console.WriteLine("{0} CreateFolder(NetIOClass)", Path);
        }

        public void Copy(string Source, string Destination)
        {
            Console.WriteLine("{0}==>{1} Copy(NetIOClass)", Source, Destination);
        }
    }

    class BufferIO : IIO
    {
        public void CreateTextFile(string Path)
        {
            Console.WriteLine("{0} CreateTextFile(BufferIO)", Path);
        }

        public void CreateFolder(string Path)
        {
            Console.WriteLine("{0} CreateFolder(BufferIO)", Path);
        }

        public void Copy(string Source, string Destination)
        {
            Console.WriteLine("{0}==>{1} Copy(BufferIO)", Source, Destination);
        }
    }

    //Adapter
    class BatchAdapter : IIO
    {
        /*
            * Bu sınıfda Adaptee nesnesini üzerinden Target de tanımlı işlemleri gerçekleştirip
            * Adaptee nesnesini Target yapısına uyarlamış oluyoruz.
            * 
        */
        private BatchIO Batch;
        public BatchAdapter(BatchIO batch)
        {
            Batch = batch;
        }

        public void CreateTextFile(string Path)
        {
            Batch.DosyaOlustur(Path);
        }

        public void CreateFolder(string Path)
        {
            Batch.KlasorOlustur(Path);
        }

        public void Copy(string Source, string Destination)
        {
            Batch.Kopyala(Source, Destination);
        }
    }

    //Adaptee
    class BatchIO
    {
        public void DosyaOlustur(string DosyaYolu)
        {
            Console.WriteLine("{0} BatchIO DosyaOlusturuldu", DosyaYolu);
        }

        public void KlasorOlustur(string DosyaYolu)
        {
            Console.WriteLine("{0} BatchIO KlasorOlusturuldu", DosyaYolu);
        }

        public void Kopyala(string Kaynak, string Hedef)
        {
            Console.WriteLine("{0} ==> {1} BatchIO Kopyalandı.", Kaynak, Hedef);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IIO io = new BatchAdapter(new BatchIO());
            io.CreateFolder(@"c:\a");
            Console.ReadKey();
        }
    }
}
