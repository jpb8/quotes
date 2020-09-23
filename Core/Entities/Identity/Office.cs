using System.Collections.Generic;

namespace Core.Entities.Identity
{
    public class Office : BaseEntity
    {
        public string Name { get; set; }
        public List<AppUser> Users { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}