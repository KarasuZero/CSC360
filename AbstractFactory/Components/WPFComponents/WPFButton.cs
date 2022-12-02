using AbstractFactory.Interfaces;

namespace AbstractFactory.Components.WPFComponents
{
    public class WPFButton : IButton
    {
        private string _text;
        private string _onClick;
        private string _name;
        
        public WPFButton(string text, string onClick, string name)
        {
            _text = text;
            _onClick = onClick;
            _name = name;
        }

        public string GetButton()
        {
            string wpfButton = "<Button Content=\"" + _text + "\" Click=\"" + _onClick + "\" Name=\"" + _name + "\" />";
            
            return wpfButton;
        }
    }
}