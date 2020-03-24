
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DataInitializer
    {
        public static async Task SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, helloEntrantContex context)
        {
            await SeedRoles(roleManager);
            await SeedAdmin(userManager, context);
            
        }

        

        public static async Task SeedAdmin(UserManager<User> userManager, helloEntrantContex context)
        {
            string email = "superadmin@gmail.com";
            string pass = "12345";

            if (await userManager.FindByEmailAsync(email) == null)
            {
                User user = new User();
                user.Email = email;
                user.UserName = email;

                IdentityResult result = await userManager.CreateAsync(user, pass);
                if (result.Succeeded)
                {
                   
                    await userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }

        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "User", "Administrator", "SuperAdmin" };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (roleExist == false)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}