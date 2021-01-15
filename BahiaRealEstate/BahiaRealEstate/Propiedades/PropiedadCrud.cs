using BahiaRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BahiaRealEstate.Services
{
    public class PropiedadCrud
    {

        private readonly bahiaEstateContext context;

        public PropiedadCrud()
        {
            context = new bahiaEstateContext();
        }

       

        public async Task<List<Propiedad>> getPropiedades()
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).ToListAsync();

            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesCuartos(int cuartos)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Cuartos == cuartos).ToListAsync();

            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesDuchas(int duchas)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Ducha == duchas).ToListAsync();

            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesDestacadas(bool destacado)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Destacado == destacado).ToListAsync();

            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesDuchaCuarto(int duchas, int cuarto)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Ducha == duchas && x.Cuartos == cuarto).ToListAsync();

            return resultado;
        }

        public async Task<List<Propiedad>> getPropiedadesDuchaDestacado(int duchas, bool destacado)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(y => y.PropiedadDireccion).Include(z => z.PropiedadPrecio).Where(x => x.Ducha == duchas && x.Destacado == destacado).ToListAsync();

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
        public async Task<Propiedad> ObtenerPropiedad(int id)
        {
            var resultado = await context.Propiedad.Include(x => x.PropiedadFoto).Include(x => x.PropiedadDireccion).Include(x => x.PropiedadPrecio).Where(x => x.Id == id).FirstOrDefaultAsync();

            return resultado;
        }

        public bool AgregarPropiedad(Propiedad propiedad, PropiedadPrecio precio, PropiedadDireccion direccion, List<PropiedadFoto> foto)
        {
            try
            {
                 context.Add(propiedad);
                 context.AddAsync(precio);
                 context.AddAsync(direccion);

                foreach (PropiedadFoto foto1 in foto)
                {
                    context.Add(foto1);
                    context.SaveChangesAsync();
                }
           
                 

                 
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return false;
            }
        }

        public async Task<bool> EditPropiedad(Propiedad propiedad, PropiedadPrecio precio, PropiedadDireccion direccion,List<PropiedadFoto> foto, int id)
        {
            try
            {
                var editandoPropiedad = await context.Propiedad.Where(x => x.Id == id).FirstOrDefaultAsync();

                editandoPropiedad.Titulo = propiedad.Titulo;
                editandoPropiedad.Descripcion = propiedad.Descripcion;
                editandoPropiedad.Ducha = propiedad.Ducha;
                editandoPropiedad.Cuartos = propiedad.Cuartos;
                editandoPropiedad.CuartoServicio = propiedad.CuartoServicio;
                editandoPropiedad.Area = propiedad.Area;
                editandoPropiedad.AreaGym = propiedad.AreaGym;
                editandoPropiedad.AreaLavado = propiedad.AreaLavado;
                editandoPropiedad.Destacado = propiedad.Destacado;
                editandoPropiedad.Caliente = propiedad.Caliente;

                var editandoPrecio = await context.PropiedadPrecio.Where(x => x.Id == id).FirstOrDefaultAsync();

                editandoPrecio.Monedaid = precio.Monedaid;
                editandoPrecio.NotaPrecio = precio.NotaPrecio;

                var editandoDireccion = await context.PropiedadDireccion.Where(x => x.IdPropiedad == id).FirstOrDefaultAsync();

                editandoDireccion.Direccion = direccion.Direccion;

                List<PropiedadFoto> editandoFoto = await context.PropiedadFoto.Where(x => x.Propiedadid == id).ToListAsync();

                editandoFoto = foto;

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeletePropiedad(int id)
        {
            var resultado = await context.Propiedad.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Remove(resultado);
            context.SaveChanges();

            return true;
        }
    }
}
