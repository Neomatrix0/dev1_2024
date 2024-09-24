public class Persona{
    public string Nome{get;set;}
    public string Cognome{get;set;}
    public string DataDiNascita{get;set;}

    public Persona(string nome,string cognome,string dataDiNascita){
        this.Nome = nome;
        this.Cognome = cognome;
        this.DataDiNascita = dataDiNascita;
    }
}