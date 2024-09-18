public class Persona{
    public string Nome{ get; set; }
    public string Cognome{ get; set; }
    public int Eta{ get; set; }
}

// classe Studente che eredita da persona

public class Studente : Persona{
    public string Matricola{ get; set; }
    public string CorsoDiStudi{ get; set; }

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

          //chiudere la console

          Console.ReadKey();
    }
}