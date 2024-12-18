     
     public class Dipendente : Persona{
     public string Mansione{get;set;}

     public string Mail{get;set;}

     public double Stipendio{get;set;}
      public Statistiche Statistiche { get; set; }

public Dipendente(string nome,string cognome,string dataNascita,string mansione,string mail,double stipendio, Statistiche statistiche): base (nome,cognome,dataNascita)
{
    
    this.Mansione = mansione;
    this.Mail = mail;
    this.Stipendio = stipendio;
    this.Statistiche = statistiche;
}
  public override string ToString()
    {
        return $"Nome: {Nome}, Cognome: {Cognome}, Data di nascita: {DataNascita}, Mansione: {Mansione}, Mail: {Mail}, Stipendio: {Stipendio}, Performance: {Statistiche.Performance}, Assenze: {Statistiche.Assenze}";
    }

}

