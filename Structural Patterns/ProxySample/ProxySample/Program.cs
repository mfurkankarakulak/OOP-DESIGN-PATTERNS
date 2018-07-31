using System;
using System.Threading;

namespace ProxySample
{
    //Subject
    interface IImageGenerator
    {
        void ShowImage();
    }

    //RealSubject
    class ImageGenerator : IImageGenerator
    {
        public void ShowImage()
        {
            Console.WriteLine("gerçek resmi gösteriliyor.");
        }
    }

    //Proxy
    class ImageGeneratorProxy : IImageGenerator
    {
        //proxy sınıfı Subject i uygular ve içinde subject referansı barındırır.
        private ImageGenerator _generator;
        private Timer t;
        private bool LoadRealObject = false;

        private void ShowRealImage(object o)
        {
            _generator = new ImageGenerator();
            _generator.ShowImage();
            LoadRealObject = true;
        }

        public void ShowImage()
        {
            if (_generator == null)
            {
                //burada başka bir threadda asıl nesnenin yüklenmesinin başlatıldığını düşünebiliriz.
                t = new System.Threading.Timer(new TimerCallback(ShowRealImage), this, 2000, 0);
            }

            if (!LoadRealObject) //gerçek nesne yüklenmesi tamamlanmamış ise önizleme resmi gösterilsin.
                Console.WriteLine("önizleme resmi gösteriliyor."); 

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ImageGeneratorProxy proxy1 = new ImageGeneratorProxy();
            
            proxy1.ShowImage();

            Console.ReadKey();

        }
    }
}
