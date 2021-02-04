using MiBahia_Estate.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyITO
    {
        
        public int PropertyTypeId { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "El titulo es demasiado largo.")]
        [FirstUpperCase]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal? Area { get; set; }
        public bool? Outstanding { get; set; }
    }
}
