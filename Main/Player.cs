using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Player
    {
        public static string Name;
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public List<PlayerAward> Awards { get; set; }

        public static Player CreateDefaultPlayer()
        {
            Player player = new Player();
            player.Level = 0;
            player.ExperiencePoints = 0;
            //player.Awards.Add(new PlayerAward());
            return player;
        }
        public int CalculateExperience(int level)
        {
            double experience = 100;

            for (int i = 2; i <= level; i++)
            {
                experience += experience * 0.5;
            }

            return (int)experience;
        }

        public void AddLibrary(string library)
        {
            Awards.Add(new Library(library));
        }

        public void StartCodeCompiler()
        {
            string[] libraries;
            if (Awards != null)
            {
                if (!Awards.Any(a => a is Library)) libraries = null;
                libraries = Awards.Where(a => a is Library).Select(a => a.Description).ToArray();
            }
            else libraries = null;
            
            if (Reader.ReadFile("test.cs"))
                CodeManager.StartCodeCompiler(libraries);
        }
    }
}
