using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace MiBahia_Estate.Services
{
    public abstract class Crud
    {
        private readonly bahia_estateContext _contexto;

        public Crud(bahia_estateContext contexto)
        {
            _contexto = contexto;
        }
        public virtual async Task<List<Inmueble>> Busqueda() {
            var resultado = await _contexto.Inmuebles.Include(x => x.InmuebleFotos)
                                                    .Include(y => y.InmuebleDireccions)
                                                    .Include(z => z.InmueblePrecio).ToListAsync();

            return resultado;



        }
        public virtual Inmueble BusquedaPorId(int id) {
          
            var resultado =  _contexto.Inmuebles.Include(x => x.InmuebleFotos)
                                                .Include(x => x.InmuebleDireccions)
                                                .Include(x => x.InmueblePrecio)
                                                .ThenInclude(z => z.Monedaid)
                                                .Where(x => x.Id == id).FirstOrDefault();

            return resultado;
        }

        public virtual async Task<List<Inmueble>> BusquedaPorDestacado(bool destacado) {


            var resultado = await _contexto.Inmuebles.Include(x => x.InmuebleFotos)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x => x.Destacado == destacado).ToListAsync();

            return resultado;

        }
        public virtual bool Agregar(Inmueble Inmueble, List<InmuebleFoto> foto, InmueblePrecio precio, InmuebleDireccion direccion) {

            try
            {
                _contexto.Add(Inmueble);
                _contexto.Add(precio);
                _contexto.Add(direccion);

                foreach (InmuebleFoto foto1 in foto)
                {
                    _contexto.Add(foto1);
                    _contexto.SaveChanges();
                }

                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public virtual bool Editar(Inmueble Inmueble, List<InmuebleFoto> fotos, InmueblePrecio precio, InmuebleDireccion direccion, int id) {

            try
            {
                var editandoInmuebles =  _contexto.Inmuebles.Where(x => x.Id == id).FirstOrDefault();

                editandoInmuebles.Titulo = Inmueble.Titulo;
                editandoInmuebles.Descripcion = Inmueble.Descripcion;
                editandoInmuebles.Area = Inmueble.Area;
                editandoInmuebles.Destacado = Inmueble.Destacado;


                var editandoPrecio =  _contexto.InmueblePrecios.Where(x => x.Id == id).FirstOrDefault();

                editandoPrecio.Monedaid = precio.Monedaid;
                editandoPrecio.NotaPrecio = precio.NotaPrecio;

                var editandoDireccion = _contexto.InmuebleDireccions.Where(x => x.Inmuebleid == id).FirstOrDefault();

                editandoDireccion.Direccion = direccion.Direccion;

                List<InmuebleFoto> editandoFoto = _contexto.InmuebleFotos.Where(x => x.Inmuebleid == id).ToList();

                editandoFoto = fotos;
                _contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public virtual bool Eliminar(int id)
        {
            var resultado =  _contexto.Inmuebles.Include(x => x.InmuebleFotos).Include(x => x.InmuebleDireccions).Include(x => x.InmueblePrecio).Where(x => x.Id == id).FirstOrDefault();

            _contexto.Remove(resultado);
            _contexto.SaveChanges();

            return true;
        }
    }
}
