using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{

    public class Boss
    {
        private int _level;
        public string Name { get; private set; }
        public string Award { get; private set; }
        public Mission Mission { get; private set; }

        public Boss(string name, int level, string award)
        {
            Name = name;
            Award = award;
            _level = level;
            Mission = new Mission(level);
        }
    }
}
