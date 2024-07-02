// See https://aka.ms/new-console-template for more information

bool prosecuzione = true;
do
{
    Console.Clear();

    Console.WriteLine("1 Prima opzione");
    Console.WriteLine("2 Seconda opzione per il suono");
    Console.WriteLine("3 Terza opzione per uscire");
    Console.WriteLine("Scegli un opzione digitando 1 o 2 o 3");

    int scelta = Convert.ToInt32(Console.ReadLine());




    switch (scelta)
    {

        case 1:

            Console.WriteLine("Hai selezionato l'Opzione Uno");

            break;


        case 2:

           Console.WriteLine("Hai selezionato l'Opzione tre sentirai un suono");
            Console.Beep();
           

            break;

        case 3:

             Console.WriteLine("l'applicazione si chiuderà");
            prosecuzione = false;


            break;

        default:

            Console.WriteLine("Numero errato,ritenta.");
            break;
    }
    
    if (prosecuzione)
    {
        Console.WriteLine("Premi un tasto per continuare");
        Console.ReadKey();
    }

}


while (prosecuzione);
