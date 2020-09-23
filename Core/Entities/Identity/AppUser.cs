using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Office Office { get; set; }
        public int OfficeId { get; set; }
    }
}
