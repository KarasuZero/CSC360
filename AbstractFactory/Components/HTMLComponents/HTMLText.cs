
using AbstractFactory.Interfaces;

namespace AbstractFactory.Components.HTMLComponents
{
    //concrete implementation of IText for HTML output
    public class HTMLText : IText
    {
        private string _text;
        
        public HTMLText(string text)
        {
            _setText(text);
        }
        private void _setText(string text)
        {
            string htmlText = "<p>" + text + "</p>";

            _text = htmlText;
        }
        
        public string GetText()
        {
            return _text;
        }
    }
}