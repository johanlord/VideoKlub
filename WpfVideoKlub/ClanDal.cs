using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfVideoKlub
{
    class ClanDal
    {
        public List<Clan> VratiClanove()
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                return db.Clans.ToList();
            }
        }

        public int UbaciClana(Clan c)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    db.Clans.Add(c);
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {

                    return -1;
                }    
            }
        }

        public int PromeniClana(Clan c)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    Clan c1 = db.Clans.Find(c.ClanID);
                    c1.Ime = c.Ime;
                    c1.Prezime = c.Prezime;
                    c1.Jmbg = c.Jmbg;
                    c1.Adresa = c.Adresa;
                    c1.Telefon = c.Telefon;
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    
                    return -1;
                }
            }
        }

        public int ObrisiClana(Clan c)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    Clan c1 = db.Clans.Find(c.ClanID);
                    db.Clans.Remove(c1);
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {

                    return -1; ;
                }
            }
        }

    }
}
