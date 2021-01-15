using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using MiBahia_Estate.Services;

namespace MiBahia_Estate.Propiedad
{
    public class PropiedadCRUD:Crud
    {
        private readonly bahia_estateContext _contexto;
        public PropiedadCRUD(bahia_estateContext contexto):base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Inmueble>> BusquedaPropiedadesCuartos(int cuartos)
        {
            var resultado = await _contexto.Inmuebles.Include(x=>x.Propiedad)
                                                     .Include(x => x.InmuebleFotos)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x=>x.Propiedad.cuartos == cuartos).ToListAsync();

            return resultado;
        }

        public async Task<List<Inmueble>> BusquedaPropiedadesDuchas(int duchas)
        {
            var resultado = await _contexto.Inmuebles.Include(x => x.Propiedad)
                                                      .Include(x => x.InmuebleDireccions)
                                                      .Include(x => x.InmueblePrecio)
                                                      .Where(x => x.Propiedad.Duchas == duchas).ToListAsync();

            return resultado;
        }

        public async Task<List<Inmueble>> getPropiedadesDuchaCuarto(int duchas, int cuartos)
        {
            var resultado = await _contexto.Inmuebles.Include(x => x.Propiedad)
                                                      .Include(x => x.InmuebleDireccions)
                                                      .Include(x => x.InmueblePrecio)
                                                      .Where(x => x.Propiedad.Duchas == duchas && x.Propiedad.Cuartos==cuartos).ToListAsync();
            return resultado;
        }

        public async Task<List<Inmueble>> getPropiedadesDuchaDestacado(int duchas, bool destacado)
        {
            var resultado = await _contexto.Inmuebles.Include(x => x.Propiedad)
                                                      .Include(x => x.InmuebleDireccions)
                                                      .Include(x => x.InmueblePrecio)
                                                      .Where(x => x.Propiedad.Duchas == duchas && x.Propiedad.Cuartos == destacado).ToListAsync();
            return resultado;
        }
            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesCuartoDestacado(int cuarto, bool destacado)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Cuartos == cuarto && x.Destacado == destacado).ToListAsync();

            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesCuartoDuchaDestacado(int cuarto, int ducha, bool destacado)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Cuartos == cuarto && x.Ducha == ducha && x.Destacado == destacado).ToListAsync();

            return resultado;
        }
    }
}
