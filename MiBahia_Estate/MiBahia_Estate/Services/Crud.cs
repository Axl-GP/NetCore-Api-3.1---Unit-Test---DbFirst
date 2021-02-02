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
        private readonly CargarFotos _cargar;

        public Crud(bahia_estateContext contexto,CargarFotos cargar)
        {
            _contexto = contexto;
            this._cargar = cargar;
        }
        public virtual async Task<List<Property>> Busqueda() {
            var resultado = await _contexto.Inmuebles.Include(x => x.InmuebleFotos)
                                                    .Include(y => y.InmuebleDireccions)
                                                    .Include(z => z.InmueblePrecio).ToListAsync();

            return resultado;



        }
        public virtual Property BusquedaPorId(int id) {
          
            var resultado =  _contexto.Inmuebles.Include(x => x.InmuebleFotos)
                                                .Include(x => x.InmuebleDireccions)
                                                .Include(x => x.InmueblePrecio)
                                                .ThenInclude(z => z.Monedaid)
                                                .Where(x => x.Id == id).FirstOrDefault();

            return resultado;
        }

        public virtual async Task<List<Property>> BusquedaPorDestacado(bool destacado) {


            var resultado = await _contexto.Inmuebles.Include(x => x.InmuebleFotos)
                                                     .Include(x => x.InmuebleDireccions)
                                                     .Include(x => x.InmueblePrecio)
                                                     .Where(x => x.Destacado == destacado).ToListAsync();

            return resultado;

        }
        public virtual async Task<bool> Agregar(Property Inmueble, List<PropertyPhotos> foto, PropertyPrice precio, PropertyAddresses direccion) {

            try
            {
                _contexto.Add(Inmueble);
                _contexto.Add(precio);
                _contexto.Add(direccion);

                foreach (PropertyPhotos foto1 in foto)
                {
                    foto1.Foto = await _cargar.GuardarImagen(foto1.FotoArchivo);
                    _contexto.InmuebleFotos.Add(foto1);
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

        public virtual bool Editar(Property Inmueble, List<PropertyPhotos> fotos, PropertyPrice precio, PropertyAddresses direccion, int id) {

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

                List<PropertyPhotos> editandoFoto = _contexto.InmuebleFotos.Where(x => x.Inmuebleid == id).ToList();

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
