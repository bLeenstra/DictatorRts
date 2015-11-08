using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.LifeForms {
    /// <summary>
    ///     https://en.wikipedia.org/wiki/Theria
    ///     The subsection of mammals that give birth rather than lay eggs
    /// </summary>
    class Theria : Metazoa {
        private bool _pregnant;

        internal Theria(Gender sex, decimal height, decimal weight) : base(sex, height, weight) {
            this._pregnant = false;
        }

        internal Theria(Gender sex, decimal height, decimal weight, DateTime dateofBirth) : base(sex, height, weight, dateofBirth) {
            this._pregnant = false;
        }

        /// <summary>
        ///     
        /// </summary>
        public bool Pregnant {
            get {
                return _pregnant;
            }
            set {
                if( Sex == Gender.Female ) {
                    _pregnant = value;
                }
            }
        }
    }
}
