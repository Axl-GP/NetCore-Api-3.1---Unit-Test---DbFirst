using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MiBahia_Estate;
using MiBahia_Estate.Helpers;
using MiBahia_Estate.Solares;

#nullable disable

namespace MiBahia_Estate
{
    public class Property
    {
        public Property()
        {
            PropertyAddresses = new HashSet<PropertyAddresses>();
            PropertyPhotos = new HashSet<PropertyPhotos>();
        }

        public int Id { get; set; }
        public int PropertyTypeId { get; set; }
        [Required]
        [StringLength(80, ErrorMessage ="El titulo es demasiado largo.")]
        [FirstUpperCase]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal? Area { get; set; }
        public bool? Outstanding { get; set; }

        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertyPrice PropertyPrice { get; set; }
        public virtual House House { get; set; }
        public virtual BuildingSite BuildingSite { get; set; }
        public virtual ICollection<PropertyAddresses> PropertyAddresses { get; set; }
        public virtual ICollection<PropertyPhotos> PropertyPhotos { get; set; }
    }
}
