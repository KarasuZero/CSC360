using System;
using FactoryPatternCommandApp.Interfaces;

namespace FactoryPatternCommandApp.OutputComponents
{
    public class swingOutput : IOutput
    {
        public swingOutput()
        {
            Console.WriteLine("swingOutput: Constructor");
            TestOutput = "in swingOutput";
        }
    }
}