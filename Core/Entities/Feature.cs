using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Feature : BaseEntity
    {
        public string Description { get; set; }
        public decimal Discovery { get; set; }
        public decimal Design { get; set; }
        public decimal Test { get; set; }
        public string Devision { get; set; }
        public string MileStone { get; set; }
        public bool InScope { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
