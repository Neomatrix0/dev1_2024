public class Persona{
    public string Nome{ get; set; }
    public string Cognome{ get; set; }
    public int Eta{ get; set; }
}

class Program{
    public static void Main(string[] args){
        Persona persona = new Persona{
            Nome="Mario",
            Cognome="Rossi",
            Eta = 30
        };

        Console.WriteLine($"Nome: {persona.Nome}");
         Console.WriteLine($"Cognome: {persona.Cognome}");
          Console.WriteLine($"Eta: {persona.Eta}");

          //chiudere la console

          Console.ReadKey();
    }
}



