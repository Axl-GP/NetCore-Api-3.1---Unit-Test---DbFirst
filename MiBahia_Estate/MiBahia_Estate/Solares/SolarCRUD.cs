using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using MiBahia_Estate.Services;

namespace MiBahia_Estate
{
    public class SolarCrud : Crud
    {
        private readonly bahia_estateContext _contexto;


        public SolarCrud(bahia_estateContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }


    }
}

