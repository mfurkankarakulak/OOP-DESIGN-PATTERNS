
namespace FactoryMethodExample
{
    public enum RaporTip
    {
        Tablo,
        Grafik
    }

    /// <summary>
    /// Creator class
    /// </summary>
    public class Creator1
    {
        /// <summary>
        /// Factory Method
        /// </summary>
        /// <param name="raporTip">Rapor tipi</param>
        /// <returns>İstenilen tipdeki rapor referansı (product)</returns>
        public IRapor RaporFactory(RaporTip raporTip)
        {
            IRapor rapor = null;
            switch (raporTip)
            {
                case RaporTip.Tablo:
                    rapor = new RaporTablo();
                    break;
                case RaporTip.Grafik:
                    rapor = new RaporGrafik();
                    break;
                default:
                    break;
            }
            return rapor;
        }
    }
}
