using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Mission
    {
        private int Level { get; set; }
        private int Number { get; set; }

        public Mission(int level, int rnd)
        {
            Level = level;
            Number = rnd;
            throw new NotImplementedException();
        }
    }
}
