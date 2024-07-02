// See https://aka.ms/new-console-template for more information

bool uscita = true;
do
{
    Console.Clear();

    Console.WriteLine("1 Prima opzione");
    Console.WriteLine("2 seconda Opzione per uscire");

    Console.WriteLine("Scegli un opzione digitando 1 o 2");

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
