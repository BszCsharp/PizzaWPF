using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPizza
{
    class Pizza
    {
        private Int32 id;
        private String bezeichnung;
        private decimal preis;
        
        public int Id { get => id; set => id = value; }
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }
        public decimal Preis { get => preis; set => preis = value; }
        public override string ToString()
        {
            return this.Bezeichnung;
        }

    }
}
