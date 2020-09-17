using System;
using System.Collections.Generic;

namespace BahiaRealEstate.Models
{
    public partial class SolarFoto
    {
        public int Id { get; set; }
        public int? Solarid { get; set; }
        public string Foto { get; set; }

        public virtual Solar Solar { get; set; }
    }
}
