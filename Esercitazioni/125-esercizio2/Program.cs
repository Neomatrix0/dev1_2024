using Newtonsoft.Json;

// Definizione di una classe per mappare i dati JSON
public class Persona{

public string Nome { get; set;}
    public int Eta { get; set;}
    public bool Impiegato{ get; set;}
    

}

public class GestioneJson{
    public static void Main(string[] args){
// creazione di un oggetto persona
        Persona persona = new Persona(){
            Nome = "Mario Rossi",
            Eta = 30,
            Impiegato = true
        };

        // serializzazione dell'oggetto in una stringa json

        string json = JsonConvert.SerializeObject(persona,Formatting.Indented); //Formatting.Indented per formattare il JSON
        File.WriteAllText(@"persona.json",json);

        // Deserializzazione della stringa JSON in un oggetto Persona

        string jsonDaLeggere = File.ReadAllText(@"persona.json");
        Persona personaDeserializzata = JsonConvert.DeserializeObject<Persona> (jsonDaLeggere);

        System.Console.WriteLine(personaDeserializzata.Nome);
    }
}