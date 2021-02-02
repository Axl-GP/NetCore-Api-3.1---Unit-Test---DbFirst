using System;
using System.Collections.Generic;
using MiBahia_Estate;

#nullable disable

namespace MiBahia_Estate
{
    public partial class House : Property
    {
        public int? Bathrooms { get; set; }
        public int? Rooms { get; set; }
        public bool? ServiceRoom { get; set; }
        public bool? Gym { get; set; }
        public bool? WashingArea { get; set; }
        
        public virtual Property IdNavigation { get; set; }
    }
}
