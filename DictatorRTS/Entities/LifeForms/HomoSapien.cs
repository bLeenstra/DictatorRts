using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DictatorRTS.GlobalFunctions;

namespace DictatorRTS.Entities.LifeForms
{
    class HomoSapien : Theria {
        private string _name;

        public HomoSapien(string name) : this(name, (Gender)EnumFunctions.GetRandomEnumElement(default(Gender)), IntegerFunctions.GetRandomInteger(350, 500), IntegerFunctions.GetRandomInteger(2000, 5000)) {
        }

        public HomoSapien(string name, Gender sex, int height, int weight) : base(sex, height, weight) {
            this._name = name;
        }

        public HomoSapien(string name, Gender sex, int height, int weight, DateTime dateOfBirth) : base(sex, height, weight, dateOfBirth) {
            this._name = name;
        }

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }
    }
}
