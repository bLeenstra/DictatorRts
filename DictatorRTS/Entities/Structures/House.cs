using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Structures
{    
    public class House : Building
    {
        private int _rooms;

        public int Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }
        
    }
}
