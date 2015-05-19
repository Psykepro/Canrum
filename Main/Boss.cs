using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{

    public class Boss
    {
        private int Level;
        private string Name;
        private List<Mission> Missions = new List<Mission>();
        private string Award;


        public Boss(string name, int level)
        {
            Name = name;
            Level = level;
            InitMissions(level);
            InitAward(level);
        }

        private void InitMissions(int level)
        {
            for (int i = 0; i < 3; i++)
            {
                Missions.Add(new Mission(level));
            }
        }

        private void InitAward(int level)
        {
            Award = Libraries.GetLibraryAsGift(level);
        }

        private Mission GetMission(int rnd)
        {
            return Missions[rnd];
        }

        public string GetAward(bool solved)
        {
            string result;
            if (solved)
            {
                result = "For solving the problem, you receive " + Award + "as a reward.";
            }
            else
            {
                result = "You failed! Come back when you consider yourself worthy!";
            }
            return result;
        }
    }
}
