using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon
{
  public  class Klijent
    {
        public int IDKlijent { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string JMBG { get; set; }
        public string brTel { get; set; }
        public string tipKose { get; set; }
        public float duzinaKose { get; set; }
        public string preparatiZaPranje { get; set; }
        public string oblikovanjeKose { get; set; }
        public virtual ICollection<Termin> Termins { get; set; }


        public Klijent()
        {
            Termins = new List<Termin>();           
        }

    }
}
