using System;
using System.IO;

namespace FileWR
{
    public class fileWR
    {
        static void Main(string[] args)
        {
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
        

            try
            {
                string s = "test data";
                string newS = ShiftString(s);
                Console.WriteLine(newS);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        public static string ShiftString(string t)
        {
            for (int i = 0; i < t.Length; i++)
            {
                string data = t.Substring(i, 1);
                if (data != " ")
                {
                    Console.WriteLine(data);
                }
            }

            return "complete";
        }
        
    }
}