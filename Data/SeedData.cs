using GolfHandicap.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicap.Data
{
    public static class SeedData
    {
        public static async Task Initialize(RoundDbContext context,
                                        UserManager<IdentityUser> userManager,
                                        RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            string memberId = "";
            string adminId = "";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(Constants.AdministratorsRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorsRole));
            }
            if (await roleManager.FindByNameAsync(Constants.MembersRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(Constants.MembersRole));
            }

            if (await userManager.FindByNameAsync("member@round.com") == null)
            {
                var user = new IdentityUser("member@round.com");
                user.EmailConfirmed = true;

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, Constants.MembersRole);
                }
                memberId = user.Id;
            }

            if (await userManager.FindByNameAsync("admin@round.com") == null)
            {
                var user = new IdentityUser("admin@round.com");
                user.EmailConfirmed = true;

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, Constants.AdministratorsRole);
                }
                adminId = user.Id;
            }
            
        }



    }
}
