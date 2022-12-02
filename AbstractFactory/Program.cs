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
           //string outputType = "HTML";
           
           //IFactory abstractFactory = FactoryProvider.GetFactory(outputType);

           //if (abstractFactory == null)
           //{
           //    Console.WriteLine("{0} is not supported", outputType);
           //}else
           //{
               //abstractFactory.AddText("Hello World"); 
               //abstractFactory.AddText("this is line 2");
               //abstractFactory.AddButton("button1", "This is button 1","button_1_OnClick()");
               //abstractFactory.CreateOutput();
           //}
           
           while (true)
           {
               Console.WriteLine("-----------Welcome to HTML/XAML Builder-----------");
               Console.WriteLine("Enter HTML to build a HTML page \n");
               Console.WriteLine("Enter WPF to build a WPF page \n");
               Console.WriteLine("Enter Exit to exit the application \n");
               
               var outputTypeInput = Console.ReadLine();
               
               //picking output type
               if (outputTypeInput == null)
               {
                   Console.WriteLine("Input can't be null");
               }
               else if (outputTypeInput.Equals("Exit"))
               {
                   Console.WriteLine("Exiting Application......\n\n");
                   break;
               }
               else
               {
                   //creating abstractFactory base on outputTypeInput
                   IFactory abstractFactory = FactoryProvider.GetFactory(outputTypeInput);

                   if (abstractFactory == null)
                   {
                       Console.WriteLine("{0} is not supported", outputTypeInput);
                   }
                   else
                   {
                       while (true)
                       {
                           //picking component
                           Console.WriteLine("\nEnter Text to add a Text \n");
                           Console.WriteLine("Enter BT to add a Button \n");
                           Console.WriteLine("Enter Create to Create output \n");
                           Console.WriteLine("Enter Exit to Exit \n");
                           
                           var componentChoiceInput = Console.ReadLine();

                           if (componentChoiceInput == null)
                           {
                               Console.WriteLine("Input cant be null");
                           }
                           else if (componentChoiceInput.Equals("Text"))
                           {
                               Console.WriteLine("\nEnter Text for the Text Block: ");
                               var textInput = Console.ReadLine();
                               
                               abstractFactory.AddText(textInput);
                           }
                           else if (componentChoiceInput.Equals("BT"))
                           {
                               Console.WriteLine("\nEnter the Name of the BT: ");
                               var BT_name = Console.ReadLine();
                               
                               Console.WriteLine("\nEnter the Text of the BT: ");
                               var BT_text = Console.ReadLine();
                               
                               Console.WriteLine("Enter the OnClick of the BT: ");
                               var BT_onClick = Console.ReadLine();
                               
                               abstractFactory.AddButton(BT_name,BT_text,BT_onClick);
                           }
                           else if (componentChoiceInput.Equals("Create"))
                           {
                               abstractFactory.CreateOutput();
                               break;
                           }
                           else if (componentChoiceInput.Equals("Exit"))
                           {
                               Console.WriteLine("returning to builder page.....\n\n");
                               break;
                           }
                           else
                           {
                               Console.WriteLine("Invalid Input");
                           }
                       }
                   }
               }
           }
        }
    }
}