
// classe 
public class GiocoIndovinaNumero{
   

    public int NumeroSegreto{get;set;}
    public int TentativiCorrenti{get;set;}
    public int TentativiMax{get;set;}

// costruttore
public  GiocoIndovinaNumero(int tentativiMax){
    Random random = new Random();
    this.NumeroSegreto=random.Next(1,101);
    this.TentativiMax=tentativiMax;
    this.TentativiCorrenti=0;
}

//metodo 
 public void Gioca()
    {
        Console.WriteLine($"Indovina il numero segreto tra 1 e 100! Hai un massimo di {TentativiMax} tentativi.");

        while (TentativiCorrenti < TentativiMax)
        {
            Console.Write("Inserisci un numero: ");
            int tentativo = int.Parse(Console.ReadLine());
            TentativiCorrenti++;

            if (tentativo < NumeroSegreto)
            {
                Console.WriteLine("Troppo basso!");
            }
            else if (tentativo > NumeroSegreto)
            {
                Console.WriteLine("Troppo alto!");
            }
            else
            {
                Console.WriteLine($"Congratulazioni! Hai indovinato il numero segreto in {TentativiCorrenti} tentativi.");
                return; // Esce dal metodo se il numero è stato indovinato
            }
        }

        Console.WriteLine($"Hai esaurito i tentativi! Il numero segreto era {NumeroSegreto}.");
    }

}
class Program{
     public static void Main(string[] args){

        //istanzia oggetto 
        GiocoIndovinaNumero gioco = new GiocoIndovinaNumero(5); // massimo di 5 tentativi
        gioco.Gioca();
}
}




