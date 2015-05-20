using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Main
{
    public class PlayerAward
    {
        public string Description {get; private set; }

        public PlayerAward(string description)
        {
            Description = description;
        }
    }
}
