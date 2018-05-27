using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfVideoKlub
{
    public partial class Clan // parcijalna klasa se koristi kada zelimo da se klasa proteze na vise fajlova
    {
        public string PunoIme
        {
            get
            {
                return Ime + " " + Prezime; // ovo nam treba za punjenje ListBox kontrole da se prikaze ime i prezime
            }
        }
    }
}
