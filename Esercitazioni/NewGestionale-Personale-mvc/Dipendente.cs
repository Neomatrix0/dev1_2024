     
     public class Dipendente : Persona{
         public int Id { get; set; }
     public Mansione Mansione{get;set;}  // connette Dipendente a Mnasione

     public string Mail{get;set;}

    
      public Statistiche Statistiche { get; set; } // connette le due classi Dipendente Statistiche

public Dipendente(string nome,string cognome,string dataNascita,string mail,Mansione mansione, Statistiche statistiche = null): base (nome,cognome,dataNascita)
{
    
    this.Mansione = mansione;
    this.Mail = mail;
   // this.Statistiche = statistiche; 
     this.Statistiche = statistiche ?? new Statistiche(0, 0); //assegna le statistiche al dipendente sono pzionali e non obbligatorie
}

// Stipendio derivato dalla mansione
    public double Stipendio => Mansione.Stipendio;
 
  // Metodo ToString per visualizzare i dettagli del dipendente
    public override string ToString()
    {
        return $"Nome: {Nome}, Cognome: {Cognome}, Data di Nascita: {DataNascita}, Mail: {Mail}, Mansione: {Mansione.Titolo}, Stipendio: {Stipendio}, Performance: {Statistiche.Fatturato}, Assenze: {Statistiche.Presenze}";
    }

}

