     
     public class Dipendente : Persona{
     public string Mansione{get;set;}

     public string Mail{get;set;}

     public double Stipendio{get;set;}

public Dipendente(string nome,string cognome,string dataNascita,string mansione,string mail,double stipendio): base (nome,cognome,dataNascita)
{
    
    this.Mansione = mansione;
    this.Mail = mail;
    this.Stipendio = stipendio;
}

}
