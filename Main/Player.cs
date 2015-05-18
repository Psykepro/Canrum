using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canrum
{
    class Player
    {
        public static string Name;
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public List<PlayerAwards> Awards { get; set; }

        public static Player CreateDefaultPlayer()
        {
            Player player = new Player();
            player.Level = 0;
            player.ExperiencePoints = 0;
            player.Awards.Add(new PlayerAwards());
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


    }
}
