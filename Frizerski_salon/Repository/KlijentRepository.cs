using Frizerski_salon.Data;
using Frizerski_salon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Repository
{
    class KlijentRepository : IKlijentRepository
    {
        private FrizerskiContext context;
        public KlijentRepository(FrizerskiContext context)
        {
            this.context = context;
        }
        public void AddKlijent(Klijent klijent)
        {
            this.context.Klijentt.Add(klijent);
        }

        public void DeleteKlijent(Klijent klijent)
        {
            this.context.Klijentt.Remove(klijent);
        }

        public Klijent FindByime(string ime)
        {
            return this.context.Klijentt.Where(c => c.ime == ime).First();
        }

        public IEnumerable<Klijent> GetAllKlijent()
        {
            return this.context.Klijentt.ToList();
        }

        public Klijent GetKlijentByIDKlijent(int klijentIDKlijent)
        {
            return this.context.Klijentt.Find(klijentIDKlijent);
        }
    }
}
