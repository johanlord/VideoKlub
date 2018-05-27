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
    /// Interaction logic for WindowUnosIznajmljivanja.xaml
    /// </summary>
    public partial class WindowUnosIznajmljivanja : Window
    {
        public int Promena { get; set; }
        public WindowUnosIznajmljivanja()
        {
            InitializeComponent();
        }

        private bool Validacija()
        {
            if (comboBoxClan.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati clana", "Poruka");
                return false;
            }
            if (comboBoxFilm.SelectedIndex < 0)
            {
                MessageBox.Show("Morate odabrati film", "Poruka");
                return false;
            }
            if (!datePicker1.SelectedDate.HasValue)
            {
                MessageBox.Show("Morate odabrati datum uzimanja", "Poruka");
                return false;
            }
            if (!datePicker2.SelectedDate.HasValue)
            {
                MessageBox.Show("Morate odabrati datum vracanja", "Poruka");
                return false;
            }
            decimal cena;
            if (!decimal.TryParse(textBoxCena.Text, out cena))
            {
                MessageBox.Show("Morate uneti cenu", "Poruka");
                return false;
            }
            return true;
        }
        private void prikaziClanove()
        {
            ClanDal cdal = new ClanDal();
            comboBoxClan.ItemsSource = cdal.VratiClanove();
            comboBoxClan.DisplayMemberPath = "PunoIme";
            comboBoxClan.SelectedValuePath = "ClanID";
        }
        private void prikaziFilmove()
        {
            FilmDal fdal = new FilmDal();
            comboBoxFilm.ItemsSource = fdal.VratiFilmove();
            comboBoxFilm.DisplayMemberPath = "NazivFilma";
            comboBoxFilm.SelectedValuePath = "FilmID";
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Promena == 1)
            {
                this.Title = "Promeni podatke o iznajmljivanju";
            }
            else
            {
                this.Title = "Unesi podatke o iznajmljivanju";
                datePicker1.SelectedDate = DateTime.Now;
                datePicker2.SelectedDate = DateTime.Now.AddDays(7);
            }
            prikaziClanove();
            prikaziFilmove();
        }
    }
}
