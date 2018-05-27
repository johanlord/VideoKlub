using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WpfVideoKlub
{
    class FilmDal
    {
        public List<Film> VratiFilmove()
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                return db.Films.ToList();
            }
        }

        public int UbaciFilm(Film f)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    db.Entry(f).State = EntityState.Added; // Drugi nacin za ubacivanje pomocu EntityState-a
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public int PromeniFilm(Film f)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    db.Entry(f).State = EntityState.Modified;
                    db.SaveChanges();
                    return 0;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        public int ObrisiFilm(Film f)
        {
            using (VideoKlubEntities db = new VideoKlubEntities())
            {
                try
                {
                    db.Entry(f).State = EntityState.Deleted;
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
