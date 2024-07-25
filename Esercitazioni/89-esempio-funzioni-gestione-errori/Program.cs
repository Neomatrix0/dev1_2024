class Program
{
    static void Main()
    {

        string nome = LeggiStringa("Inserisci il tuo nome: ");
        int eta = LeggiIntero("Inserisci la tua età:");
        Console.WriteLine($"Ciao,{nome}! Hai {eta} anni.");
    }

    static string LeggiStringa(string messaggio)
    {
        Console.Write(messaggio);
        return Console.ReadLine();
    }

    static int LeggiIntero(string messaggio)
    {

        int valore;
        bool successo;

        do
        {

            Console.Write(messaggio);
            successo = int.TryParse(Console.ReadLine(), out valore);
            if (!successo)
            {
                Console.WriteLine("Inserimento non valido.Riprova.");
            }
        } while (!successo);


        return valore;
    }


}