using MiBahia_Estate.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.BuildingSites
{
    public class BuildingSiteITO : PropertyITO
    {
        public decimal PricePerMeter { get; set; }

        public ICollection<PropertyAddressesITO> Addresses {get;set;}
        public ICollection<PropertyPhotosITO>? Photos {get;set;}
        public PropertyPriceITO Price {get;set;}
    }
}
