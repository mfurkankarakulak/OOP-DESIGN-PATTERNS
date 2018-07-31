
namespace FactoryMethodExample
{
    public interface IRaporCreator
    {
        IRapor CreateRapor();
    }

    public class CreatorTabloRapor : IRaporCreator
    {
        public IRapor CreateRapor()
        {
            return new RaporTablo();
        }
    }

    public class CreatorGrafikRapor : IRaporCreator
    {
        public IRapor CreateRapor()
        {
            return new RaporGrafik();
        }
    }
}