using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon
{
   public class Termin
    {
        public int IDTermin { get; set; }
        public string vreme { get; set; }
        public string imeiprezime { get; set; }
        public int KlijentID { get; set; }
        public int UslugaID { get; set; }
        public Klijent Klijent { get; set; }
        public Usluga Usluga { get; set; }  
        public virtual ICollection<Usluga> Uslugas { get; set; }
        public virtual ICollection<Klijent> Klijents { get; set; }
        public virtual ICollection<Zaposleni> Zaposlenis { get; set; }
    }
}
