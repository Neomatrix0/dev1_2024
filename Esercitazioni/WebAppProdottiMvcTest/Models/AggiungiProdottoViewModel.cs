public class AggiungiProdottoViewModel
{
    public Prodotto Prodotto { get; set; } // Oggetto prodotto che verrà aggiunto
    public List<string> Categorie { get; set; } // Lista delle categorie da selezionare nel form

    public string Codice { get; set; } // Campo aggiuntivo per eventuale codice di sicurezza
}
