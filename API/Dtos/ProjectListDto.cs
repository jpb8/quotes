using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProjectListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TigaId { get; set; }
        public int Features { get; set; }
    }
}
