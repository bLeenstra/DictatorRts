using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.GlobalFunctions {
    class IntegerFunctions {
        /// <summary>
        ///     Returns a random Int between two values
        /// </summary>
        /// <param name="startValue"></param>
        /// <param name="endValue"></param>
        /// <returns></returns>
        public static int GetRandomInteger(int startValue, int endValue) {
            Random rng = new Random();
            return rng.Next(startValue, endValue);
        }
    }
}
