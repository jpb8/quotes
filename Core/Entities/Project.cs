using System.Collections.Generic;

namespace Core.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string TigaId { get; set; }
        public List<Feature> Features { get; set; }
    }
}