using System;

namespace AbstractFactorySamplePc
{
    public abstract class HddAbstract
    {
        public abstract void HddIslem();
        public abstract string HddTur { get; }
    }

    public abstract class RamAbstract
    {
        public abstract void RamIslem();
        public abstract string RamTur { get; }
    }

    public abstract class PcFactory
    {
        public abstract HddAbstract CreateHdd();
        public abstract RamAbstract CreateRam();
    }

    public class HddConcrete1 : HddAbstract
    {
        public override void HddIslem()
        {
            Console.WriteLine("HddConcrete1 birleştirildi.");
        }

        public override string HddTur
        {
            get { return "Bu hdd türü: HddConcrete1"; }
        }
    }

    public class HddConcrete2 : HddAbstract
    {
        public override void HddIslem()
        {
            Console.WriteLine("HddConcrete2 birleştirildi");
        }

        public override string HddTur
        {
            get { return "Bu hdd türü: HddConcrete2"; }
        }
    }

    public class RamConcrete1 : RamAbstract
    {
        public override void RamIslem()
        {
            Console.WriteLine("RamConcrete1 birleştirildi");
        }

        public override string RamTur
        {
            get { return "Bu ram türü: RamConcrete1"; }
        }
    }

    public class RamConcrete2 : RamAbstract
    {
        public override void RamIslem()
        {
            Console.WriteLine("RamConcrete2 birleştirildi");
        }

        public override string RamTur
        {
            get { return "Bu ram türü: RamConcrete2"; }
        }
    }

    public class Concrete1Factory : PcFactory
    {
        public override HddAbstract CreateHdd()
        {
            return new HddConcrete1();
        }

        public override RamAbstract CreateRam()
        {
            return new RamConcrete1();
        }
    }

    public class Concrete2Factory : PcFactory
    {
        public override HddAbstract CreateHdd()
        {
            return new HddConcrete2();
        }

        public override RamAbstract CreateRam()
        {
            return new RamConcrete2();
        }
    }

    public class Factory
    {
        private PcFactory _pcFactory;
        private HddAbstract _hddAbstract;
        private RamAbstract _ramAbstract;

        public Factory(PcFactory pcFactory)
        {
            _pcFactory = pcFactory;
            _hddAbstract = _pcFactory.CreateHdd();
            _ramAbstract = _pcFactory.CreateRam();
        }

        public void Birlestir()
        {
            Console.WriteLine(_hddAbstract.HddTur);
            _hddAbstract.HddIslem();

            Console.WriteLine(_ramAbstract.RamTur);
            _ramAbstract.RamIslem();
        }
    }
}
