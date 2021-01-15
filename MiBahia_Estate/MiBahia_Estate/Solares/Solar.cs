using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate.Solares
{
    public partial class Solar:Inmueble
    {
        public decimal? PrecioMetro { get; set; }

        public virtual Inmueble IdNavigation { get; set; }
    }
}
