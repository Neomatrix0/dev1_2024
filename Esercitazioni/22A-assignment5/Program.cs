
// Creare una console app che contiene un elenco di nomi dei partecipanti del corso
// La app permette di inserire un nuovo partecipante
// La app visualizza la lista dei partecipanti
// La app permette di uscire
// la app permette di ordinare la lista dei partecipanti in ordine alfabetico
// la app permette di cercare un partecipante nella lista
// la app permette di eliminare un partecipante dalla lista
// la app permette di modificare un partecipante nella lista
// la app permette di visualizzare il numero di partecipanti

// creazione lista

List<string> partecipanti = new List<string>();   

// dichiarazioni variabili nome e scelta

string nome;
int scelta;

// ciclo do while  si interrompe solo quando viene premuto 8

do
{
    Console.WriteLine("1. Inserisci partecipante");
    Console.WriteLine("2. Visualizza partecipanti");
    Console.WriteLine("3. Ordina partecipanti");
    Console.WriteLine("4. Cerca partecante");
    Console.WriteLine("5. Elimina partecante");
    Console.WriteLine("6. Modifica partecipante");
    Console.WriteLine("7. Numero partecipanti");
    Console.WriteLine("8. Esci");
    Console.Write("Scelta: ");

    // accetta come input una stringa e la converte in numero

    scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:                                                     // inserisci partecipante                     
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine().ToLower().Trim();             // accetta input ed elimina spazi vuoti o problemi relativi al caps lock
            partecipanti.Add(nome);
            break;

        case 2:
            Console.WriteLine("Elenco partecipanti:");              // ciclo che stampa elenco partecipanti
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;

        case 3:
            Console.WriteLine("1. Ordine crescente");                // se premi 1  mette la lista in ordine crescente se premi 2 la mette in ordine descrescente
            Console.WriteLine("2. Ordine decrescente");
            Console.Write("Scelta: ");

            int ordine = Convert.ToInt32(Console.ReadLine());
            if (ordine == 1)
            {
                partecipanti.Sort();                                // metodo per mettere in ordine alfabetico i nomi nella lista
            }
            else if (ordine == 2)
            {
                partecipanti.Sort();
                partecipanti.Reverse();                             // metodo per mettere in ordine inverso i nomi nella lista
            }
            else
            {
                Console.WriteLine("Scelta non valida");
            }
            break;

        case 4:
            Console.Write("Nome partecipante: ");                               // verifica se il partecipante è presente nella lista o meno
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.WriteLine("Il partecipante è presente nella lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;

        case 5:                                                                     //  Se il partecipante inserito è già nella lista viene rimosso 
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))                                        // metodo che permette di rilevare se i partecipanti sono nella lista
            {
                partecipanti.Remove(nome);                                          // metodo per rimuovere il nome dalla lista
                Console.WriteLine("Il partecipante è stato eliminato dalla lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");        
            }
            break;

        case 6:
            Console.Write("Nome partecipante: ");                                   // modifica nome partecipante
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.Write("Nuovo nome: ");
                string nuovoNome = Console.ReadLine();
                int indice = partecipanti.IndexOf(nome);                            // assegnato l'indice del nome alla variabile indice
                partecipanti[indice] = nuovoNome;
                Console.WriteLine("Il partecipante è stato modificato nella lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 7:

            Console.WriteLine($"Numero partecipanti: {partecipanti.Count}");         // stampa il numero di partecipanti
            break;

        case 8:
            Console.WriteLine("Arrivederci!");                                      // se premi 8 esci dal loop
            break;

        default:
            Console.WriteLine("Scelta non valida");                                 // se il numero scelto non rientra in quelli prestabiliti allora stampa il messaggio
            break;
    }
} while (scelta != 8);                                                              // se il numero scelto è 8 il loop verrà chiuso




/*


// Applicazione gestione utenti

// creazione lista vuota di stringhe

List<string> listaNomi = new List<string>();

// loop per continuare ad eseguire l'applicazione

while (true)
{
    Console.WriteLine("\nDigita 1 se vuoi inserire un nuovo partecipante.\nDigita 2 per vedere l'elenco dei partecipanti.\nDigita 3 per uscire\nDigita 4 per mettere in ordine alfabetico la lista oppure invertirla\nDigita 5 per cercare un nome nell'elenco");

    // converte un input di tipo stringa in un intero

    int scelta = Convert.ToInt32(Console.ReadLine());

    // in base al tipo di scelta si può inserire un nuovo utente nella lista,visualizzare la lista o uscire dall'app

    switch (scelta)
    {

        case 1:
            Console.WriteLine("Inserisci partecipante: \n");

            string scelto = Console.ReadLine().ToLower().Trim();           // accetta una stringa come input

            listaNomi.Add(scelto);                                 // viene aggiunto il nome alla lista 


            Thread.Sleep(1000);                                         // pausa di 1 secondo                            
            break;


        case 2:

            Console.WriteLine("Visualizza partecipante\n");

            // avverte se la lista è ancora vuota

            if (listaNomi.Count == 0)
            {
                Console.WriteLine("Nessun partecipante presente.");
            }
            else
            {

                foreach (string nome in listaNomi)                               // ciclo per mostrare tutti gli utenti aggiunti alla lista 
                {
                    Console.WriteLine(nome);

                }
            };
            Thread.Sleep(1000);

            break;

        case 3:

            Console.WriteLine("L'applicazione si chiuderà");                    // digita 3 per uscire dal loop
            Thread.Sleep(1000);
            return;

        case 4:




            Console.WriteLine("se digiti 1 mette la lista in ordine alfabetico, se digiti 2 la lista si inverte");


            int ordine = Convert.ToInt32(Console.ReadLine());                       // accetta input e lo converte in int

            if (ordine == 1)
            {

                listaNomi.Sort();                                                   //sistema partecipanti in ordine alfabetico

                Console.WriteLine("La lista in ordine alfabetico\n");

                foreach (string nome in listaNomi)                                  // ciclo per mostrare tutti gli utenti aggiunti alla lista 
                {

                    Console.WriteLine(nome);

                };
                //scelta d'invertire l'elenco
            }
            else if (ordine == 2)
            {
                listaNomi.Sort();

                listaNomi.Reverse();                                                 //inverte l'ordine dei partecipanti

                Console.WriteLine($"\nLa lista in ordine invertito.\n");

                foreach (string nome in listaNomi)                                   // ciclo per mostrare tutti gli utenti aggiunti alla lista  in modo invertito
                {
                    Console.WriteLine(nome);

                };
            }
            else
            {
                Console.WriteLine("Numero errato.Puoi digitare solo 1 o 2.");
            }


            Thread.Sleep(1000);
            break;

        case 5:
            Console.WriteLine("Inserisci il nome del partecipante da cercare\n");
            string nome = Console.ReadLine().ToLower().Trim();

            if (listaNomi.Contains(nome))                          //  verifica se il nome inserito è nell'elenco
            {
                listaNomi.Remove(nome);
                Console.WriteLine($"{nome} è già nell'elenco quindi è stato rimosso");

            }
            else
            {
                Console.WriteLine($"{nome} non è nell'elenco");
            };

            break;


        case 6:
            Console.Write("Nome partecipante:");
            nome = Console.ReadLine();
            if (listaNomi.Contains(nome))
            {
                Console.Write("Nuovo nome:");
                string nuovoNome = Console.ReadLine();
                int indice = listaNomi.indexOf(nome);
                partecipanti[indice] = nuovoNome;
                Console.WriteLine("Il partecipanto è stato modificato dalla lista");
            }
            else
            {
                Console.WriteLine("Il partecipante è stato modificato nella lista");
            }
            break;


        default:
            Console.WriteLine("Scelta non valida. Riprova.\n");         //se vengono digitati altri numeri non compresi nelle casistiche l'applicazione lo segnala
            Thread.Sleep(1000);
            break;

    }

}



// versione Matteo



List<string> partecipanti = new List<string>();
char inserimento = 'o';
while (inserimento != 'q')
{
    Console.WriteLine("-----Gestionale classe-----\n1 - inserimento partecipante\n2 - Visualizza partecipanti\n3 - Ordina\nq per uscire");
    inserimento = Console.ReadKey(true).KeyChar; //hide carattere premuto
    switch (inserimento)
    {
        case '1':
            Console.WriteLine("inserimento nome");
            partecipanti.Add(Console.ReadLine()!);
            Console.Clear();
            break;
        case '2':
            Console.Clear();
            Console.WriteLine("Partecipanti:");
            foreach (string studente in partecipanti) Console.WriteLine(studente);
            Console.WriteLine();
            break;
        case '3':
            partecipanti.Sort();
            Console.WriteLine("d - Discendente?");
            inserimento = Console.ReadKey(true).KeyChar;
            if (inserimento == 'd') partecipanti.Reverse();
            Console.Clear();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Scelta non valida.\n");
            break;
    }
}

*/