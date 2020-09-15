using System.Collections.Generic;

namespace Core.Entities
{
    public class FeatureInProg
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string MileStone { get; set; }
        public decimal DiscoveryTotal { get; set; }
        public decimal DesignTotal { get; set; }
        public decimal ImplementationTotal { get; set; }
        public decimal TestTotal { get; set; }
        public List<UserStoryInProg> UserStories { get; set; } = new List<UserStoryInProg>();
    }
}