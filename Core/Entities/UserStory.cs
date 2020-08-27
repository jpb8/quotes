using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UserStory : BaseEntity
    {
        public string Description { get; set; }
        public string Devision { get; set; }
        public string ServiceDiscipline { get; set; }
        public decimal Discovery { get; set; }
        public decimal Design { get; set; }
        public decimal Implementation { get; set; }
        public decimal Test { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }
        public Feature Feature { get; set; }
        public int FeatureId { get; set; }
    }
}
