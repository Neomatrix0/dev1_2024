class Persona{
    private string nome;
    private string cognome;
    private int eta;

    public string Nome{}{
        get{return nome;}
        set{nome=value;}
    }

    public string Cognome{
        get{return cognome;}
        set{cognome=value;}
    } 

    public int Eta{
        get{ return eta;}
        set{eta=value;}
    }

    public Persona(string nome, string cognome,int eta){    //costruttore con parametri tra parentesi tonde ci sono i parametri
        this.nome=nome; //this si riferisce all'oggetto corrente(necessario per distinguere tra corpo e parametro)
        this.cognome=cognome;
        this.eta=eta;
    }

    public void Stampa(){                   // definizione di un metodo pubblico cioè accessibile dall'esterno
        Console.WriteLine($"Nome: {nome}");
         Console.WriteLine($"Cognome: {cognome}");
          Console.WriteLine($"Età: {eta}");
    }
}

class Program{
    static void Main(string[] args){
        Persona p = new Persona("Mario", "Rossi", 30); // creazione di un oggetto di tipo Persona tramite il costruttore 
        p.Stampa();
        p.Nome ="Luigi";  //scrittura del campo nome tramite la proprietà Nome
        p.Stampa(); // chiamata al metodo Stampa dell'oggetto p

        //stamperà nome: Luigi cognome: Rossi età: 30

    }
}
