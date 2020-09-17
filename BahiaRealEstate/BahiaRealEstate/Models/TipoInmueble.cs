using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class TipoInmueble
    {
        public TipoInmueble()
        {
            Propiedad = new HashSet<Propiedad>();
            Solar = new HashSet<Solar>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Propiedad> Propiedad { get; set; }
        public virtual ICollection<Solar> Solar { get; set; }
    }
}
