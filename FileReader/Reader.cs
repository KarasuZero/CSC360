using System.Security.AccessControl;
using System;
using System.Runtime.CompilerServices;

namespace FileWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            ITextReader fileReader = new StreamReaderComponent();
            ITextReader shiftdown = new ShiftDownDecorator(fileReader);
            
            Console.WriteLine(shiftdown.getData());
        }
    }

    //interfaces
    public interface ITextReader
    {
        string getData();
        string fpath(string fname);
        void readData(string fpath);
    }
    
    //components
    public class StreamReaderComponent : ITextReader
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

        public void readData(string fpath)
        {
            StreamReader reader = null;

            try
            {
                //TODO streamr reader
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
//abstract decorator
    public abstract class ReaderDecorator : ITextReader
    {
        private ITextReader _component;

        public ReaderDecorator(ITextReader component)
        {
            _component = component;
        }

        public string fpath(string fname)
        {
            return _component.fpath(fname);
        }

        public virtual void readData(string fpath)
        {
            _component.readData(fpath);
        }

        public virtual string getData()
        {
            return _component.getData();
        }
    }

    //concreate decorators
    public class ShiftDownDecorator : ReaderDecorator
    {
        public ShiftDownDecorator(ITextReader component) : base(component)
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
                    
                }
                
            }
            
            foreach (var letter in newData)
            {
                dataOut += letter;
            }
            return dataOut;
        }

        public override void readData(string fpath)
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