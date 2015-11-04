using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities
{
    public class BaseTerrain
    {
        // do we need to have the parent class???
        public override string ToString()
        {
            return string.Format("{0} ({1}, {2})", this.GetType().Name, this.X, this.Y);
        }

        private float _depth;

        public float Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        private int _x, _y;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        
    }
}
