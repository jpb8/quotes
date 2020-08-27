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
        public string MileStone { get; set; }
        public string Project { get; set; }
        public int ProjectId { get; set; }
    }
}
