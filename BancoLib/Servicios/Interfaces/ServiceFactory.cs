using BancoLib.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.Servicios.Interfaces
{
    public class ServiceFactory : AbstractServiceFactory
    {
        public override IService CrearService()
        {
            return new BancoService();
        }
    }
}
