using System;

using AbstractFactory.Interfaces;
using AbstractFactory.Providers;

namespace AbstractFactory
{
    //Client
    internal class Program
    {
        public static void Main(string[] args)
        {
           string outputType = "HTML";
           
           IFactory abstractFactory = FactoryProvider.GetFactory(outputType);

           if (abstractFactory == null)
           {
               Console.WriteLine("{0} is not supported", outputType);
           }else
           {
               abstractFactory.AddText("Hello World"); 
               abstractFactory.AddText("this is line 2");
               abstractFactory.AddButton("button1", "This is button 1","button_1_OnClick()");
               abstractFactory.CreateOutput();
           }
        }
    }
}