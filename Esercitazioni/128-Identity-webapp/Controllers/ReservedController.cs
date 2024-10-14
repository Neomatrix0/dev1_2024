using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MvcApp.Controllers
{
    public class ReservedController : Controller
    {
        //GET: /Reserved/Index
        [Authorize] //richiede all'utente di essere autenticato
        public IActionResult Index()
        {
            return View(); // restituisce la view solo se l'utente è autenticato
        }

        [Authorize(Roles="Admin")] //GET: Reserved/Admin
        public IActionResult Admin()
        {
            return View(); // restituisce la view solo se l'utente è autenticato
        }

        [Authorize(Roles="User")] //GET: Reserved/Admin
        public IActionResult User()
        {
            return View(); // restituisce la view solo se l'utente è autenticato
        }
    }
}
