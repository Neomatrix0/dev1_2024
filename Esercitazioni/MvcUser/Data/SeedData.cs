using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcUser.Data;


public class SeedData
{
    public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        string[] roleNames = { "Admin", "Fornitore", "Cliente" };

        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName)); // Corretto da .rolemanager a roleManager
            }
        }

        if (await userManager.FindByEmailAsync("admin@admin.com") == null)
        {
            var adminUser = new AppUser
            {
                UserName = "admin@admin.com",
                Codice = "12345678",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, "AdminPass1!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
        else
        {
            var adminUser = await userManager.FindByEmailAsync("admin@admin.com");
            await userManager.AddToRoleAsync(adminUser, "Admin"); // Mancava il punto e virgola
        }
    }
}
