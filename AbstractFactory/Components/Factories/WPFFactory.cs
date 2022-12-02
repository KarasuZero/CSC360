using System;
using System.Collections.Generic;
using System.IO;
using AbstractFactory.Components.WPFComponents;
using AbstractFactory.Interfaces;

namespace AbstractFactory.Components.Factories
{
    //concete factory for wpf output

    public class WPFFactory : IFactory
    {
        private List<string> _output = new List<string>()
        {
            "<Window x:Class=\"WpfApplication1.MainWindow\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" Title=\"MainWindow\" Height=\"800\" Width=\"800\">",
            "<Grid>"
        };

        public override void AddText(string userInput)
        {
            WPFText text = new WPFText(userInput);
            
            _output.Add(text.GetText());
            
            Console.WriteLine("WPF Text added: " + text.GetText() + "\n");
        }

        public override void AddButton(string name, string text, string onclick)
        {
            WPFButton button = new WPFButton(text, onclick, name);
            
            _output.Add(button.GetButton());
            
            Console.WriteLine("WPF Button added: " + button.GetButton() + "\n");
        }

        public override void CreateOutput()
        {
            _output.Add("</Grid></Window>");
            
            Console.WriteLine("\nWPF Output: \n\n");
            foreach (var line in _output)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\n\n");
            
            string fpath = @"C:\Users\kento\Desktop\outputFolder\WPFOutput.xaml";
            StreamWriter writer = new StreamWriter(fpath);
            foreach (var line in _output)
            {
                writer.WriteLine(line);
            }
            writer.Close();
            
            Console.WriteLine("WPF Output saved to WPFOutput.xaml");
        }
    }
}