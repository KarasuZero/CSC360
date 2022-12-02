using AbstractFactory.Components.Factories;
using AbstractFactory.Interfaces;

namespace AbstractFactory.Providers
{
    public class FactoryProvider
    {
        public static IFactory GetFactory(string outputType)
        {
            switch (outputType)
            {
                case "HTML":
                    return new HTMLFactory();
                case "WPF":
                    return new WPFFactory();
                default:
                    return null;
            }
        }
        
    }
}