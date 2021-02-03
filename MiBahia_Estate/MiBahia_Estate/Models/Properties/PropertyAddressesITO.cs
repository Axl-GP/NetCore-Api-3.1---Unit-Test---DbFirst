using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyAddressesITO
    {
        [Required]
        public int PropertyId { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
