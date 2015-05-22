using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    enum MissionData
    {
        Problem = 0,
        InputData,
        OutputData
    }

    public class Mission
    {
        public int Level { get; private set; }
        public int Number { get; private set; }

        public Mission(int level)
        {
            Level = level;
            Number = (new Random()).Next(5);
        }

        public string GenerateFileName()
        {
            string defaultDir = "..\\..\\Missions";
            if (!Directory.Exists(defaultDir)) return null;
            string[] files = Directory.GetFiles(defaultDir);
            files = files.Select(f => f.Split('\\').Last()).ToArray();
            int filesCount = files.Count(f => f[0] == '0'+Level);
            string fileName = String.Format("{0}\\{1}{2}.txt", defaultDir, Level, (new Random().Next(1, filesCount + 1)));
            return fileName;
        }
    }
}
