using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using _128_Identity_webapp.Data;
//using MvaAuthApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Aggiunge supporto per i ruoli
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<ProdottiService>(); 

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Aggiungo ambito di servizio per la gestione dei ruoli
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Risolvi il RoleManager dal provider di servizi
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        // Chiamata al metodo per assicurare che i ruoli esistano
        await ApplicationDbInitializer.EnsureRolesAsync(roleManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Errore avvenuto durante la creazione dei ruoli");
    }
}

//Aggiungi script di seed

using(var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedAdminUser(userManager, roleManager);
}

//definizone metodo

async Task SeedAdminUser(UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager){
    if(!await roleManager.RoleExistsAsync("Admin")){
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // crea l'utente admin se esiste

       if(await userManager.FindByEmailAsync("info2@admin.com")== null){
        var user = new IdentityUser{
            UserName = "info2@admin.com",
            Email = "info2@admin.com",
            EmailConfirmed = true,
        };
        var result = await userManager.CreateAsync(user,"Admin123!"); //imposta password utente Admin
        if(result.Succeeded){
            await userManager.AddToRoleAsync(user,"Admin"); //aggiungi l'utente admin al ruolo Admin
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseStatusCodePagesWithReExecute("/Home/Error");
 //app.UseHsts();
 // Aggiungi l'autenticazione qui



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

public static class ApplicationDbInitializer
{
    public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        var roles = new List<string> { "Admin", "User" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role)); // Corretto typo qui
            }
        }
    }
}
