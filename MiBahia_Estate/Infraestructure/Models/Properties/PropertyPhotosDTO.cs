using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Models.Properties
{
    public class PropertyPhotosDTO
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }

        [Required]
        public string PhotoPath { get; set; }
        public IFormFile PhotoFile { get; set; }
    }
}
