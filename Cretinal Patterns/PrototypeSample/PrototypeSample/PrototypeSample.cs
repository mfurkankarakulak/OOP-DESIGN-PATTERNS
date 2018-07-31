using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrototypeSample
{
    /// <summary>
    /// Prototype
    /// </summary>
    public interface IPrototype
    {
        IPrototype Clone();
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    public class Kisi : IPrototype
    {
        public string Ad { get; set; }
        public DateTime DogumTarihi { get; set; }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as IPrototype;
        }
    }

    /// <summary>
    /// ConcretePrototype
    /// </summary>
    public class Urun : IPrototype
    {
        public string Name { get; set; }
        public float Price { get; set; }

        public IPrototype Clone()
        {
            return this.MemberwiseClone() as IPrototype;
        }
    }
}
