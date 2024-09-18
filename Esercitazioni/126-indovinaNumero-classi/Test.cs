/*using System;

class GiocoIndovinaNum
{
    public int NumeroSegreto { get; set; }
    public int TentativiMassimi { get; set; }
    public int TentativiCorrenti { get; set; }

    // Costruttore
    public GiocoIndovinaNum(int numeroSegreto, int tentativiMassimi)
    {
        this.NumeroSegreto = numeroSegreto;
        this.TentativiMassimi = tentativiMassimi;
        this.TentativiCorrenti = 0;
    }

    public void Gioca()
    {
        Console.WriteLine("Indovina il numero segreto tra 1 e 100!");

        while (TentativiCorrenti < TentativiMassimi)
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
                return;
            }
        }

        Console.WriteLine($"Hai esaurito i tentativi. Il numero segreto era {NumeroSegreto}.");
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        int numeroSegreto = random.Next(1, 101);
        int tentativiMassimi = 5; // massimo di 5 tentativi

        GiocoIndovinaNum game = new GiocoIndovinaNum(numeroSegreto, tentativiMassimi);
        game.Gioca();
    }
}
*/