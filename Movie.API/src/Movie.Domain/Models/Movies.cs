using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Movie.Domain.Models.Lookups;

namespace Movie.Domain.Models
{
    public class Movies : BaseEntity
    {
        public string Name { get; set; }
        public int Rating { get; set; } 
        public TypeLookup Type { get; set; }
        public int TypeId { get; set; }
    }
}
