

    // puoi definire costruttori per inizializzare le proprietà al momento della creazione dell'oggetto

    public class Studente :Persona
    {

    public string Matricola{ get;set; }
    public string CorsoDiStudi{get;set; }

    //costruttore
    public Studente(string nome,string cognome,int eta,string matricola,string corsoDiStudi){
    Nome = nome;
    Cognome = cognome;
    Eta = eta;
    Matricola = matricola;
    CorsoDiStudi = corsoDiStudi;
    }
    }

    