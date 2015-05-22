using System;
using System.IO;

namespace Main
{
    public static class Reader
    {
        public static string[][] GetMissionData(string filePath)
        {
            string[][] data = null;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {

                    string readTheFile = sr.ReadToEnd();
                    string[] dataParts = readTheFile.Split(new[] {'⑱'}, StringSplitOptions.RemoveEmptyEntries);
                    data = new string[3][];
                    data[0] = new[] {dataParts[0]};
                    data[1] = dataParts[1].Split('Ẋ');
                    data[2] = dataParts[2].Split('Ẋ');

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }

            return data;
        }
    }
}

