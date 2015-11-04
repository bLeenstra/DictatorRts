using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Structures
{
    public class Skyscraper : Building
    {
        private int _floors;

        public int Floors
        {
            get { return _floors; }
            set { _floors = value; }
        }

    }
}
