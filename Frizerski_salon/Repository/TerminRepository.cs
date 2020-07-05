using Frizerski_salon.Data;
using Frizerski_salon.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Repository
{
    class TerminRepository : ITerminRepository
    {
        private FrizerskiContext context;
        public TerminRepository(FrizerskiContext context)
        {
            this.context = context;
        }
        public void AddTermin(Termin termin)
        {
            this.context.Terminn.Add(termin);
        }

        public void DeleteTermin(Termin termin)
        {
            this.context.Terminn.Remove(termin);
        }

        public Termin FindByimeiprezime(string imeiprezime)
        {
            return this.context.Terminn.Where(c => c.imeiprezime == imeiprezime).First();
        }

        public IEnumerable<Termin> GetAllTermin()
        {
            return this.context.Terminn.ToList();
        }

        public Termin GetTerminByimeiprezime(string terminimeiprezime)
        {
            return this.context.Terminn.Find(terminimeiprezime);
        }
    }
}
