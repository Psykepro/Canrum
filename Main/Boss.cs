using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canrum
{

    public class Boss
    {
        private int level;
        private string name;
        private List<Mission> missions = new List<Mission>();
        private string award;


        public Boss(string name, int level)
        {
            this.name = name;
            this.level = level;
            initMissions(level);
            initAward(level);
        }

        private void initMissions(int level)
        {
            for (int i = 0; i < 3; i++)
            {
                this.missions.Add(new Mission(level));
            }
        }

        private void initAward(int level)
        {
            this.award = Libraries.GetLibraryAsGift(level);
        }

        public Mission GetMission(int rnd)
        {
            return missions[rnd];
        }

        public string GetAward(bool solved)
        {
            string result;
            if (solved)
            {
                result = "For solving the problem, you receive " + award + "as a reward.";
            }
            else
            {
                result = "You failed! Come back when you consider yourself worthy!";
            }
            return result;
        }
    }
}
