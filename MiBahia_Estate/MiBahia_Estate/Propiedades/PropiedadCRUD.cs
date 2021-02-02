using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MiBahia_Estate.Services;
using MiBahia_Estate.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MiBahia_Estate
{
    public class PropiedadCRUD:Crud
    {
        private readonly bahia_estateContext _contexto;

        public PropiedadCRUD(bahia_estateContext contexto):base(contexto)
        {
            _contexto = contexto;
        }
        [ServiceFilter(typeof(MyFilter))]
        public async Task<List<Property>> BusquedaPropiedadesCuartos(int cuartos)
        {
            var resultado = await _contexto.Inmuebles.Include(x=>x.Propiedad)
                                                     .Include(x => x.InmuebleFotos)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x=>x.Propiedad.Cuartos == cuartos).ToListAsync();

            return resultado;
        }

        public async Task<List<Property>> BusquedaPropiedadesDuchas(int duchas)
        {
            var resultado = await _contexto.Inmuebles.Include(x => x.Propiedad)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x => x.Propiedad.Ducha == duchas).ToListAsync();

            return resultado;
        }

        public async Task<List<Property>> BusquedaPropiedadesDuchaCuarto(int duchas, int cuartos)
        {
            var resultado = await _contexto.Inmuebles.Include(x => x.Propiedad)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x => x.Propiedad.Ducha == duchas && x.Propiedad.Cuartos==cuartos).ToListAsync();
            return resultado;
        }

        public async Task<List<Property>> BusquedaPropiedadesDuchaDestacado(int duchas, bool destacado)
        {
            var resultado = await _contexto.Inmuebles.Include(x => x.Propiedad)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x => x.Propiedad.Ducha == duchas && x.Propiedad.Destacado == destacado).ToListAsync();
            return resultado;
        
        }

        public async Task<List<House>> BusquedaPropiedadesCuartoDestacado(int cuarto, bool destacado)
        {
            var resultado = await _contexto.Propiedads.Include(x => x.InmuebleFotos)
                                                      .Include(y => y.InmuebleDireccions)
                                                      .Include(z => z.InmueblePrecio)
                                                      .Where(x => x.Cuartos == cuarto && x.Destacado == destacado).ToListAsync();

            return resultado;
        }

        public async Task<List<House>> BusquedaPropiedadesCuartoDuchaDestacado(int cuarto, int ducha, bool destacado)
        {
            var resultado = await _contexto.Propiedads.Include(x => x.InmuebleFotos)
                                                      .Include(y => y.InmuebleDireccions)
                                                      .Include(z => z.InmueblePrecio)
                                                      .Where(x => x.Cuartos == cuarto && x.Ducha == ducha && x.Destacado == destacado).ToListAsync();

            return resultado;
        }
    }
}
