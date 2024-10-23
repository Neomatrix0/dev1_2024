using Microsoft.AspNetCore.Identity;


public class AppUser : IdentityUser
{
    // Aggiungi le tue proprietà personalizzate, se necessario
   /*public string Nome { get; set; }*/
    public string Codice { get; set; }
}
