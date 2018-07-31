using System;

namespace BridgeSample
{
    //Implementor
    abstract class DbImplementor
    {
        public abstract void Execute(string Sql);
        public abstract void OpenCon(string SqlCon);
    }

    //ConcreteImplementor
    class SqlServerImplementor : DbImplementor
    {
        public override void Execute(string Sql)
        {
            Console.WriteLine("\"{0}\" - SqlServer işletildi.", Sql);
        }

        public override void OpenCon(string SqlCon)
        {
            Console.WriteLine("\"{0}\" - Sql Server Con. Açıldı.", SqlCon);
        }
    }

    //ConcreteImplementor
    class OracleImplementor : DbImplementor
    {
        public override void Execute(string Sql)
        {
            Console.WriteLine("\"{0}\" - oracle işletildi.", Sql);
        }

        public override void OpenCon(string SqlCon)
        {
            Console.WriteLine("\"{0}\" - oracle Con. Açıldı.", SqlCon);
        }
    }

    //Abstraction
    abstract class DbAbstraction
    {
        protected DbImplementor implementor;

        public DbAbstraction(DbImplementor imp)
        {
            Implementor = imp;
        }

        // Property
        public DbImplementor Implementor
        {
            set { implementor = value; }
        }

        public abstract void Exec(string Sql);
        public abstract void ConOpen(string ConStr);
    }

    //RefinedAbstraction
    class DbRefinedAbstraction : DbAbstraction
    {
        public DbRefinedAbstraction(DbImplementor imp)
            : base(imp)
        {

        }
        public override void Exec(string Sql)
        {
            implementor.Execute(Sql);
        }

        public override void ConOpen(string ConStr)
        {
            implementor.OpenCon(ConStr);
        }
    }

    //client
    class Program
    {
        static void Main(string[] args)
        {
            DbAbstraction absDb = new DbRefinedAbstraction(new SqlServerImplementor());
            absDb.ConOpen("e-ticaret db");
            absDb.Exec("select * from Urun");

            absDb = new DbRefinedAbstraction(new OracleImplementor());
            absDb.ConOpen("e-ticaret db");
            absDb.Exec("select * from Urun");


            Console.ReadKey();
        }
    }
}
