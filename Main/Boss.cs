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
        public string Name { get; set; }
        public string Award { get; set; }
        public Mission Mission { get; private set; }

        public Boss(string name, int level,string award)
        {
            Name = name;
            Award = award;
            this.level = level;
            Random r=new Random();
            int number=r.Next(1, 6);
            Mission = new Mission(level, number);

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
