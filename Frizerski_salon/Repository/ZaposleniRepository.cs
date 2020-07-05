using Frizerski_salon.Data;
using Frizerski_salon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Repository
{
    class ZaposleniRepository : IZaposleniRepository
    {
        private FrizerskiContext context;
        public ZaposleniRepository(FrizerskiContext context)
        {
            this.context = context;
        }
        public void AddZaposleni(Zaposleni zaposleni)
        {
            this.context.Zaposlenii.Add(zaposleni);
        }

        public bool CombinationExists(string korisnickoIme, string sifra, string tipZaposlenog)
        {
            var count = context.Zaposlenii.Where(x => x.korisnickoIme == korisnickoIme && x.sifra == sifra && x.tipZaposlenog ==tipZaposlenog).Count();
            return count == 1 ? true : false;
        }

        public void DeleteZaposleni(Zaposleni zaposleni)
        {
            this.context.Zaposlenii.Remove(zaposleni);
        }

        public Zaposleni FindByPrezime(string prezime)
        {
            return this.context.Zaposlenii.Where(c => c.prezime == prezime).First();
        }

        public IEnumerable<Zaposleni> GetAllZaposleni()
        {
            return this.context.Zaposlenii.ToList();
        }

        public Zaposleni GetZaposleniByIDZaposleni(int zaposleniIDZaposleni)
        {
            return this.context.Zaposlenii.Find(zaposleniIDZaposleni);
        }
    }
}
