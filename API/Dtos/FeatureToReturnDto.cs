using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class FeatureToReturnDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Discovery { get; set; }
        public decimal Design { get; set; }
        public decimal Test { get; set; }
        public string Devision { get; set; }
        public string MileStone { get; set; }
        public bool InScope { get; set; }
        public string ResourceType { get; set; }
        public string Project { get; set; }
        public int ProjectId { get; set; }
    }
}
