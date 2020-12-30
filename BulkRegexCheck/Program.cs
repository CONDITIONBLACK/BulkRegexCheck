using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Crayon;

namespace Regexulator
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine(Output.Blue($"Enter Path to File containing regular expressions to validate: "));
            string FilePath = @"" + Console.ReadLine();

            if (File.Exists(FilePath))
            {
                string line;

                // Read the file line by line.  
                StreamReader FileToRead =
                    new StreamReader(FilePath);
                while ((line = FileToRead.ReadLine()) != null)
                {
                    TestUserInputRegEx(line);
                }

                FileToRead.Close();
                Console.WriteLine(Output.Blue($"All Regular Expressions validated for file {0}"), FilePath);
                Console.WriteLine(Output.Blue($"Press Any Key to Exit"));
                Console.ReadKey();
            }
        }
        public static bool VerifyRegEx(string testPattern)
        {
            bool isValid = true;

            if ((testPattern != null) && (testPattern.Trim().Length > 0))
            {
                try
                {
                    Regex.Match("", testPattern);
                }
                catch (ArgumentException)
                {
                    // BAD PATTERN: Syntax error
                    isValid = false;
                }
            }
            else
            {
                //BAD PATTERN: Pattern is null or blank
                isValid = false;
            }

            return (isValid);
        }

        public static void TestUserInputRegEx(string line)
        {
            if (VerifyRegEx(line))
            {
                Console.WriteLine(Output.BrightGreen("The regular expression {0} is VALID."), line);
            }
            else
                Console.WriteLine(Output.BrightRed("The regular expression {0} is NOT VALID."), line);
        }
    }
}
