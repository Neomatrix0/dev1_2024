// See https://aka.ms/new-console-template for more information
List<string> listaNomi = new List<string>();

//while (true)
//{

    int scelta;

    switch (scelta)
    {

        case 1:
            Console.WriteLine("Inserisci partecipante: ");
            string scelto = Console.ReadLine();
            listaNomi.Add(scelto);
            

        case 2:

            Console.WriteLine("Visualizza partecipante");

            foreach (string nome in listaNomi)
            {
                Console.WriteLine(nome);
            };

        case 3:
            Console.WriteLine("per uscire premi 0");
            int quit = Convert.ToInt32(Console.ReadLine());

            if (quit == 0)
            {

                break;

            }
    }
//}