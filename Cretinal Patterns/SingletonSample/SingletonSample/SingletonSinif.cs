
namespace SingletonSample
{
    public class SingletonSinif
    {
        private static SingletonSinif _TekNesne = new SingletonSinif();

        private SingletonSinif() { } /*Constructon private yapılarak bu sınıf dışından instance (örneğinin) alınmasını engelliyoruz */

        /*Oluşturulan static nesnenin dışarıdan erişilmesini sağlamak için property tanımı*/
        public static SingletonSinif Sinif 
        {
            get 
            { 
                return _TekNesne; 
            }
        }

        /*Oluşturulan static nesnenin dışarıdan erişilmesini metod ile de sağlayabiliriz*/
        public static SingletonSinif Sinif2()
        {
            return _TekNesne;
        }

        public int toplam(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}
