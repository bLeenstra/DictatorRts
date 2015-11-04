using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.Resources {
    class Currency : BaseResource {
        private decimal _buyStrength;
        private readonly string _name;
        public Currency(string name, decimal amount) : this(name, amount, 0m) {

        }

        public Currency(string name, decimal amount, decimal buy) : base(amount) {
            _name = name;
            _buyStrength = buy;
        }

        /// <summary>
        ///     Returns the buying power of this currency
        /// </summary>
        public decimal BuyStrength {
            get {
                return _buyStrength;
            }
            set {
                _buyStrength = value;
            }
        }

        public string Name {
            get { return _name;}
        }

        
    }
}
