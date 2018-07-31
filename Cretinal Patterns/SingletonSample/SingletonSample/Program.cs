
namespace SingletonSample
{
    class Program
    {
        static void Main(string[] args)
        {
            int t1 = SingletonSinif.Sinif.toplam(1, 2);
            int t2 = SingletonSinif.Sinif2().toplam(2, 3);

            t1 = SingletonSinif2.Sinif.toplam(3, 4);
            t1 = SingletonSinif3.Sinif.toplam(3, 4);
        }
    }
}
