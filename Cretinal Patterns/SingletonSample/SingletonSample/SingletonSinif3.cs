using System;

namespace SingletonSample
{
    public class SingletonSinif3
    {
        private static SingletonSinif3 _TekNesne;
        private static Object lockObject = new Object();

        private SingletonSinif3() { }

        public static SingletonSinif3 Sinif 
        {
            get 
            {
                if (_TekNesne == null)
                {
                    lock (lockObject)
                    {
                        if (_TekNesne == null)
                            _TekNesne = new SingletonSinif3(); 
                    }
                }
                
                return _TekNesne; 
            }
        }

        public int toplam(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}
