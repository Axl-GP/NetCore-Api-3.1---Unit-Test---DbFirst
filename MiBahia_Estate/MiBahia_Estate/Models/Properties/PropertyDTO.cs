using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Area { get; set; }
        public bool? Outstanding { get; set; }
    }
}
