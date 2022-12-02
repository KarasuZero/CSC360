using System.Collections.Generic;

namespace AbstractFactory.Interfaces
{
    //abstract factory
    public abstract class IFactory
    {
        public abstract void AddText(string text);
        public abstract void AddButton(string name, string text, string onclick);
        
        public abstract void CreateOutput();
    }
}