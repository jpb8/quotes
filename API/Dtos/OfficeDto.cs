using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class OfficeDto
    {
        [Required]
        public string Name { get; set; }
        public List<string> Users { get; set; }
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
