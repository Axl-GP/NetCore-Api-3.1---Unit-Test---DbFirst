using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate
{
    public partial class TipoInmueble
    {
        public TipoInmueble()
        {
            Inmuebles = new HashSet<Inmueble>();
        }

        public bool Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Inmueble> Inmuebles { get; set; }
    }
}
