using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.LifeForms
{
    /// <summary>
    ///     Animal
    ///     https://en.wikipedia.org/wiki/Animal
    /// </summary>
    public class Metazoa : Eukaryotes {
        public enum Gender {
            Male,
            Female
        }

        private Gender _sex;
        private decimal _height;
        private decimal _weight;

        internal Metazoa(Gender sex, decimal height, decimal weight) {
            this._sex = sex;
            this._height = height;
            this._weight = weight;
        }

        internal Metazoa(Gender sex, decimal height, decimal weight, DateTime dateofBirth) : base(dateofBirth) {
            this._sex = sex;
            this._height = height;
            this._weight = weight;
        }

        public Gender Sex {
            get {
                return _sex;
            }
            set {
                _sex = value;
            }
        }

        /// <summary>
        ///     Height kept in mm
        /// </summary>
        public decimal Height {
            get {
                return _height;
            }
            set {
                _height = value;
            }
        }

        /// <summary>
        ///     Weight kept in grams
        /// </summary>
        public decimal Weight {
            get {
                return _weight;
            }
            set {
                _weight = value;
            }
        }
    }
}
