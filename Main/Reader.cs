using System;
using System.IO;

class Reader
{
    public static void ReadFile(string fileName)
    {
        try
        {
            
            string[] textSplit = new string[4];
            string test = String.Empty;
            using (StreamReader sr = new StreamReader(fileName))
            {
                test = sr.ReadToEnd();
            }
            textSplit = test.Split('⑱');
            PrintProblem(textSplit);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found!");
        }

    }

    public static void PrintProblem(string[] tokens)
    {
        Console.WriteLine(tokens[0]);
        Console.WriteLine(tokens[1]);
        Console.WriteLine(tokens[2]);
        Console.WriteLine(tokens[3]);        
    }
}

