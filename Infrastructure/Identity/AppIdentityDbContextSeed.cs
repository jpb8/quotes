using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "jpb8",
                    Email = "joseph.ballard@tiga.us",
                    UserName = "joseph.ballard@tiga.us",
                    Office = new Office
                    {
                        Name = "Main Houston",
                        City = "Spring",
                        Street = "25700 I-45 North Suite 480",
                        State = "Tesas",
                        Zipcode = "77386"
                    }
                };

                await userManager.CreateAsync(user, "P4$$w0rd");
            };
        }
    }
}
