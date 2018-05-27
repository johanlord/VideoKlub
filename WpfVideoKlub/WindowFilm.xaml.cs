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
    /// Interaction logic for WindowFilm.xaml
    /// </summary>
    public partial class WindowFilm : Window
    {

        private FilmDal fDal = new FilmDal();
        public WindowFilm()
        {
            InitializeComponent();
        }

        private void PrikaziFilmove()
        {
            listBox1.ItemsSource = fDal.VratiFilmove();
            listBox1.DisplayMemberPath = "NazivFilma";
            listBox1.SelectedValuePath = "FilmID";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PrikaziFilmove();
        }

        private void buttonUbaci_Click(object sender, RoutedEventArgs e)
        {
            WindowUnosFilma wFilm = new WindowUnosFilma();
            wFilm.Promena = 0;
            if (wFilm.ShowDialog() == true)
            {
                Film f = new Film();
                f.NazivFilma = wFilm.textBoxNaziv.Text;
                f.Trajanje = int.Parse(wFilm.textBoxTrajanje.Text);
                f.Zanr = wFilm.textBoxZanr.Text;

                int rezultat = fDal.UbaciFilm(f);

                if (rezultat == 0)
                {
                    MessageBox.Show("Uspesno ste ubacili film", "Poruka");
                    PrikaziFilmove();
                    listBox1.SelectedValue = f.FilmID;
                }
                else
                {
                    MessageBox.Show("Greska pri unosu filma", "Poruka");
                }
            }
        }

        private void buttonPromeni_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
            Film f = (Film)listBox1.SelectedItem;
            WindowUnosFilma wfilm = new WindowUnosFilma();
            wfilm.Promena = 1;
            wfilm.textBoxNaziv.Text = f.NazivFilma;
            wfilm.textBoxTrajanje.Text = f.Trajanje.ToString();

            wfilm.textBoxZanr.Text = f.Zanr;

            if (wfilm.ShowDialog() == true)
            {
                f.NazivFilma = wfilm.textBoxNaziv.Text;
                f.Trajanje = int.Parse(wfilm.textBoxTrajanje.Text);
                f.Zanr = wfilm.textBoxZanr.Text;
                int rezultat = fDal.PromeniFilm(f);
                if (rezultat == 0)
                {
                    PrikaziFilmove();
                    listBox1.SelectedValue = f.FilmID;
                    MessageBox.Show("Uspesno ste izmenili film", "Film promenjen");
                }
                else
                {
                    MessageBox.Show("Greska pri izmeni filma", "Film nije promenjen");
                }
            }
        }

        private void buttonObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                return;
            }
                Film selektovaniFilm = (Film)listBox1.SelectedItem;
                if (MessageBox.Show("Da li ste siguran da zelite brisanje?", "Upozorenje",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                int rez = fDal.ObrisiFilm(selektovaniFilm);
                if (rez == 0)
            {
                PrikaziFilmove();
                listBox1.SelectedIndex = -1;
                textBoxNaziv.Clear();
                textBoxTrajanje.Clear();
                textBoxZanr.Clear();
            }
            else
            {
                MessageBox.Show("Ne mozete obrisati film");
            }
            }
            
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedIndex <0)
            {
                return;
            }
                Film f = (Film)listBox1.SelectedItem;
                textBoxNaziv.Text = f.NazivFilma;
                textBoxTrajanje.Text = f.Trajanje.ToString();
                textBoxZanr.Text = f.Zanr;
            
        }
    }
}
