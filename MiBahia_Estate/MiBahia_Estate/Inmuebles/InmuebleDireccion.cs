using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate
{
    public partial class InmuebleDireccion
    {
        public int Id { get; set; }
        public int? Inmuebleid { get; set; }
        public string Direccion { get; set; }

        public virtual Inmueble Inmueble { get; set; }
    }
}
