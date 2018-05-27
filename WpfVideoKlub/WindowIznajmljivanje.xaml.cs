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
using System.Windows.Shapes;

namespace WpfVideoKlub
{
    /// <summary>
    /// Interaction logic for WindowIznajmljivanje.xaml
    /// </summary>
    public partial class WindowIznajmljivanje : Window
    {
        private IznajmljivanjeDal izdal = new IznajmljivanjeDal();
        public WindowIznajmljivanje()
        {
            InitializeComponent();
        }
        private void prikaziIznajmljivanja()
        {
            dataGrid1.ItemsSource = izdal.PrikaziIznajmljivanja();
            dataGrid1.SelectedValuePath = "IznajmljivanjeID";
        }

        private void buttonUbaci_Click(object sender, RoutedEventArgs e)
        {
            WindowUnosIznajmljivanja wIzn = new WindowUnosIznajmljivanja();
            wIzn.Promena = 0;
            if (wIzn.ShowDialog() == true)
            {
                Clan c = (Clan)wIzn.comboBoxClan.SelectedItem;
                Film f = (Film)wIzn.comboBoxFilm.SelectedItem;
                Iznajmljivanje iz = new Iznajmljivanje();
                iz.ClanID = c.ClanID;
                iz.FilmID = f.FilmID;
                iz.DatumIznajmljivanja = wIzn.datePicker1.SelectedDate.Value;
                iz.DatumVracanja = wIzn.datePicker2.SelectedDate;
                iz.Cena = decimal.Parse(wIzn.textBoxCena.Text);
                int rezultat = izdal.UbaciIznajmljivanje(iz);
                if (rezultat == 0)
                {
                    prikaziIznajmljivanja();
                    dataGrid1.Focus();
                    dataGrid1.SelectedValue = iz.IznajmljivanjeID;
                    dataGrid1.ScrollIntoView(dataGrid1.SelectedItem);
                    MessageBox.Show("Uspesno ste izvrsili iznajmljivanje", "Poruka");
                }
                else
                {
                    MessageBox.Show("Greska pri unosu iznajmljivanja", "Poruka");
                }
            }
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex < 0)
            {
                return;
            }
            PrikaziIznajmljivanja_Result red = (PrikaziIznajmljivanja_Result)dataGrid1.SelectedItem;
            int indeks = dataGrid1.Items.IndexOf(red);
            int ID = red.IznajmljivanjeID;

            Iznajmljivanje selIznajmljivanje = izdal.VratiIznajmjivanje(ID);
            WindowUnosIznajmljivanja wIzn = new WindowUnosIznajmljivanja();

            wIzn.Promena = 1;

            wIzn.comboBoxClan.SelectedValue = selIznajmljivanje.ClanID;
            wIzn.comboBoxFilm.SelectedValue = selIznajmljivanje.FilmID;
            wIzn.datePicker1.SelectedDate = selIznajmljivanje.DatumIznajmljivanja;
            wIzn.datePicker2.SelectedDate = selIznajmljivanje.DatumVracanja;
            wIzn.textBoxCena.Text = selIznajmljivanje.Cena.ToString();

            if (wIzn.ShowDialog() == true)
            {
                Clan c = (Clan)wIzn.comboBoxClan.SelectedItem;
                Film f = (Film)wIzn.comboBoxFilm.SelectedItem;
                selIznajmljivanje.ClanID = c.ClanID;
                selIznajmljivanje.FilmID = f.FilmID;
                selIznajmljivanje.DatumIznajmljivanja = wIzn.datePicker1.SelectedDate.Value;
                selIznajmljivanje.DatumVracanja = wIzn.datePicker2.SelectedDate.Value;
                selIznajmljivanje.Cena = decimal.Parse(wIzn.textBoxCena.Text);
                int rezultat = izdal.PromeniIznajmljivanje(selIznajmljivanje);
                if (rezultat == 0)
                {
                    prikaziIznajmljivanja();
                    dataGrid1.Focus();
                    dataGrid1.SelectedIndex = indeks;
                    dataGrid1.ScrollIntoView(red);
                    MessageBox.Show("Uspesno ste izmenili iznajmljivanje",
                    "Iznajmljivanje promenjeno");
                }
                else
                {
                    MessageBox.Show("Greska pri izmeni iznajmljivanja", "Iznajmljivanje nije promenjeno");
                }
            }
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex < 0)
            {
                return;
            }
            PrikaziIznajmljivanja_Result red = (PrikaziIznajmljivanja_Result)dataGrid1.SelectedItem;
            Iznajmljivanje iz = izdal.VratiIznajmjivanje(red.IznajmljivanjeID);
            if (MessageBox.Show("Da li ste sigurni da zelite brisanje?", "Upozorenje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int rezultat = izdal.ObrisiIznajmljivanje(iz);
                if (rezultat == 0)
                {
                    prikaziIznajmljivanja();
                }
                else
                {
                    MessageBox.Show("Ne mozete obrisati Iznajmljivanje", "Poruka");
                }
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            prikaziIznajmljivanja();
        }
       
    }
}

