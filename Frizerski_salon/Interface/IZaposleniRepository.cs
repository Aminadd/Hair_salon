using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Interface
{
    public interface IZaposleniRepository
    {
        IEnumerable<Zaposleni> GetAllZaposleni();
        void AddZaposleni(Zaposleni zaposleni);
        Zaposleni GetZaposleniByIDZaposleni(int zaposleniIDZaposleni);
        void DeleteZaposleni(Zaposleni zaposleni);
        Zaposleni FindByPrezime(string prezime);
        bool CombinationExists(string korisnickoIme, string sifra, string tipZaposlenog);

    }
}
