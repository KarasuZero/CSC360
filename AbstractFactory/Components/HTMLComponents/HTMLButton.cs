using System;
using AbstractFactory.Interfaces;

namespace AbstractFactory.Components.HTMLComponents
{
   
    //concrete implementation of IButton for HTML output
    public class HTMLButton : IButton
    {
        private string _text;
        private string _onClick;
        private string _name;
        
        public HTMLButton(string text, string onClick, string name)
        {
            _text = text;
            _onClick = onClick;
            _name = name;
        }

        public string GetButton()
        {
            string htmlButton = 
                "<button" +
                    " name=\"" + _name + 
                    "\" onclick=\"" + _onClick + 
                    "\">" + _text + "" +
                "</button>";
            
            return htmlButton;
        }
    }
}

    