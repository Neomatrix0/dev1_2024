class Persona{
    public string nome;
    public string cognome;
    public int eta;

    public Persona(string nome, string cognome, int eta) {      //i campi vengono inizializzati tramite il costruttore con i parametri
    // questo passaggio è necessario  per inizializzare i campi dell'oggetto con valori specifici perchè altrimenti i campi non verrebbero inizializzati
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
        }

        public void Stampa(){   // definizione di un metodo pubblico cioè accessibile dall'esterno
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Cognome: {cognome}");
            Console.WriteLine($"Età: {eta}");
        }
}
