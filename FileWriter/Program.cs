
using System.Security.AccessControl;
using System;
using System.Runtime.CompilerServices;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            //deco pattern
            ITextWriter textWriter = new StreamWriterComponent();
            //defualt
            ITextWriter shift = new ShiftDecorator(textWriter);
            ITextWriter sig = new SigDecorator(textWriter);
            
            //sig.writeData(sig.fpath());
            // Console.WriteLine(shift.getData());
            // Console.WriteLine(sig.getData());
            
            //shift then sign
            Console.WriteLine("Shift then sign");
            ITextWriter shiftFirst = new ShiftDecorator(textWriter);
            ITextWriter signSecond = new SigDecorator(shiftFirst);
            
            Console.WriteLine("Output: " + signSecond.getData());
            signSecond.writeData(signSecond.fpath("ShiftThenSign.txt"));
            
            //sign then shift
            Console.WriteLine("sign then shift");
            ITextWriter signFirst = new SigDecorator(textWriter);
            ITextWriter shiftSecond = new ShiftDecorator(signFirst);
            
            Console.WriteLine("Output: " + shiftSecond.getData());
            shiftSecond.writeData(shiftSecond.fpath("SignThenShift.txt"));
        }
    }

    //interfaces
    public interface ITextWriter
    {
        string getData();
        string fpath(string fname);
        void writeData(string fpath);
    }
    
    //components
    public class StreamWriterComponent : ITextWriter
    {
        public string getData()
        {
            return "default data";
        }

        public string fpath(string fname)
        {
            string fdir = "C:\\Users\\kento\\RiderProjects\\CSC360\\DecoPattern\\";
            var fpath = Path.Combine(fdir, fname);
            
            return fpath;
        }

        public void writeData(string fpath)
        {
           

            StreamWriter writer = null;

            try
            {
                string data = getData();
                
                writer = new StreamWriter(fpath);
                Console.WriteLine("the data: " + data);
                writer.WriteLine(data);
                Console.WriteLine("writing");
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
//abstract decorator
    public abstract class WriterDecorator : ITextWriter
    {
        private ITextWriter _component;

        public WriterDecorator(ITextWriter component)
        {
            _component = component;
        }

        public string fpath(string fname)
        {
            return _component.fpath(fname);
        }

        public virtual void writeData(string fpath)
        {
            _component.writeData(fpath);
        }

        public virtual string getData()
        {
            return _component.getData();
        }
    }

    //concreate decorators
    public class SigDecorator : WriterDecorator
    {
        public SigDecorator(ITextWriter component) : base(component)
        {
        }

        public override String getData()
        {

            string dataIn = base.getData();
            
            DateTime now = DateTime.Now;
            
            string dataOut = dataIn + " " + now;
            
            Console.WriteLine("Signature added");
            
            return dataOut;
        }

        public override void writeData(string fpath)
        {
            StreamWriter writer = null;

            try
            {
                string data = getData();
                
                writer = new StreamWriter(fpath);
                Console.WriteLine("the data: " + data);
                writer.WriteLine(data);
                Console.WriteLine("writing");
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    
    public class ShiftDecorator : WriterDecorator
    {
        public ShiftDecorator(ITextWriter component) : base(component)
        {
        }

        public override String getData()
        {
            string dataIn = base.getData();

            string[] lowerAlphabets =
            {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u",
                "v", "w", "x", "y", "z"
            };
            
            string[] upperAlphabets =
            {
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U",
                "V", "W", "X", "Y", "Z"
            };
            List<string> lowerAlphabetDeck = new List<string>(lowerAlphabets);
            List<string> upperAlphabetDeck = new List<string>(upperAlphabets);

            List<string> newData = new List<string>();

            string prev = "z";
            
            string dataOut = "";
            
            for (int i = 0; i < dataIn.Length; i++)
            {
                string letter = dataIn.Substring(i, 1);
                Console.WriteLine("current letter: " + letter);
                
                foreach (var alphabet in lowerAlphabetDeck)
                {
                    Console.WriteLine("Compareing: " + letter + " to " + alphabet);
                    if (letter.Equals(alphabet))
                    {
                        Console.WriteLine("Match Found......");
                        if (letter.Equals("a"))
                        {
                            Console.WriteLine("Changing a to z......");
                            newData.Add("z");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Changing " + letter + " to " + prev);
                            newData.Add(prev);
                            break;
                        }
                    }
                    else
                    { 
                        prev = alphabet;
                    }
                    
                }
                
                foreach (var alphabet in upperAlphabetDeck)
                {
                    Console.WriteLine("Compareing: " + letter + " to " + alphabet);
                    if (letter.Equals(alphabet))
                    {
                        if (letter.Equals("A"))
                        {
                            newData.Add("Z");
                            break;
                        }
                        else
                        {
                            newData.Add(prev);
                            break;
                        }
                    }
                    else
                    { 
                        prev = alphabet;
                    }
                }
                
            }
            
            foreach (var letter in newData)
            {
                dataOut += letter;
            }
            return dataOut;
        }

        public override void writeData(string fpath)
        {
            StreamWriter writer = null;

            try
            {
                string data = getData();
                
                writer = new StreamWriter(fpath);
                Console.WriteLine("the data: " + data);
                writer.WriteLine(data);
                Console.WriteLine("writing");
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}