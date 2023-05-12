using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.API.DTOs
{
    public class MovieWithTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public string Type { get; set; }
        public int TypeId { get; set; }
    }
}
