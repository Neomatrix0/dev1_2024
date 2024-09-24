public class Statistiche{
    public int Id{ get; set; }
    public double Fatturato{ get; set; }

    public int Presenze{ get; set; }

    public Statistiche(double fatturato,int presenze){
        
        Fatturato = fatturato;
        Presenze = presenze;
    }
}