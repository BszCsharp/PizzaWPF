using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfAppPizza
{
    class Bestellung:INotifyPropertyChanged
    {
        private Int32 bestellid;
        private DateTime datum;
        private Decimal bestellwert;
        private Int32 kundenr;
        private List<BestellPosition> lstpositionen = new List<BestellPosition>();
        public int Bestellid { get => bestellid; set => bestellid = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public decimal Bestellwert
        {
            get => bestellwert;
            private set
            {
                bestellwert = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Bestellwert"));
            }
        }
        public int Kundenr { get => kundenr; set => kundenr = value; }
        //TODO: Aufgabe 6
        public decimal AddBestellung(BestellPosition bestellpos)
        {
            lstpositionen.Add(bestellpos);
            decimal bwert = bestellpos.NeuePizza.Preis * bestellpos.Menge;
            this.Bestellwert += bwert;
            return bwert ;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public override string ToString()
        {
            return String.Format("KundenNr: {0}  Datum: {1}",this.Kundenr,this.Datum);
        }
    }
}
