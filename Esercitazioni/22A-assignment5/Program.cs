// Applicazione gestione utenti

// creazione lista vuota di stringhe

List<string> listaNomi = new List<string>();

// loop per continuare ad eseguire l'applicazione

while (true)
{
    Console.WriteLine("Digita 1 se vuoi inserire un nuovo partecipante.\nDigita 2 per vedere l'elenco dei partecipanti.\n3 per uscire\n");

// converte un input di tipo stringa in un intero

    int scelta = Convert.ToInt32(Console.ReadLine());

// in base al tipo di scelta si può inserire un nuovo utente nella lista,visualizzare la lista o uscire dall'app

    switch (scelta)
    {

        case 1:
            Console.WriteLine("Inserisci partecipante: \n");
            string scelto = Console.ReadLine().ToLower().Trim();        // accetta una stringa come input
            listaNomi.Add(scelto);                                      // viene aggiunto il nome alla lista 
            break;


        case 2:

            Console.WriteLine("Visualizza partecipante\n");

            foreach (string nome in listaNomi)                               // ciclo per mostrare tutti gli utenti aggiunti alla lista 
            {
                Console.WriteLine(nome);

            };
            break;

        case 3:

            Console.WriteLine("L'applicazione si chiuderà");                    // digita 3 per uscire dal loop
            return;

        default:
                    Console.WriteLine("Scelta non valida. Riprova.\n");         //se vengono digitati altri numeri non compresi nelle casistiche l'applicazione lo segnala
                    break;
            
            
            

    }

}
