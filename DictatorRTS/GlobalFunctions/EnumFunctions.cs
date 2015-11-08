using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.GlobalFunctions {
    class EnumFunctions {
        public static int GetRandomEnumElement(Enum type) {
            Array values = Enum.GetValues(type.GetType());
            return IntegerFunctions.GetRandomInteger(0, values.Length);
        }
    }
}
