using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.CoinType
{
    public class CoinTypeITO
    {
        [Required]
        public string Type { get; set; }
    }
}
