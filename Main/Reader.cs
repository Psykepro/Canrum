using System;
using System.IO;

namespace Main
{
    class Reader
    {
        public static bool ReadFile(string fileName)
        {
            try
            {
                string test;

                using (StreamReader sr = new StreamReader(fileName))
                {
                    test = sr.ReadToEnd();
                }

                var textSplit = test.Split('⑱');
                return PrintProblem(textSplit);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
                return false;
            }

        }

        private static bool PrintProblem(string[] tokens)
        {
            if (tokens.Length != 4)
            {
                Console.WriteLine("File is not in the correct format");
                return false;
            }

            Console.WriteLine(tokens[0]);
            Console.WriteLine(tokens[1]);
            Console.WriteLine(tokens[2]);
            Console.WriteLine(tokens[3]);

            return true;
        }
    }
}

