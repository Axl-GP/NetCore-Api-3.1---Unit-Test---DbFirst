using System;
using System.Collections.Generic;

#nullable disable

namespace MiBahia_Estate
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            Properties = new HashSet<Property>();
        }

        public bool Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
