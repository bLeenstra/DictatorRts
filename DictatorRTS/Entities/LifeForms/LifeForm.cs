using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.LifeForms
{
    public class LifeForm : BaseEntity {
        private bool _alive;
        private readonly DateTime _dateOfBirth;

        internal LifeForm() : this(DateTime.Now) {
        }

        internal LifeForm(DateTime dateofBirth) {
            this._alive = true;
            this._dateOfBirth = dateofBirth;
        }

        internal LifeForm(decimal health) : this(DateTime.Now, health) {
        }

        internal LifeForm(DateTime dateofBirth, decimal health) : base(health) {
            this._alive = true;
            this._dateOfBirth = dateofBirth;
        }

        public bool Alive {
            get {
                return _alive;
            }
            set {
                _alive = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
        }

        public int Age
        {
            get { return GlobalFunctions.DateFunctions.YearsDifference(DateOfBirth, DateTime.Today); }
        }
    }
}
