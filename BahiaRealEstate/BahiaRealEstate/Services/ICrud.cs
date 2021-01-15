using BahiaRealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BahiaRealEstate.Services
{
    public abstract class ICrud
    {

        public abstract Task<List<Solar>> Busqueda()
        {

        }
        public abstract Solar BusquedaPorId(int id);
        public abstract Task<List<Solar>> BusquedaPorDestacado();
        public abstract bool Agregar(Inmueble inmueble);
        public abstract bool Editar(Inmueble inmueble);
        public abstract bool Eliminar(int id);
    }
}
