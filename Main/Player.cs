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
        public int Level { get; set; }
        public List<string> Awards { get; private set; }
        public List<Boss> Bosses { get; private set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
            Level = 1;
            Awards = new List<string>();
            Bosses = new List<Boss>();
        }

        //public int CalculateExperience(int level)
        //{
        //    double experience = 100;

        //    for (int i = 2; i <= level; i++)
        //    {
        //        experience += experience * 0.5;
        //    }

        //    return (int)experience;
        //}

        public void ReceiveAward()
        {
            Awards.Add(Bosses.Last().Award);
        }

        public void StartCodeCompiler()
        {
            string[] libraries;
            libraries = Awards.Count == 0 ? null : Awards.ToArray();

            if (Reader.ReadFile("test.cs"))
                CodeManager.StartCodeCompiler(libraries);
        }
    }
}
