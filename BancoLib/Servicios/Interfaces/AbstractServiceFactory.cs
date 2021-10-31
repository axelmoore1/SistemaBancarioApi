﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoLib.Servicios.Interfaces
{
    public abstract class AbstractServiceFactory
    {
        public abstract IService CrearService();
    }
}
