public class Statistiche{
   // public int Id{ get; set; }
    public int Performance{ get; set; }

    public double Assenze{ get; set; }

    public Statistiche(int performance,int assenze){
        
        Performance = performance;
        Assenze = assenze;
    }

   public override string ToString(){
    return $" Statistiche: Performance: {Performance}, Assenze: {Assenze}";
   }
}