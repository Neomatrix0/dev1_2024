// Applicazione gestione utenti

// creazione lista vuota di stringhe

List<string> listaNomi = new List<string>();

// loop per continuare ad eseguire l'applicazione

while (true)
{
    Console.WriteLine("\nDigita 1 se vuoi inserire un nuovo partecipante.\nDigita 2 per vedere l'elenco dei partecipanti.\nDigita 3 per uscire\nDigita 4 per mettere in ordine alfabetico la lista oppure invertirla\n");

    // converte un input di tipo stringa in un intero

    int scelta = Convert.ToInt32(Console.ReadLine());

    // in base al tipo di scelta si può inserire un nuovo utente nella lista,visualizzare la lista o uscire dall'app

    switch (scelta)
    {

        case 1:
            Console.WriteLine("Inserisci partecipante: \n");
            string scelto = Console.ReadLine().ToLower().Trim();        // accetta una stringa come input
            listaNomi.Add(scelto);                                      // viene aggiunto il nome alla lista 
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
          
        /* versione ottimale
        listaNomi.Sort();
        Console.WriteLine();
        ins = Console.ReadKey(true).KeyChar;
        if( ins == 'd') listaNomi.Reverse();
        Console.Clear();
        break;




         */
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

                listaNomi.Reverse();                                                 //inverte l'ordine dei partecipanti

                Console.WriteLine($"\nLa lista in ordine invertito.\n");

                foreach (string nome in listaNomi)                                   // ciclo per mostrare tutti gli utenti aggiunti alla lista  in modo invertito
                {
                    Console.WriteLine(nome);

                };
            }else{
                Console.WriteLine("Numero errato.Puoi digitare solo 1 o 2.");
            }





            Thread.Sleep(1000);
            break;*/

        default:
            Console.WriteLine("Scelta non valida. Riprova.\n");         //se vengono digitati altri numeri non compresi nelle casistiche l'applicazione lo segnala
            Thread.Sleep(1000);
            break;




    }

}

//versione insegnante
/*

List<string> partecipanti = new List<string>();
string nome;
int scelta;

do{
Console.WriteLine("1. Inserisci partecipante");
Console.WriteLine("2. Visualizza partecipanti");
Console.WriteLine("3. Esci");

scelta = Convert.ToInt32(Console.ReadLine());

switch(scelta){

case 1:

Console.Write("Nome partecipante: ");
nome = Console.ReadLine();
partecipanti.Add(nome);
break;

case 2:

Console.WriteLine("Elenco partecipanti: ");
foreach(string partecipante in partecipanti){
Console.WriteLine(partecipante);
}
break;

case 3:
Console.WriteLine("Arrivederci");
break;

default:
Console.WriteLine("Scelta non valida");
break;
}
}
while(scelta != 3); // il ciclo continua finchè la scelta è diversa da 3



*/

// versione Matteo

/*

List<string> partecipanti = new List<string>();
char inserimento = 'o';
while (inserimento != 'q')
{
    Console.WriteLine("-----Gestionale classe-----\n1 - inserimentoerisci partecipante\n2 - Visualiza partecipanti\n3 - Ordina\nq per uscire");
    inserimento = Console.ReadKey(true).KeyChar; //hide carattere premuto
    switch (inserimento)
    {
        case '1':
            Console.WriteLine("inserimentoerire nome");
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