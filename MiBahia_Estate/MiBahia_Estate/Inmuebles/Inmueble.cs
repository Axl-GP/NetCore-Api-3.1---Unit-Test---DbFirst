using System;
using System.Collections.Generic;

using MiBahia_Estate.Propiedades;
using MiBahia_Estate.Solares;

#nullable disable

namespace MiBahia_Estate
{
    public abstract class Inmueble
    {
        public Inmueble()
        {
            InmuebleDireccions = new HashSet<InmuebleDireccion>();
            InmuebleFotos = new HashSet<InmuebleFoto>();
        }

        public int Id { get; set; }
        public bool TipoInmuebleId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal? Area { get; set; }
        public bool? Destacado { get; set; }

        public virtual TipoInmueble TipoInmueble { get; set; }
        public virtual InmueblePrecio InmueblePrecio { get; set; }
        public virtual Propiedad Propiedad { get; set; }
        public virtual Solar Solar { get; set; }
        public virtual ICollection<InmuebleDireccion> InmuebleDireccions { get; set; }
        public virtual ICollection<InmuebleFoto> InmuebleFotos { get; set; }
    }
}
