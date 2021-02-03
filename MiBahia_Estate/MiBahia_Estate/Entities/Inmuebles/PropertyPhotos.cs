using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MiBahia_Estate
{
    public partial class PropertyPhotos
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string PhotoPath { get; set; }

        [NotMapped]
        public IFormFile PhotoFile { get; set; }

        public virtual Property Property { get; set; }
    }
}
