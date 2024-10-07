public class AggiungiProdottoViewModel
{
    public Prodotto Prodotto { get; set; } // Oggetto prodotto che verrà aggiunto
    public List<string> Categorie { get; set; } // Lista delle categorie da selezionare nel form

    [Required(ErrorMessage = "Il Codice è obbligatorio.")]
    public string Codice { get; set; } // Campo per codice di sicurezza
}
