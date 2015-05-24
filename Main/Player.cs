using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Player
    {
        public string Name { get; private set; }
        public int Points { get; set; }
        public bool DoublePoints { get; set; }
        public int PointsModifier { get; set; }
        public int Level { get; set; }
        public List<string> Awards { get; private set; }
        private Boss[] Bosses;

        public Player(string name)
        {
            Name = name;
            Points = 0;
            Level = 1;
            Awards = new List<string>();
            Bosses = new Boss[5];
            InitBosses();
        }

        private void InitBosses()
        {
            HashSet<string> names = new HashSet<string>();
            HashSet<string> awards = new HashSet<string>();

            for (int level = 1; level <= 5; level++)
            {
                if (level == 5)
                {
                    Bosses[level-1] = new Boss(Resources.GetFinalBoss(), level, "\"True Programmer\" title");
                    break;
                }

                string name = Resources.GetRandomBoss();
                while (names.Contains(name))
                {
                    name = Resources.GetRandomBoss();
                }
                names.Add(name);
                string award = Resources.GetRandomAward();
                while (awards.Contains(award))
                {
                    award = Resources.GetRandomAward();
                }
                awards.Add(award);

                Bosses[level-1] = new Boss(name, level, award);
            }
        }

        public void ReceiveAward()
        {
            Awards.Add(Bosses[Level-1].Award);
        }

        public bool? CompleteMission()
        {
            string fileName = GetCurrentBoss().Mission.GenerateFileName();
            string[][] fileData = Reader.GetMissionData(fileName);
            string missionTask = fileData[(int) MissionData.Problem][0];
            string[] missionInput = fileData[(int)MissionData.InputData],
                     missionOutput = fileData[(int)MissionData.OutputData],
                     playerOutput;

            Console.WriteLine(missionTask);

            bool compiledSuccessfully =
                CodeManager.GetOutputFromCompiled(
                Awards.ToArray(),
                fileData[(int)MissionData.InputData],
                out playerOutput);

            if (!compiledSuccessfully) return null;

            for (int i = 0; i < missionInput.Length; i++)
            {
                if (missionOutput[i] != playerOutput[i]) return false;
            }
            return true;
        }

        public Boss GetCurrentBoss()
        {
            return Bosses[Level-1];
        }

        public void PrintCurrentMission()
        {
            
        }
    }
}
