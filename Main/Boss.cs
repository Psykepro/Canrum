using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{

    public class Boss
    {
        private int level;
        public string Name { get; private set; }
        public string Award { get; private set; }
        public Mission Mission { get; private set; }

        public Boss(string name, int level, int rnd)
        {
            Name = name;
            this.level = level;
            Mission = new Mission(level, rnd);
            //InitMissions(level);
            //InitAward(level);
        }

        //private void InitMissions(int level)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Missions.Add(new Mission(Level));
        //    }
        //}

        //private void InitAward(int level)
        //{
        //    Award = Resources.GetLibraryAsGift(level);
        //}

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
