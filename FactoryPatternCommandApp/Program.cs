using System;
using FactoryPatternCommandApp.FactoryComponents;
using FactoryPatternCommandApp.Interfaces;

namespace FactoryPatternCommandApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var FindOutputFactory = new OutputFactory() as IFactory;
            var testHtmlOutput = FindOutputFactory.getOutput("HTML");
            var testSwingOutput = FindOutputFactory.getOutput("SWING");
            
            Console.WriteLine
            (
                $"this should be HTML: {testHtmlOutput.TestOutput}\n" +
                $" and this should be Swing: {testSwingOutput.TestOutput}"

            );
        }
    }
}