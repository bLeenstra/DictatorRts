using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.GlobalFunctions {
    class DateFunctions {
        /// <summary>
        ///     Gets the Difference in years between 2 DateTime.
        ///     Will return a negative value if startDate > endDate
        /// </summary>
        /// <param name="startDate">The Ealier Date</param>
        /// <param name="endDate">The Later Date</param>
        /// <returns>Difference in years as a int</returns>
        public static int YearsDifference(DateTime startDate, DateTime endDate) {
            int value = endDate.Year - startDate.Year;
            return startDate > endDate.AddYears(-value) ? value - 1 : value;
        }
    }
}
