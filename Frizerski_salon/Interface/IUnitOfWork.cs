using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IKlijentRepository Klijentt { get; }
        ITerminRepository  Terminn { get; }
        IUslugaRepository Uslugaa { get; }
        IZaposleniRepository Zaposlenii { get; }

        void Complete();

    }
}
