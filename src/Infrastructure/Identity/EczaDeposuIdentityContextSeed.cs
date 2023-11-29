using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class EczaDeposuIdentityContextSeed
    {
        public static async Task SeedAsync(EczaDeposuIdentityContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await db.Database.MigrateAsync(); // otomatik migrasyon

            if (await userManager.Users.AnyAsync() || await roleManager.Roles.AnyAsync())
                return;


            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.PHARMACIST));
            var pharmacist = new ApplicationUser()
            {
                UserName = AuthorizationConstant.DEFAULT_PHARMA_USER,
                Email = AuthorizationConstant.DEFAULT_PHARMA_USER,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(pharmacist, AuthorizationConstant.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(pharmacist, AuthorizationConstant.Roles.PHARMACIST);


            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.ADMIN));
            var admin = new ApplicationUser()
            {
                UserName = AuthorizationConstant.DEFAULT_ADMIN_USER,
                Email = AuthorizationConstant.DEFAULT_ADMIN_USER,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(admin, AuthorizationConstant.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(admin, AuthorizationConstant.Roles.ADMIN);
        }
    }
}
