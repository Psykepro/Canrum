using System;
using System.IO;

namespace Main
{
    public static class Reader
    {
        static string[] _missionText=new string[3];
        public static void PrintMission(Mission mission)
        {
            string fileName = mission.Level.ToString() + mission.Number.ToString() + ".txt";
            StreamReader sr=new StreamReader(fileName);
            try
            {
                using (sr)
                {
                    string readTheFile = sr.ReadToEnd();
                    _missionText = readTheFile.Split(new[] { '⑱' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");
            }
            Console.WriteLine(_missionText[0]);
        }

        public static string[] GetInputAndOutput(Mission mission)
        {
            string[] inputOutput = new string[2];
            string fileName = mission.Level.ToString() + mission.Number.ToString() + ".txt";
            StreamReader sr = new StreamReader(fileName);
            try
            {
                using (sr)
                {
                    string readTheFile = sr.ReadToEnd();
                    _missionText = readTheFile.Split(new[] { '⑱' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found!");               
            }
            inputOutput[0] = _missionText[1];
            inputOutput[1] = _missionText[2];
            return inputOutput;
        }
    }
}

