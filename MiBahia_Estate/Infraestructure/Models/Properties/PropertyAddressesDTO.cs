using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyAddressesDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Address { get; set; }
    }
}
