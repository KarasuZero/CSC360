using System;
using FactoryPatternCommandApp.Interfaces;

namespace FactoryPatternCommandApp.OutputComponents
{
    public class htmlOutput : IOutput
    {
       public htmlOutput()
       {
           Console.WriteLine("htmlOutput: Constructor");
           TestOutput = "in htmlOutput";
       }
    }
}