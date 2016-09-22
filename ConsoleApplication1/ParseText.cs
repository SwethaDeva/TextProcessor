using System;
using System.Linq;

namespace TextProcessor
{
    /* 
     write a program that parses a sentence and replaces each word with the following: first letter, 
     number of distinct characters between first and last character, and last letter.
     */
    class ParseText
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press E to Exit");

            bool exitConsole = false;
            while (!exitConsole)
            {
                Console.WriteLine("Please enter text to process:");

                string text = Console.ReadLine();

                if (text == "E")
                {
                    exitConsole = true;
                }
                else
                {
                    if (text != null && text != "")
                    {
                        ExtractString obj1 = new ExtractString();
                        obj1.ProcessString(text);
                        Console.ReadLine();
                    }
                }
            }

        }
    }
    
    class ExtractString
    {
        public void ProcessString(string input)
        {
            string[] ExtractWords = input.Split(null);
            int index_Of_lastChar = 0;
            int count_Of_chars = 0;

            foreach (string str in ExtractWords)
            {
                if (str.Length == 1)
                {
                    Console.WriteLine(str[0].ToString());
                }
                else
                {
                    index_Of_lastChar = str.Length - 2;
                    string tempstr = str.Substring(1, index_Of_lastChar);
                    count_Of_chars = tempstr.Distinct().Count();
                    Console.WriteLine(str[0].ToString() + count_Of_chars + str[(str.Length) - 1].ToString());
                }

            }
        }
    }

}
