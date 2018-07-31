using System;
using System.Collections.Generic;

namespace FlyweightSample
{
    //yardımcı enum
    enum ComponentType
    {
        Icon = 1,
        Sound = 2
    }

    //Flyweight
    abstract class Component
    {
        //intrinsic özellikler
        public string Name;

        //extrinsic özellikler
        public int x;
        public int y;

        public abstract void Draw(int x,int y);
        public Component(string Name)
        {
            this.Name = Name;
        }
    }

    //ConcreteFlyweight
    class ComponentIcon : Component
    {
        public ComponentIcon()
            : base("CmpIcon") //sabit kısmını direkt atıyoruz
        {
        }

        public override void Draw(int x, int y)
        {
            //extrinsic özellikleri bu metot ile içeri alıp işlem yapıyoruz.
            base.x = x;
            base.y = y;
            Console.WriteLine("{0} {1} image çiziliyor.", x.ToString(), y.ToString());
        }
    }

    //ConcreteFlyweight
    class ComponentSound : Component
    {
        public ComponentSound()
            : base("CmpSound")
        {
        }

        public override void Draw(int x, int y)
        {
            base.x = x;
            base.y = y;
            Console.WriteLine("{0} {1} swf çiziliyor.", x.ToString(), y.ToString());
        }
    }

    //FlyweightFactory
    class ComponentManager
    {
        private Dictionary<ComponentType, Component> CompList;
        public ComponentManager()
        {
            CompList = new Dictionary<ComponentType, Component>();
        }

        public Component GetComponent(ComponentType ct)
        {
            //eğer listede varsa varolan nesneyi gönderiyoruz.
            if (CompList.ContainsKey(ct))
                return CompList[ct];

            //listede yoksa istenen nesneyi oluşturup listeye ekliyoruz.
            Component c;
            if (ct == ComponentType.Icon)
                c = new ComponentIcon();
            else
                c = new ComponentSound();

            CompList.Add(ct, c);

            return CompList[ct];
        }

        public int GetCount()
        {
            return CompList.Count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ComponentType[] Components = { ComponentType.Sound, ComponentType.Icon, ComponentType.Icon, ComponentType.Sound };
            ComponentManager cm = new ComponentManager();

            /*Bu değerlerin ayrı tutularak işlendiğini varsayalım*/
            int x = 20;
            int y = 10;

            foreach (ComponentType item in Components)
            {
                Component c = cm.GetComponent(item);
                c.Draw(x, y);
                x += 20;
                y += 10;
            }

            Console.WriteLine(cm.GetCount());
            Console.ReadKey();
        }
    }
}
