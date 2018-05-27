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
    /// Interaction logic for WindowUnosClana.xaml
    /// </summary>
    public partial class WindowUnosClana : Window
    {
        public int Promena { get; set; }
        public WindowUnosClana()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Promena == 1)
            {
                this.Title = "Promenite podatke o clanu";
            }
            else
            {
                this.Title = "Unesite podatke o clanu";
            }
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxIme.Text))
            {
                MessageBox.Show("Unesite ime clana");
                textBoxIme.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxPrezime.Text))
            {
                MessageBox.Show("Unesite prezime clana");
                textBoxPrezime.Focus();
                return false;
            }

            string mb = textBoxJmbg.Text.Trim();

            if (mb.Length != 13)
            {
                MessageBox.Show("Maticni broj mora imati 13 karaktera");
                textBoxJmbg.Focus();
                return false;
            }

            foreach (char c in mb)
            {
                if (!char.IsDigit(c)) // ako nesto u maticnom broju nije cifra
                {
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(textBoxAdresa.Text))
            {
                MessageBox.Show("Unesite adresu clana");
                textBoxAdresa.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBoxTelefon.Text))
            {
                MessageBox.Show("Unesite telefon clana");
                textBoxTelefon.Focus();
                return false;
            }

            return true;
        }

        private void buttonPrihvati_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                this.DialogResult = true;
            }
        }

        private void buttonOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
