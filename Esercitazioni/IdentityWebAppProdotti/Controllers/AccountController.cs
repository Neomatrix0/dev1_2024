/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

//namespace MvcApp.Controllers
//{

    private readonly UserManager<IdentityUser> _userManager;
    public class AccountController(UserManager<IdentityUser> _userManager)
    {
       
       _userManager = _userManager;
    }

    //GET /Account/AddToRole
        public async Task<IActionResult> AddToRoleAdmin()
        {
            var user = await _userManager.FindByNameAsync(user.Identity.Name); // serve a trovare utente attuale
            await _userManager.AddToRoleAsync(user,"Admin");
            return RedirectRoAction("Index", "Home");
            
        }

         public async Task<IActionResult> GetRole()
        {
            var user = await _userManager.FindByNameAsync(user.Identity.Name);
            var roles = await _userManager.GetRolesAsync(user);
            return Content(string.Join(", ",roles)); // stampa ruolo utnete
            
        }
*/

    
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

//namespace MvcApp.Controllers
//{

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;

    // Costruttore corretto
    public AccountController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    // GET /Account/AddToRole
    public async Task<IActionResult> AddToRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name); // Trova l'utente attuale
        await _userManager.AddToRoleAsync(user, "Admin");
        return RedirectToAction("Index", "Home"); // Corretto RedirectRoAction in RedirectToAction
    }

    // GET /Account/GetRole
    public async Task<IActionResult> GetRole()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var roles = await _userManager.GetRolesAsync(user);
        return Content(string.Join(", ", roles)); // Stampa il ruolo dell'utente
    }

    //GET: /Account/RemoveFromRole

      public async Task<IActionResult> RemoveFromRoleAdmin()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
         await _userManager.RemoveFromRoleAsync(user,"Admin");
        return RedirectToAction("Index", "Home");
    }

       public async Task<IActionResult> AddToRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
         await _userManager.AddToRoleAsync(user,"User");
        return RedirectToAction("Index", "Home");
    }

        public async Task<IActionResult> RemoveFromRoleUser()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
         await _userManager.RemoveFromRoleAsync(user,"User");
        return RedirectToAction("Index", "Home");
    }
}
//}
