using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Misc
{    
    public class RandomGenerator
    {
        public Random baseRandom = new Random();

        /// <summary>
        ///  Do we allow them to restart the same game. we need to record the seed we have in there.
        /// </summary>
        /// <returns></returns>
        public static int GetBaseSeed()
        {
            return 0;
        }
    }
}
