using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate
{
    public partial class PropertyAddresses
    {
        public int Id { get; set; }
        public int? PropertyId { get; set; }
        public string Address { get; set; }

        public virtual Property Property { get; set; }
    }
}
