using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPizza
{
    class BestellPosition
    {
        private Int32 id;
        private Int32 bestellnummer;
        private Pizza neuePizza;
        private Int32 menge;

        public int Id { get => id; set => id = value; }
        public int Bestellnummer { get => bestellnummer; set => bestellnummer = value; }
        public int Menge { get => menge; set => menge = value; }
        internal Pizza NeuePizza { get => neuePizza; set => neuePizza = value; }
    }
}
