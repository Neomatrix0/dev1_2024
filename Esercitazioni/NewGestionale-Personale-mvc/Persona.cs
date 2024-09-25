// classe gneerica Persona con dati anagrafici come proprietà
// verrà estesa dalla classe Dipendente per sfruttare i campi relativi all'anagrafica
public class Persona{
    public string Nome{get;set;}
    public string Cognome{get;set;}
    public string DataDiNascita{get;set;}

// costruttore Persona 
    public Persona(string nome,string cognome,string dataDiNascita){
        this.Nome = nome;
        this.Cognome = cognome;
        this.DataDiNascita = dataDiNascita;
    }
}