public class Persona{
    public string Nome{get;set;}
    public string Cognome{get;set;}
    public string DataNascita{get;set;}

    public Persona(string nome,string cognome,string dataNascita){
        this.Nome = nome;
        this.Cognome = cognome;
        this.DataNascita = dataNascita;
    }
}