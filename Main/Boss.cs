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
        private string Award;
        private List<Mission> Missions = new List<Mission>();
        private List<string> _bossNames = new List<string>
        {
            "Filkolev",
            "a_rusenov",
            "achebg",
            "Bi0GaMe",
            "vladislav.karamfilov",
            "iordan_93",
            "VGeorgiev",
            "nikbikbank",
            "RoYaL",
            "mpeshev",
            "Nakov"
        };
        
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
                Missions.Add(new Mission(Level));
            }
        }

        private void InitAward(int level)
        {
            Award = Libraries.GetLibraryAsGift(level);
        }

        private string GetBossName(int rnd, int level)
        {
            string name = _bossNames[rnd];
            if (level == 5)
            {
                name = _bossNames[_bossNames.Count - 1];
            }
            return name;
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
