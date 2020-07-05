using Frizerski_salon.Data;
using Frizerski_salon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Repository
{
    class UslugaRepository : IUslugaRepository
    {
        private FrizerskiContext context;
        public UslugaRepository(FrizerskiContext context)
        {
            this.context = context;
        }
        public void AddUsluga(Usluga usluga)
        {
            this.context.Uslugaa.Add(usluga);
        }

        public void DeleteUsluga(Usluga usluga)
        {
            this.context.Uslugaa.Remove(usluga);
        }

        public Usluga FindByimeiprezime(string imeiprezime)
        {
            return this.context.Uslugaa.Where(c => c.imeiprezime == imeiprezime).First();
        }
        public IEnumerable<Usluga> GetAllUsluga()
        {
            return this.context.Uslugaa.ToList();
        }

        public Usluga GetUslugaByCena(string uslugaCena)
        {
            return this.context.Uslugaa.Find(uslugaCena);
        }
    }
}
