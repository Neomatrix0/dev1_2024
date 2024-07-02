// See https://aka.ms/new-console-template for more information

bool uscita = true;
do
{
    Console.Clear();

    Console.WriteLine("1 Prima opzione");
    Console.WriteLine("2 seconda pzione per uscire");
    Console.WriteLine("3 Terza opzione per il suono");
    Console.WriteLine("Scegli un opzione digitando 1 o 2 o 3");

    int scelta = Convert.ToInt32(Console.ReadLine());




    switch (scelta)
    {

        case 1:



            Console.WriteLine("Hai selezionato l'Opzione Uno");

            break;




        case 2:
            Console.WriteLine("l'applicazione si chiuderà");
            uscita = false;

            break;

            case 3:



            Console.WriteLine("Hai selezionato l'Opzione tre sentirai un suono");
            Console.Beep();

            break;

        default:

            Console.WriteLine("Numero errato,ritenta.");
            break;
    }
    if(uscita)
    {
        Console.WriteLine("Premi un tasto per continuare");
        Console.ReadKey();
    }


}



while (uscita);
