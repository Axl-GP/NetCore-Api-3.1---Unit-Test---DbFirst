using MiBahia_Estate.Models.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Houses
{
    public class HouseDTO: PropertyDTO
    {
        public int? Bathrooms { get; set; }
        public int? Rooms { get; set; }
        public bool? ServiceRoom { get; set; }
        public bool? Gym { get; set; }
        public bool? WashingArea { get; set; }
    }
}
