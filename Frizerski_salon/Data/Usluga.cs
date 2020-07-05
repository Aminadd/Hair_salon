using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon
{
   public class Usluga
    {
        public int IDUsluga { get; set; }
        public string imeiprezime { get; set; }
        public string cena { get; set; }
        public string vrsta_usluge { get; set; }
        public string imeFrizera { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }
        public virtual ICollection<Klijent> Klijents { get;  internal set; }
        public  virtual ICollection<Zaposleni> Zaposlenis { get; internal set; }


        public Usluga()
        {
            Termins = new List<Termin>();
        }
    }
}
