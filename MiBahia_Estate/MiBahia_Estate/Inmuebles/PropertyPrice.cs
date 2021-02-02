using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MiBahia_Estate
{
    public partial class PropertyPrice
    {
        public int Id { get; set; }
        [Required]
        public int CoinId { get; set; }
        [Required]
        public int Price { get; set; }
        public string PriceNotes { get; set; }

        public virtual Property IdNavigation { get; set; }
    }
}
