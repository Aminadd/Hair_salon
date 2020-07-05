using Frizerski_salon.Interface;
using Frizerski_salon.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frizerski_salon.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private FrizerskiContext context;
        private KlijentRepository klijentt;
        private TerminRepository terminn;
        private UslugaRepository uslugaa;
        private ZaposleniRepository zaposlenii;


        public UnitOfWork(FrizerskiContext context)
        {
            this.context = context;
        }

        public IKlijentRepository Klijentt
        {
            get
            {
                return klijentt ?? (klijentt = new KlijentRepository(context));
            }
        }
        public ITerminRepository Terminn
        {
            get
            {
                return terminn ?? (terminn = new TerminRepository(context));
            }
        }
        public IUslugaRepository Uslugaa
        {
            get
            {
                return uslugaa ?? (uslugaa = new UslugaRepository(context));
            }
        }
        public IZaposleniRepository Zaposlenii  
        {
            get
            {
                return zaposlenii ?? (zaposlenii = new ZaposleniRepository(context));
            }
        }
       
        public void Complete()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
