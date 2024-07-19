using Newtonsoft.Json;
//using Spectre.Console;

class Program
{

    List<string> dipendenti = new List<string>();
    string? inserimento;

    static void Main(string[] args)
    {


        Console.WriteLine("Benvenuto nel programma di gestione del personale.");
            



        int opzione;

        do
        {

            Console.Clear();
            Console.WriteLine("1. Inserisci dipendente");
            Console.WriteLine("2. Visualizza dipendenti");
            Console.WriteLine("3. Cerca dipendente");
            Console.WriteLine("4. Modifica dipendente");
            Console.WriteLine("5. Rimuovi dipendente");
            Console.WriteLine("6. Tasso di assenteismo");
            Console.WriteLine("7. Indicatore di performance");
            Console.WriteLine("8. Ordina per stipendio");
            Console.WriteLine("9. Salva dipendente in file json");
            Console.WriteLine("10. Esci");

            opzione = Convert.ToInt32(Console.ReadLine());
            switch (opzione)
            {

                case 1:

                    InserisciDipendente();


                    break;

                case 2:

               //     VisualizzaDipendenti();


                    break;

                case 3:

               // CercaDipendente();

                    break;

                case 4:

                // ModificaDipendente();

                    break;

                case 5:

                    break;

                case 6:

                    break;

                case 7:

                    break;

                case 8:

                    break;

                case 9:

                    break;

                case 10:
                    Console.WriteLine("Il programma verrà chiuso.Attendere prego.");

                    break;

                default:

                    Console.WriteLine("Errore di scelta:Prego riprovare");
                    break;
            }

            if (opzione != 10)
            {
                Console.WriteLine("Premere un tasto per proseguire");
                Console.ReadKey();
            }

        }

        while (opzione != 10);


    }

    static string InserisciDipendente()
    {
        Console.WriteLine("Inserisci nome,cognome,età e stipendio separate da virgola");
        inserimento = Console.ReadLine();
        string[] dati= inserimento.Split(',');
    
    }

}
      // string[] dati= input.Split(',');
        /*Console.WriteLine("Nome dipendente:\n");

        string? nome = Console.ReadLine().ToLower().Trim();

        Console.WriteLine("Cognome dipendente:\n");

        string? cognome = Console.ReadLine().ToLower().Trim();

        Console.WriteLine("Data di nascita:\n");

        string? dataDiNascita = Console.ReadLine();

        string datiCompleti = string.Concat(nome, secondline, thirdline);
        dipendenti.Add(new Dipendente );
        */
        

    
/*
    static void VisualizzaDipendenti()
    {
        Console.WriteLine("Lista dipendenti:\n");
        foreach (var dipendente in dipendenti)
        {
            Console.WriteLine($"{dipendente.nome},{dipendente.cognome},{dipendente.dataDiNascita}\n");
        }   
    }
    
    static void CercaDipendente(){
    }
    
    
    
    */

   /* static void ModificaDipendente(){

    }


    */

