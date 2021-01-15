using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate.Propiedades
{
    public partial class Propiedad : Inmueble
    {
        public int? Ducha { get; set; }
        public int? Cuartos { get; set; }
        public bool? CuartoServicio { get; set; }
        public bool? AreaGym { get; set; }
        public bool? AreaLavado { get; set; }
        public bool? Caliente { get; set; }

        public virtual Inmueble IdNavigation { get; set; }
    }
}
