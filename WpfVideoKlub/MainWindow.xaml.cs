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

namespace WpfVideoKlub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonClanovi_Click(object sender, RoutedEventArgs e)
        {
            WindowClan wClan = new WindowClan();
            wClan.ShowDialog();
        }

        private void buttonFilmovi_Click(object sender, RoutedEventArgs e)
        {
            WindowFilm wFilm = new WindowFilm();
            wFilm.ShowDialog();
        }

        private void buttonIznajmljivanje_Click(object sender, RoutedEventArgs e)
        {
            WindowIznajmljivanje wIz = new WindowIznajmljivanje();
            wIz.ShowDialog();
        }
    }
}
