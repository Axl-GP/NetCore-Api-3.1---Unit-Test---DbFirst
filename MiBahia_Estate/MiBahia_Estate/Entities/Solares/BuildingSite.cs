using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate.Solares
{
    public partial class BuildingSite:Property
    {
        public decimal PricePerMeter { get; set; }

        public virtual Property IdNavigation { get; set; }
    }
}
