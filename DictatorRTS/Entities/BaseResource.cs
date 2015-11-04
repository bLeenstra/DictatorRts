using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities {
    class BaseResource
    {
        private decimal _amount;

        public BaseResource(decimal amount)
        {
            this._amount = amount;
        }

        public decimal Amount { get; set; }
    }
}
