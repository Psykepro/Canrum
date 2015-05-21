using System;
using System.IO;

namespace Main
{
    public static class Reader
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
                if (textSplit.Length != 4)
                    throw new FormatException();

                PrintProblem(textSplit);

                return true;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Problem file not found!");
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Problem file not in correct format!");
                return false;
            }

        }

        public static void PrintMission(Mission mission)
        {

            Console.WriteLine(tokens[0]);
        }
    }
}

