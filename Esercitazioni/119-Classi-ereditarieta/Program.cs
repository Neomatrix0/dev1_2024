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

class Studente: Persona{   // definizione di una classe Studente che erdita dalla classe Persona
    public string corso;
    public Studente(string nome,string cognome,int eta,string corso) : base(nome,cognome,eta){   //costruttore con parametri chiama costruttore della classe base
    this.corso = corso;  // inizializzazione del campo corso della classe studente

    }


    public void StampaCorso(){
        Console.WriteLine($"Corso: {corso}");
    }
}

class Program{
    static void Main(string[] args){
        Studente s = new Studente("Mario","Rossi",30,"informatica"); //creazione di un oggetto di tipo Studente tramite costruttore
        s.Stampa();  // chiamata al metodo Stampa dell'oggetto s
        s.StampaCorso();  // chiamata al metodo Stampacorso dell'oggetto s

        // Stampa e stampacorso stamperà 
        //Nome: Mario Cognome: Rossi Età:30 Corso: informatica
    }
}