using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPizza
{
    class Kunde
    {
        private Int32 kundennr;
        private String nachname;
        private String vorname;
        private String email;

        public int Kundennr { get => kundennr; set => kundennr = value; }
        public string Nachname { get => nachname; set => nachname = value; }
        public string Vorname { get => vorname; set => vorname = value; }
        public string Email { get => email; set => email = value; }
        public override string ToString()
        {
            return String.Format("{0}: {1}, {2}", this.Kundennr, this.Nachname, this.Vorname);
        }
        public String Name
        {
            get { return String.Format("{0}, {1}", this.Nachname, this.Vorname); }
        }

    }
}
