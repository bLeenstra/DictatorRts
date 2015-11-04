using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities
{
    /// <summary>
    /// This will be used for every base class we have in the program.
    /// </summary>
    public class BaseEntity
    {
        private readonly decimal _maxHealth;
        private decimal _currentHealth;

        public BaseEntity() : this(100m){
            
        }
        public BaseEntity(decimal health) {
            _maxHealth = _currentHealth = health;
        }

        public decimal MaxHealth
        {
            get { return _maxHealth; }   
        }

        public decimal CurrentHealth {
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }

        public bool IsAlive {
            get { return CurrentHealth > 0; }
        }
    }
}
