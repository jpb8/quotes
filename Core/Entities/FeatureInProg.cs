using System.Collections.Generic;

namespace Core.Entities
{
    public class FeatureInProg
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string MileStone { get; set; }
        public List<UserStoryInProg> UserStories { get; set; } = new List<UserStoryInProg>();
    }
}