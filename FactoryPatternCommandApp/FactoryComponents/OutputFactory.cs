using System;
using FactoryPatternCommandApp.Interfaces;
using FactoryPatternCommandApp.OutputComponents;

namespace FactoryPatternCommandApp.FactoryComponents
{
    public class OutputFactory : IFactory
    {
        public IOutput getOutput(string outputType)
        {
            if (outputType.Contains("HTML"))
            {
                return new htmlOutput();
            }
            else if (outputType.Contains("SWING"))
            {
                return new swingOutput();
            }
            else
            {
                throw new ArgumentException("Invalid output type");
            }
        }
    }
}