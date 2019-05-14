using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.OleDb;
using System.Collections.ObjectModel;

namespace WpfAppPizza
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        private List<Pizza> lstPizza = new List<Pizza>();
        private List<Kunde> lstKunde = new List<Kunde>();
        private ObservableCollection<Bestellung> lstBestellung = new ObservableCollection<Bestellung>();
        OleDbConnection con;
        private Bestellung bestellung;

        public MainWindow()
        {
            InitializeComponent();
            this.comboAuftrag.ItemsSource = lstBestellung;
            con = new OleDbConnection(Properties.Settings.Default.ConString);
            con.Open();
            Fill_pizza();
            this.comboPizza.ItemsSource = lstPizza;
            Fill_kunden();
            this.comboKunde.ItemsSource = lstKunde;
  
        }

        private void Fill_kunden()
        {
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "tKunde";
            cmd.CommandType = System.Data.CommandType.TableDirect;

            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lstKunde.Add(mkKunde(reader));
            }
        }

        private Kunde mkKunde(OleDbDataReader reader)
        {
            Kunde k = new Kunde();
            k.Kundennr = reader.GetInt32(0);
            k.Nachname = reader.GetString(1);
            k.Vorname = reader.GetString(2);
            k.Email = reader.GetString(3);
            return k;
        }

        private void Fill_pizza()
        {
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandText = "tPizza";
            cmd.CommandType = System.Data.CommandType.TableDirect;
            
            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                lstPizza.Add(mkPizza(reader));
            }

        }

        private Pizza mkPizza(OleDbDataReader reader)
        {
            Pizza p = new Pizza();
            p.Id = reader.GetInt32(0);
            p.Bezeichnung = reader.GetString(1);
            p.Preis = reader.GetDecimal(2);
            return p;
        }

        private void buttonBestellungErzeugen_Click(object sender, RoutedEventArgs e)
        {
            bestellung = new Bestellung();
            bestellung.Kundenr = Convert.ToInt32(((Kunde)comboKunde.SelectedItem).Kundennr);
            bestellung.Datum = DateTime.Now;
            lstBestellung.Add(bestellung);
            //comboKunde.SelectedItem = bestellung;
            comboAuftrag.SelectedItem = bestellung;
            //comboAuftrag.IsDropDownOpen = true;
            comboAuftrag.Text = bestellung.ToString();
        }

  

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Bestellung b = (Bestellung)comboAuftrag.SelectedItem;
            BestellPosition bp = new BestellPosition();
            bp.Bestellnummer = b.Bestellid;
            bp.Menge = Convert.ToInt32(txtBoxMenge.Text);
            bp.NeuePizza = (Pizza)comboPizza.SelectedItem;
            b.AddBestellung(bp);
        }
    }
}
