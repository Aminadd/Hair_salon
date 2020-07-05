using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Interface
{
 public   interface ITerminRepository
    {
        IEnumerable<Termin> GetAllTermin();
        void AddTermin(Termin termin);
        Termin GetTerminByimeiprezime(string terminimeiprezime);
        void DeleteTermin(Termin termin);
        Termin FindByimeiprezime(string imeiprezime);
       
    }
}
