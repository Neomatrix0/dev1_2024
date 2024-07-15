// versione con solo readkey in modo da andare avanti senza premere invio dopo la scelta 

bool continua = true;
bool inSottomenu = false;

while (continua)
{

    Console.Clear();

    if (!inSottomenu)
    {
        // Mostra menu principale
        Console.WriteLine("Menu principale");
        Console.WriteLine("1. Opzione 1");
        Console.WriteLine("2. Vai al sottomenu");
        Console.WriteLine("3. Esci");
        Console.Write("Seleziona un opzione:");


    }
    else
    {

        Console.WriteLine("Sottomenu:");
        Console.WriteLine("1. Sotto-opzione 1");
        Console.WriteLine("2. Sotto-opzione 2");
        Console.WriteLine("3. Torna al menu principale");
        Console.Write("Seleziona un opzione:");



    }

    ConsoleKeyInfo tasto = Console.ReadKey(true);

    if (!inSottomenu)
    {

        switch (tasto.KeyChar)
        {
            case '1':

                Console.WriteLine("Hai scelto l'opzione 1");
                break;


            case '2':
                inSottomenu = true; // Passa al sottomenu
                break;

            case '3':
                continua = false;
                break;

            default:

                Console.WriteLine("Scelta non valida. Riprova.");
                break;

        }
    }
    else
    {
        switch (tasto.KeyChar)
        {
            case '1':
                Console.WriteLine("Hai scelto la Sotto-opzione 1");
                break;
            case '2':
                Console.WriteLine("Hai scelto la Sotto-opzione 2");
                break;
            case '3':
                inSottomenu = false;  // Torna al menu principale
                break;
            default:
                Console.WriteLine("Scelta non valida. Riprova.");
                break;
        }


    }

    if (continua)
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
}