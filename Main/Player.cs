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
        public List<Boss> Bosses { get; private set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
            Level = 1;
            Awards = new List<string>();
            Bosses=new List<Boss>();
            for (int i = 0; i < 5; i++)
            {
               Bosses.Add(new Boss("",i+1,""));
            }
            GenerateBosses();
        }

        public void GenerateBosses()
        {

            HashSet<string>names=new HashSet<string>();
            HashSet<string>awards=new HashSet<string>();
            string temp = String.Empty;
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    Bosses[i].Name = Resources.BossNames.Last();
                }
                else
                {
                    temp = GenerateRandomName();
                    while (names.Contains(temp))
                    {
                        temp = GenerateRandomName();
                    }
                    names.Add(temp);
                    Bosses[i].Name = temp;
                    temp = GenerateRandomLibrary();
                    while (awards.Contains(temp))
                    {
                        temp = GenerateRandomLibrary();
                    }
                    awards.Add(temp);
                    Bosses[i].Award = temp;
                }
            }

        }

        public string GenerateRandomLibrary()
        {
            Random random=new Random();
            int libraryIndex = random.Next(0, Resources.Libraries.Length);
            string library = Resources.Libraries[libraryIndex];
            return library;
        }

        public string GenerateRandomName()
        {
            Random random=new Random();
            int nameIndex = random.Next(0, Resources.BossNames.Length - 1);
            string name=Resources.BossNames[nameIndex];
            return name;
        }

        public void ReceiveAward()
        {
            Awards.Add(Bosses.Last().Award);
        }

        private string StartCodeCompiler(Mission mission)
        {
            string[] libraries;
            libraries = Awards.Count == 0 ? null : Awards.ToArray();

            if (Reader.ReadFile("test.cs"))
             CodeManager.StartCodeCompiler(libraries);
        }

        public bool MissionSuccess(Mission mission)
        {
            return StartCodeCompiler(mission) == Reader.ExpectedResult(mission);
        }


    }
}
