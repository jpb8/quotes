using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Discovery { get; set; }
        public decimal Design { get; set; }
        public decimal Test { get; set; }

    }
}
