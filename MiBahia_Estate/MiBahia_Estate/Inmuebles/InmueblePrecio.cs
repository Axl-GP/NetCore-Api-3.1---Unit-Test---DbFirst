using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate
{
    public partial class InmueblePrecio
    {
        public int Id { get; set; }
        public int Monedaid { get; set; }
        public int Precio { get; set; }
        public string NotaPrecio { get; set; }

        public virtual Inmueble IdNavigation { get; set; }
    }
}
