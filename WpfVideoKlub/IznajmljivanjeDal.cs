using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfVideoKlub
{
    class IznajmljivanjeDal
    {
        public List<Iznajmljivanje> VratiIznajmljivanja()
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                return db.Iznajmljivanjes.ToList();
            }
        }
        public List<PrikaziIznajmljivanja_Result> PrikaziIznajmljivanja()
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                return db.PrikaziIznajmljivanja().ToList();
            }
        }
        public Iznajmljivanje VratiIznajmjivanje(int id)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                return db.Iznajmljivanjes.Find(id);
            }
        }
        public int UbaciIznajmljivanje(Iznajmljivanje iz)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    db.Iznajmljivanjes.Add(iz);
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public int PromeniIznajmljivanje(Iznajmljivanje iz)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    Iznajmljivanje i = db.Iznajmljivanjes.Find(iz.IznajmljivanjeID);
                    i.FilmID = iz.FilmID;
                    i.ClanID = iz.ClanID;
                    i.DatumIznajmljivanja = iz.DatumIznajmljivanja;
                    i.DatumVracanja = iz.DatumVracanja;
                    i.Cena = iz.Cena;
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
        public int ObrisiIznajmljivanje(Iznajmljivanje iz)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    Iznajmljivanje i = db.Iznajmljivanjes.Find(iz.IznajmljivanjeID);
                    db.Iznajmljivanjes.Remove(i);
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }
    }
}
