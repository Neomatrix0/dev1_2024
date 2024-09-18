public class Persona{
    
    public string Nome{ get; set; }
    public string Cognome{ get; set; }
    public int Eta{ get; set; }

    // meotod virtuale nella classe base sovrascrivibile
    public virtual void Saluta(){
        Console.WriteLine("Ciao, sono una persona.");
    }
}

public class Studente : Persona{

     public string Matricola{ get; set; }
    public string CorsoDiStudi{ get; set; }

    // override del metodo Saluta
    public override void Saluta()
    {
        Console.WriteLine("Ciao, sono uno studente.");
    }
}


class Program{
    public static void Main(string[] args){

        // creazione di un' istanza della classe Studente
       Studente studente = new Studente{
            Nome="Luca",
            Cognome="Bianchi",
            Eta = 22,
            Matricola = "123456",
            CorsoDiStudi = "Ingegneria Informatica"
        };

        // utilizzo delle proprietà della classe Studente

        Console.WriteLine($"Nome: {studente.Nome}");
         Console.WriteLine($"Cognome: {studente.Cognome}");
          Console.WriteLine($"Eta: {studente.Eta}");
          Console.WriteLine($"Matricola: {studente.Matricola}");
          Console.WriteLine($"Corso di studi: {studente.CorsoDiStudi}");
          studente.Saluta();

          //chiudere la console

          Console.ReadKey();
    }}


    /*

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

    */