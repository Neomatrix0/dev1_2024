class Program
{
    static void Main()
    {

        string nome = LeggiStringa("Inserisci il tuo nome: ");
        int eta = LeggiIntero("Inserisci la tua età:");
        Console.WriteLine($"Ciao,{nome}! Hai {eta} anni.");
    }

    static string LeggiStringa(string messaggio){
        Console.Write(messaggio);
        return Console.ReadLine();  
    }

    static int LeggiIntero(string messaggio){
        Console.Write(messaggio);
        return Convert.ToInt32(Console.ReadLine());  
    }


}