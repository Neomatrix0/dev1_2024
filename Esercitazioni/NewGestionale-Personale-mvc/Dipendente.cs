// classe Dipendente estende Persona quindi ne prende i campi ovvero i dati anagrafici
public class Dipendente : Persona
{
    public int Id { get; set; }
    public Mansione Mansione { get; set; }  // connette Dipendente a Mansione
    public string Mail { get; set; }
    public Statistiche Statistiche { get; set; } // connette Dipendente a Statistiche

// costruttore 
    public Dipendente(int id,string nome, string cognome, string dataDiNascita, string mail, Mansione mansione, Statistiche statistiche = null)
        : base(nome, cognome, dataDiNascita) // Fa riferimento alla proprietà 'DataDiNascita' della classe base 'Persona'
                                            // Chiamata al costruttore della classe base Persona per impostare i dati anagrafici
    {
        this.Id =id;
        this.Mansione = mansione;
        this.Mail = mail;
        this.Statistiche = statistiche ?? new Statistiche(0, 0);  // Se vengono fornite le statistiche, le assegna altrimenti crea nuove statistiche con valori di default (0)
    }

    //  Proprietà che  restituisce lo stipendio del dipendente preso da Mansione
    // serve a ottenere il valore dello stipendio dalla  mansione senza dover accedere direttamente a dipendente.Mansione.Stipendio. ma sarà dipendente.Stipendio
    public double Stipendio => Mansione.Stipendio;

     // Metodo ToString per restituire una rappresentazione leggibile del dipendente
    public override string ToString()
    {
        return $"ID:{Id},Nome: {Nome}, Cognome: {Cognome}, Data di Nascita: {DataDiNascita}, Mail: {Mail}, Mansione: {Mansione.Titolo}, Stipendio: {Stipendio}, Fatturato: {Statistiche.Fatturato}, Presenze: {Statistiche.Presenze}";
    }
}
