using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Feature : BaseEntity
    {
        public string Description { get; set; }
        public string MileStone { get; set; }
        public List<UserStory> UserStories { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
