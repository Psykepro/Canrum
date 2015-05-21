using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Mission
    {
        public int Level { get; private set; }
        public int Number { get; private set; }

        public Mission(int level, int rnd)
        {
            Level = level;
            Number = rnd;
        }
    }
}
