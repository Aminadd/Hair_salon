using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon
{
   public class Zaposleni
    {
        public int IDZaposleni { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brTelefona { get; set; }
        public string JMBG { get; set; }
        public string korisnickoIme { get; set; }
        public string sifra { get; set; }
        public string tipZaposlenog { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }

        public Zaposleni()
        {
            Termins = new List<Termin>();
        }
    }
}
