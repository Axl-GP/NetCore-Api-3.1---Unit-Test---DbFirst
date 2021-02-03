using MiBahia_Estate.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.BuildingSites
{
    public class BuildingSiteDTO:PropertyDTO
    {
        public decimal PricePerMeter { get; set; }
    }
}
