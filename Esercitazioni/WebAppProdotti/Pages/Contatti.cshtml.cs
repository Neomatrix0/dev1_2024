using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppProdotti.Pages
{
    public class Contatti : PageModel
    {
        private readonly ILogger<Contatti> _logger;

        public Contatti(ILogger<Contatti> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}