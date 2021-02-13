using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyPhotosITO
    {
        [Required]
        public int PropertyId { get; set; }

        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
