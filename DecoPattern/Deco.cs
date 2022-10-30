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
            ITextReader textReader = new StreamReaderComponent();
            
            //signature, shifting, and lineending
            ITextWriter shiftUp = new ShiftUpDecorator(textWriter);
            ITextReader shiftdown = new ShiftDownDecorator(textReader);
            
            ITextWriter sig = new SigDecorator(textWriter);
            ITextReader lineEnding = new LineEndingDecorator(textReader);

            // Console.WriteLine("Shifed up : "+ shiftUp.getData());
            // shiftUp.writeData(shiftUp.fpath("shiftUpText.txt"));
            //Console.WriteLine(sig.getData());
            //sig.writeData(sig.fpath("sigTest.txt"));
            
            // shift then sign
            // Console.WriteLine("Shift then sign");
            // ITextWriter shiftFirst = new ShiftUpDecorator(textWriter);
            // ITextWriter signSecond = new SigDecorator(shiftFirst);
            //
            // Console.WriteLine("Output: " + signSecond.getData());
            // signSecond.writeData(signSecond.fpath("ShiftThenSign.txt"));
            
            // sign then shift
            // Console.WriteLine("sign then shift");
            // ITextWriter signFirst = new SigDecorator(textWriter);
            // ITextWriter shiftSecond = new ShiftUpDecorator(signFirst);
            //
            // Console.WriteLine("Output: " + shiftSecond.getData());
            // shiftSecond.writeData(shiftSecond.fpath("SignThenShift.txt"));
            
            // read data from txt file and shift 
            // shiftdown.readData(shiftdown.fpath("readerTest.txt"));
            // Console.WriteLine(shiftdown.getData());
            
            //changing line ending from windows to unix
            Console.WriteLine(lineEnding.readData("irrelevent"));
        }
    }

    //interfaces
    public interface ITextWriter
    {
        string getData();
        string fpath(string fname);
        void writeData(string fpath);
    }
    
    public interface ITextReader
    {
        string getData();
        string fpath(string fname);
        string readData(string fpath);
    }
    
    //components
    public class StreamWriterComponent : ITextWriter
    {
        public string getData()
        {
            return "writer test dummy data";
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
    
    public class StreamReaderComponent : ITextReader
    {
        public string getData()
        {
            return "default data";
        }

        public string fpath(string fname)
        {
            string fdir = "C:\\Users\\kento\\RiderProjects\\CSC360\\DecoPattern";
            var fpath = Path.Combine(fdir, fname);
            
            return fpath;
        }

        public string readData(string fpath)
        {
            StreamReader reader = null;
            string dataOut = "";
            string data;
            try
            {
                reader = new StreamReader(fpath);
                data = reader.ReadLine();
                while (data != null)
                {
                    Console.WriteLine(data);
                    dataOut += data;
                    data = reader.ReadLine();
                }
                
                reader.Close();
                return dataOut;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
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

        public virtual string readData(string fpath)
        {
            return _component.readData(fpath);
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
            
            string dataOut = dataIn + " Jia Lin " + now;
            
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
    
    public class ShiftUpDecorator : WriterDecorator
    {
        public ShiftUpDecorator(ITextWriter component) : base(component)
        {
        }
        //TODO add space detection to shift up 
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
            
            string dataOut = "";
            
            for (int i = 0; i < dataIn.Length; i++)
            {
                string letter = dataIn.Substring(i, 1);
                Console.WriteLine("current letter: " + letter);

                for (int a = 0; a < lowerAlphabets.Length - 1; a++)
                {
                    Console.WriteLine("Comparing: " + letter + " to " + lowerAlphabetDeck[a]);
                    if (letter.Equals(lowerAlphabetDeck[a]))
                    {
                        Console.WriteLine("Its a hit.............");
                        if (letter.Equals("z"))
                        {
                            newData.Add("a");
                            break;
                        }
                        else if (letter.Equals(" "))
                        {
                            Console.Write("Hit a space......");
                            newData.Add(" ");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Swaping: " + letter + " to " + lowerAlphabetDeck[a+1] + ".............");
                            newData.Add(lowerAlphabetDeck[a+1]);
                            break;
                        }
                    }
                }
                
                for (int a = 0; a < upperAlphabets.Length - 1; a++)
                {
                    if (letter.Equals(upperAlphabetDeck[a]))
                    {
                        if (letter.Equals("z"))
                        {
                            newData.Add("a");
                            break;
                        }
                        else if (letter.Equals(" "))
                        {
                            newData.Add(" ");
                            break;
                        }
                        else
                        {
                            newData.Add(lowerAlphabetDeck[a+1]);
                            break;
                        }
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
    
    public class ShiftDownDecorator : ReaderDecorator
    {
        public ShiftDownDecorator(ITextReader component) : base(component)
        {
        }

        public override String getData()
        {
            string dataIn = base.readData(base.fpath("readerTest.txt"));

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
                
            }
            
            foreach (var letter in newData)
            {
                dataOut += letter;
            }
            return dataOut;
        }
    }
    
    public class LineEndingDecorator : ReaderDecorator
    {
        public LineEndingDecorator(ITextReader component) : base(component)
        {
        }

        public override string readData(string fpath)
        {
            Console.WriteLine("Change Windows Line ending to Unix Line ending.......");
            string[] filePaths = Directory.GetFiles(@"C:\Users\kento\RiderProjects\CSC360\DecoPattern", "*.txt");

            foreach (string file in filePaths)
            {
                string[] lines = File.ReadAllLines(file);
                List<string> list_of_string = new List<string>();
                foreach (string line in lines)
                {
                    list_of_string.Add( line.Replace("\r\n", "\n"));
                }
                File.WriteAllLines(file, list_of_string);
            }
            return "operation complete";
        }
    }
}