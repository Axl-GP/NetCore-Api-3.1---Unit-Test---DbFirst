using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class SolarDireccion
    {
        public int Id { get; set; }
        public int? IdSolar { get; set; }
        public string Direccion { get; set; }

        public virtual Solar IdNavigation { get; set; }
    }
}
