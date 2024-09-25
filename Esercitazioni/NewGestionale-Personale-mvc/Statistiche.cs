public class Statistiche{
    public int Id{ get; set; }

    // Proprietà per memorizzare il fatturato generato da un dipendente
    public double Fatturato{ get; set; }

 // Proprietà per memorizzare il numero di presenze di un dipendente
    public int Presenze{ get; set; }

// costruttore classe Statistiche
    public Statistiche(double fatturato,int presenze){
        
        Fatturato = fatturato;
        Presenze = presenze;
    }
}