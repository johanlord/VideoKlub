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
    /// Interaction logic for WindowClan.xaml
    /// </summary>
    public partial class WindowClan : Window
    {

        private ClanDal cDal = new ClanDal();
        public WindowClan()
        {
            InitializeComponent();
        }

        private void PrikaziClanove()
        {
            listBox1.ItemsSource = cDal.VratiClanove();
            listBox1.DisplayMemberPath = "PunoIme";
            listBox1.SelectedValuePath = "ClanID";
        }

        private void buttonUbaci_Click(object sender, RoutedEventArgs e)
        {
            WindowUnosClana wuc = new WindowUnosClana();
            wuc.Promena = 0;
            if (wuc.ShowDialog() == true)
            {
                Clan c = new Clan();
                c.Ime = wuc.textBoxIme.Text;
                c.Prezime = wuc.textBoxPrezime.Text;
                c.Jmbg = wuc.textBoxJmbg.Text;
                c.Adresa = wuc.textBoxAdresa.Text;
                c.Telefon = wuc.textBoxTelefon.Text;

                int rezultat = cDal.UbaciClana(c);

                if (rezultat == 0)
                {
                    PrikaziClanove();
                    listBox1.SelectedValue = c.ClanID; // ovo smemo da radimo jer smo definisali .SelectedValuePath za listBox
                    MessageBox.Show("Ubacili ste clana");
                }
                else
                {
                    MessageBox.Show("Greska pri unosu clana");
                }
            }
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            Clan c = (Clan)listBox1.SelectedItem;
            WindowUnosClana wpc = new WindowUnosClana();
            wpc.Promena = 1;

            wpc.textBoxIme.Text = c.Ime;
            wpc.textBoxPrezime.Text = c.Prezime;
            wpc.textBoxJmbg.Text = c.Jmbg;
            wpc.textBoxAdresa.Text = c.Adresa;
            wpc.textBoxTelefon.Text = c.Telefon;
            
           
            if (wpc.ShowDialog() == true)
            {
                c.Ime = wpc.textBoxIme.Text;
                c.Prezime = wpc.textBoxPrezime.Text;
                c.Jmbg = wpc.textBoxJmbg.Text;
                c.Adresa = wpc.textBoxAdresa.Text;
                c.Telefon = wpc.textBoxTelefon.Text;

                int rezultat = cDal.PromeniClana(c);
                if (rezultat == 0)
                {
                    PrikaziClanove();
                    listBox1.SelectedValue = c.ClanID;
                    MessageBox.Show("Promenjen clan");
                }
                else
                {
                    MessageBox.Show("Greska pri promeni clana");
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziClanove();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }

            Clan c = (Clan)listBox1.SelectedItem;

            textBoxIme.Text = c.Ime;
            textBoxPrezime.Text = c.Prezime;
            textBoxJmbg.Text = c.Jmbg;
            textBoxAdresa.Text = c.Adresa;
            textBoxTelefon.Text = c.Telefon;
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }

            Clan c = (Clan)listBox1.SelectedItem;

            MessageBoxResult mrez = MessageBox.Show("Da li zelite da obrisete clana " + c.PunoIme, "Pitanje?", MessageBoxButton.YesNo);

            if (mrez == MessageBoxResult.No)
            {
                return;
            }

            int rezultat = cDal.ObrisiClana(c);

            if (rezultat == 0)
            {
                PrikaziClanove();
                textBoxIme.Clear();
                textBoxPrezime.Clear();
                textBoxJmbg.Clear();
                textBoxAdresa.Clear();
                textBoxTelefon.Clear();
                listBox1.SelectedIndex = -1;

                MessageBox.Show("Obrisan clan");
            }
            else
            {
                MessageBox.Show("Greska pri brisanju");
            }
        }
    }
}
