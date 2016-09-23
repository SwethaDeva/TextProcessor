using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            StringBuilder CompleteText = new StringBuilder();
            
            //Assuming each word in a sentence is delimited with a space.
            string[] ExtractWords = input.Split(null);
            int index_Of_lastChar = 0;
            int count_Of_chars = 0;
            string delimiter = " ";
            int index_of_spclChar = 0;
            char[] SpecialChars = "!@#$%^&*(),';.<>".ToCharArray();
            foreach (string str in ExtractWords)
            {
               if(str.Trim().Length>1)
               {
                    index_of_spclChar = str.IndexOfAny(SpecialChars);
                    index_Of_lastChar = str.Length - 1;
                    if (index_of_spclChar == -1)                    
                    {
                                             
                        string tempstr = str.Substring(1, index_Of_lastChar-1);
                        count_Of_chars = tempstr.Distinct().Count();
                        CompleteText.Append(delimiter);
                        CompleteText.Append(str[0].ToString() + count_Of_chars + str[(str.Length) - 1].ToString());
                    }
                    else
                    { 
                     //Assuming that the special charecter is always at the end of the parsed word from the inputted text.
                      if(index_Of_lastChar == index_of_spclChar) 
                      {
                            string tempstr = str.Substring(1, index_Of_lastChar - 2);
                            count_Of_chars = tempstr.Distinct().Count();
                            CompleteText.Append(delimiter);
                            CompleteText.Append(str[0].ToString() + count_Of_chars + str[(str.Length) - 2].ToString() + str[(str.Length) - 1].ToString());
                        }

                    }

                    
                }
                else 
                {
                    CompleteText.Append(delimiter);
                    CompleteText.Append(str[0].ToString());
                    delimiter = " ";
                }                

            }

            Console.WriteLine("Formatted Text:" + CompleteText);
        }
    }

}
