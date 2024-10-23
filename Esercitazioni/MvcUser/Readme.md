# MvcUser

dotnet new mvc --auth Individual -o MvcUser

Installo Idnetity che serve a creare le pagine per la registrazione e il login

dotnet add package Microsoft.AspNetCore.Identity.UI

# Creazione di un utente che estende IdentityUser

Nella cartella Models creo un nuovo file chiamato AppUser.cs e definisco il modello come segue:

 ```csharp

public class AppUser : IdentityUser{
    public string Codice{get;set;}
}

 ```

 Nella cartella Data, aggiorno ApplicationDbContext per utilizzare il modello utente estero invece di IdentityUser

 ```csharp

//aggiungo <AppUser>
 public class ApplicationDbContext : IdentityDbContext<AppUser>

 ```

  ```bash
# migrazione ed aggiornamento database

dotnet ef migrations add InitialCreate
dotnet ef database update


 ```

 # modifiche al Program.cs




 # creo file SeedData.cs in cartella data

```csharp
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
                Email = "admin@admin.com",
                Nome = "Admin",
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

 ```