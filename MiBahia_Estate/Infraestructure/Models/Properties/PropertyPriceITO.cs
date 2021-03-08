using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyPriceITO
    {
        public int Id { get; set; }
        [Required]
        public int CoinId { get; set; }
        [Required]
        public int Price { get; set; }

        public string PriceNotes { get; set; }
    }
}
