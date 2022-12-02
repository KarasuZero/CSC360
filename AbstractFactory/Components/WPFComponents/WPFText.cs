
using AbstractFactory.Interfaces;

namespace AbstractFactory.Components.WPFComponents
{
    public class WPFText : IText
    {
        private string _text;
        
        public WPFText(string text)
        {
            _setText(text);
        }
        
        private void _setText(string text)
        {
            string wpfText = "<TextBlock Text=\"" + text + "\" />";
            
            _text = wpfText;
        }
        
        public string GetText()
        {
            return _text;
        }
    }
}