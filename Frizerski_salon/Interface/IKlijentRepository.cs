using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Interface
{
    public interface IKlijentRepository
    {
        IEnumerable<Klijent> GetAllKlijent();
        void AddKlijent(Klijent klijent);
        Klijent GetKlijentByIDKlijent(int klijentIDKlijent);
        void DeleteKlijent(Klijent klijent);
        Klijent FindByime(string ime);
    }
}
