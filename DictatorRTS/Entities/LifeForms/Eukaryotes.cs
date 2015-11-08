using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictatorRTS.Entities.LifeForms
{
    /// <summary>
    ///     Organisms with nucleated cells
    ///     https://en.wikipedia.org/wiki/Eukaryote
    /// </summary>
    public class Eukaryotes : LifeForm {

        internal Eukaryotes() {

        }

        internal Eukaryotes(decimal health) : base(health) {

        }

        internal Eukaryotes(DateTime dateofBirth) : base(dateofBirth) {

        }

        internal Eukaryotes(DateTime dateofBirth, decimal health) : base(dateofBirth, health) {

        }
    }
}
