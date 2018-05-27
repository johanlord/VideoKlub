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
    /// Interaction logic for WindowUnosFilma.xaml
    /// </summary>
    public partial class WindowUnosFilma : Window
    {

        public int Promena { get; set; }
        public WindowUnosFilma()
        {
            InitializeComponent();
        }

        private bool Validacija()
        {
            if (string.IsNullOrWhiteSpace(textBoxNaziv.Text))
            {
                MessageBox.Show("Morate uneti naziv filma", "Poruka");
                textBoxNaziv.Focus();
                return false;
            }
            int t;
            if (!int.TryParse(textBoxTrajanje.Text, out t))
            {
                MessageBox.Show("Trajanje filma je ceo broj minuta", "Poruka");
                textBoxTrajanje.Clear();
                textBoxTrajanje.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(textBoxZanr.Text))
            {
                MessageBox.Show("Morate uneti zanr filma", "Poruka");
                textBoxZanr.Focus();
                return false;
            }
            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Promena == 1)
            {
                this.Title = "Promenite podatke o filmu";
            }
            else
            {
                this.Title = "Unesite podatke o filmu";
            }
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
