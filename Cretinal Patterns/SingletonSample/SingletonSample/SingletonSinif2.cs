
namespace SingletonSample
{
    public class SingletonSinif2
    {
        private static SingletonSinif2 _TekNesne;

        private SingletonSinif2() { }

        public static SingletonSinif2 Sinif 
        {
            get 
            {
                if (_TekNesne == null)
                    _TekNesne = new SingletonSinif2();
                
                return _TekNesne; 
            }
        }

        public int toplam(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}
