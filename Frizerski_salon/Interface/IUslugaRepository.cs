using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Interface
{
    public interface IUslugaRepository
    {
        IEnumerable<Usluga> GetAllUsluga();
        void AddUsluga(Usluga usluga);
        Usluga GetUslugaByCena(string uslugaCena);
        void DeleteUsluga(Usluga usluga);
        Usluga FindByimeiprezime(string imeiprezime);
    }
}
