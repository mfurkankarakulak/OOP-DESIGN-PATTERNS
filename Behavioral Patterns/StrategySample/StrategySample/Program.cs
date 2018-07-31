using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrategySample
{
    //strategy yapısı
    interface ILogStrategy
    {
        void InsertLog(string LogValue);
    }

    //ConcreteStrategy1
    class LogFile:ILogStrategy
    {
        public void InsertLog(string LogValue)
        {
            Console.WriteLine("File bazlı log yazıldı. {0}",LogValue);
        }
    }

    //ConcreteStrategy2
    class LogDb : ILogStrategy
    {
        public void InsertLog(string LogValue)
        {
            Console.WriteLine("Veri tabanı bazlı log yazıldı.");
        }
    }

    //Context yapısı
    class LogWriter
    {
        ILogStrategy logstrategy;
        public LogWriter(ILogStrategy LogStrategy)
        {
            logstrategy = LogStrategy;
        }

        public void LogInsert(string LogValue)
        {
            logstrategy.InsertLog(LogValue);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //direkt LogDb veya LogFile nesnelerini kullanmayıp 
            //LogWriter üzerinden erişimi sağlıyoruz.

            LogWriter lw = new LogWriter(new LogFile());
            lw.LogInsert("ins1");

            lw = new LogWriter(new LogDb());
            lw.LogInsert("ins2");

            /*
                diyelim ki sonradan uygulamamızın registry bazlı log tutmasını istedik.
                tek yapmamız gereken yeni bir ConcreteStrategy yapısı oluşturmak.
                tabiki bütün loglar aynı şekilde tutulacak ise Constructor a parametre
                vermek yerine LogWriter Constructor da direkt istediğimiz Concrete türünü oluşturabiliriz.
            */ 
            Console.ReadKey();
        }
    }
}
