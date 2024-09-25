public class Dipendente : Persona
{
    public int Id { get; set; }
    public Mansione Mansione { get; set; }  // connette Dipendente a Mansione
    public string Mail { get; set; }
    public Statistiche Statistiche { get; set; } // connette Dipendente a Statistiche

    public Dipendente(int id,string nome, string cognome, string dataDiNascita, string mail, Mansione mansione, Statistiche statistiche = null)
        : base(nome, cognome, dataDiNascita) // Fa riferimento alla proprietà 'DataDiNascita' della classe base 'Persona'
    {
        this.Id =id;
        this.Mansione = mansione;
        this.Mail = mail;
        this.Statistiche = statistiche ?? new Statistiche(0, 0); // Imposta le statistiche
    }

    // Stipendio derivato dalla mansione
    public double Stipendio => Mansione.Stipendio;

    // Metodo ToString per visualizzare i dettagli del dipendente
    public override string ToString()
    {
        return $"ID:{Id},Nome: {Nome}, Cognome: {Cognome}, Data di Nascita: {DataDiNascita}, Mail: {Mail}, Mansione: {Mansione.Titolo}, Stipendio: {Stipendio}, Fatturato: {Statistiche.Fatturato}, Presenze: {Statistiche.Presenze}";
    }
}
