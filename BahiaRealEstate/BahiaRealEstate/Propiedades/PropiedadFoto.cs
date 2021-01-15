using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class PropiedadFoto
    {
        public int Id { get; set; }
        public int? Propiedadid { get; set; }
        public string Foto { get; set; }

        public virtual Propiedad Propiedad { get; set; }
    }
}
