using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using  Newtonsoft.Json;


    public class AggiungiProdottoModel : PageModel
    {
        private readonly ILogger<AggiungiProdottoModel> _logger;

        public AggiungiProdotto(ILogger<AggiungiProdottoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost(){}
    }
