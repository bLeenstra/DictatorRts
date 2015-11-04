using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcesLibary
{
    /// <summary>
    ///     Class for money
    /// </summary>
    public class Currency : Resource
    {
        private decimal _sellStrenght;
        private decimal _buyStrength;
        private string _name;
        public Currency(string name) : this(name, 0m, 0m, 0m) {

        }

        public Currency(string name, decimal amount) : this(name, amount, 0m, 0m) {
            
        }

        public Currency(string name, decimal amount, decimal buy, decimal sell) : base(amount)
        {
            _name = name;
            _buyStrength = buy;
            _sellStrenght = sell;
        }

        public string Name => _name;

        /// <summary>
        ///     Returns the buying power of this currency
        /// </summary>
        public decimal BuyStrength
        {
            get { return _buyStrength; }
            set { _buyStrength = value; } 
        }

        /// <summary>
        ///     Returns the selling power of this currency
        /// </summary>
        public decimal SellStrenght
        {
            get { return _sellStrenght; }
            set { _sellStrenght = value; }
        }
    }
}
