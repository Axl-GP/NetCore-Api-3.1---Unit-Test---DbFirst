using BahiaRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BahiaRealEstate.Services
{
    public class SolarCrud
    {
        private readonly bahiaEstateContext context;

        public SolarCrud()
        {
            context = new bahiaEstateContext();
        }

        public async Task<List<Solar>> getSolares()
        {
            var resultado = await context.Solar.Include(x => x.SolarFoto).Include(y => y.SolarDireccion).Include(z => z.SolarPrecio).ThenInclude(z=>z.Moneda).ToListAsync();

            return resultado;
        }
        public async Task<Solar> getSolar(int id)
        {
            var resultado = await context.Solar.Include(x => x.SolarFoto).Include(x => x.SolarDireccion).Include(x => x.SolarPrecio).ThenInclude(z => z.Moneda).Where(x => x.Id == id).FirstOrDefaultAsync();

            return resultado;
        }

        public async Task<List<Solar>> getSolaresDestacadas(bool destacado)
        {
            var resultado = await context.Solar.Include(x => x.SolarFoto).Include(x => x.SolarDireccion).Include(x => x.SolarPrecio).Where(x => x.Destacado == destacado).ToListAsync();

            return resultado;
        }

        

        public async Task<bool> AddSolar(Solar Solar, SolarPrecio precio, SolarDireccion direccion, List<SolarFoto> foto)
        {
            try
            {
                await context.AddAsync(Solar);
                await context.AddAsync(precio);
                await context.AddAsync(direccion);

                foreach (SolarFoto foto1 in foto)
                {
                    context.Add(foto1);
                    await context.SaveChangesAsync();
                }

                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> EditSolar(Solar Solar, SolarPrecio precio, SolarDireccion direccion, List<SolarFoto> listaFotos, int id)
        {
            try
            {
                var editandoSolar = await context.Solar.Where(x => x.Id == id).FirstOrDefaultAsync();

                editandoSolar.Titulo = Solar.Titulo;
                editandoSolar.Descripcion = Solar.Descripcion;
                editandoSolar.Area = Solar.Area;              
                editandoSolar.Destacado = Solar.Destacado;
              

                var editandoPrecio = await context.SolarPrecio.Where(x => x.Id == id).FirstOrDefaultAsync();

                editandoPrecio.Monedaid = precio.Monedaid;
                editandoPrecio.NotaPrecio = precio.NotaPrecio;

                var editandoDireccion = await context.SolarDireccion.Where(x => x.IdSolar == id).FirstOrDefaultAsync();

                editandoDireccion.Direccion = direccion.Direccion;

                List<SolarFoto> editandoFoto = context.SolarFoto.Where(x => x.Solarid == id).ToList();

                editandoFoto = listaFotos;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteSolar(int id)
        {
            var resultado = await context.Solar.Include(x => x.SolarFoto).Include(x => x.SolarDireccion).Include(x => x.SolarPrecio).Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Remove(resultado);
            context.SaveChanges();

            return true;
        }
    }
}

