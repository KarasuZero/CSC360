using System;
using System.Collections.Generic;
using System.IO;
using AbstractFactory.Components.HTMLComponents;
using AbstractFactory.Interfaces;

namespace AbstractFactory.Components.Factories
{
    //concrete factory for html output
    public class HTMLFactory : IFactory
    {
        private List<string> _output = new List<string>(){"<html><body>"};
        
        public override void AddText(string userInput)
        {
            HTMLText text = new HTMLText(userInput);
            
            _output.Add(text.GetText());
            
            Console.WriteLine("HTML Text added: " + text.GetText() + "\n");
        }

        public override void AddButton(string name,string text, string onClick)
        {
            HTMLButton button = new HTMLButton(text, onClick, name);
            
            _output.Add(button.GetButton());
            
            Console.WriteLine("HTML Button added: " + button.GetButton() + "\n");
        }
        
        public override void CreateOutput()
        {
            _output.Add("</body></html>");
            
            Console.WriteLine("\nHTML Output: \n\n");
            foreach (var line in _output)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\n\n");
            
            string fpath = @"C:\Users\kento\Desktop\outputFolder\HTMLOutput.html";
            StreamWriter writer = new StreamWriter(fpath);
            foreach (var line in _output)
            {
                writer.WriteLine(line);
            }
            writer.Close();
            
            Console.WriteLine("HTML Output saved to HTMLOutput.html");
        }
    }
}