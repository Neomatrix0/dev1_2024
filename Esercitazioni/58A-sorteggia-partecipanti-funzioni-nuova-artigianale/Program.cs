//using Spectre.Console;

class Program
{
    static List<string> partecipanti = new List<string>();
    const string filePath = "partecipanti.txt";

    static void Main()
    {
        CaricaPartecipanti();
        int scelta;
        do
        {
            Console.Clear();
            Console.WriteLine("1. Inserisci partecipante");
            Console.WriteLine("2. Visualizza partecipanti");
            Console.WriteLine("3. Ordina partecipanti");
            Console.WriteLine("4. Cerca partecipante");
            Console.WriteLine("5. Elimina partecipante");
            Console.WriteLine("6. Modifica partecipante");
            Console.WriteLine("7. Numero partecipanti");
            Console.WriteLine("8. Dividi partecipanti in 2 squadre");
            Console.WriteLine("9. Dividi partecipanti in 2 squadre con random");
            Console.WriteLine("10. Esci");
            Console.Write("Scelta: ");
            scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    InserisciPartecipante();
                    break;

                case 2:
                    VisualizzaPartecipanti();
                    break;

                case 3:
                    OrdinaPartecipanti();
                    break;

                case 4:
                    CercaPartecipante();
                    break;

                case 5:
                    EliminaPartecipante();
                    break;

                case 6:
                    ModificaPartecipante();
                    break;

                case 7:
                    NumeroPartecipanti();
                    break;

                case 8:
                    DividiPartecipantiInSquadre();
                    break;

                case 9:
                    DividiPartecipantiInSquadreConRandom();
                    break;

                case 10:
                    Console.WriteLine("Arrivederci");
                    break;

                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }
            if (scelta != 10)
            {
                Console.WriteLine("\nPremi un tasto per continuare...");
                Console.ReadKey();
            }

        } while (scelta != 10);
    }

    static void CaricaPartecipanti()
    {
        if (File.Exists(filePath))
        {
            partecipanti = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SalvaPartecipanti()
    {
        File.WriteAllLines(filePath, partecipanti);
    }

    static void InserisciPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string? nome = Console.ReadLine();
        partecipanti.Add(nome);
        SalvaPartecipanti();
    }

    static void VisualizzaPartecipanti()
    {
        Console.WriteLine("Elenco partecipanti:");
        foreach (string partecipante in partecipanti)
        {
            Console.WriteLine(partecipante);
        }
    }

    static void OrdinaPartecipanti()
    {
        Console.WriteLine("1. Ordine crescente");
        Console.WriteLine("2. Ordine decrescente");
        Console.Write("Scelta: ");
        int ordine = Convert.ToInt32(Console.ReadLine());
        if (ordine == 1)
        {
            partecipanti.Sort();
        }
        else if (ordine == 2)
        {
            partecipanti.Sort();
            partecipanti.Reverse();
        }
        else
        {
            Console.WriteLine("Scelta non valida");
        }
        SalvaPartecipanti();
    }

    static void CercaPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string? nome = Console.ReadLine();
        if (partecipanti.Contains(nome))
        {
            Console.WriteLine("Il partecipante è presente nella lista");
        }
        else
        {
            Console.WriteLine("Il partecipante non è presente nella lista");
        }
    }

    static void EliminaPartecipante()
    {

        
       // Console.Write("Nome partecipante: ");
        
        string? nome = Console.ReadLine();
        string[] inserimento =nome.Split(",");
        //int nome = Convert.ToInt32(Console.ReadLine());
        foreach (var studente in inserimento)
{
        if (partecipanti.Contains(studente))
        {
            partecipanti.Remove(studente);
            Console.WriteLine($"\nIl partecipante {studente} è stato eliminato dalla lista\n");
            SalvaPartecipanti();
            VisualizzaPartecipanti();
        }
        else
        {
            Console.WriteLine("Il partecipante non è presente nella lista");
        }
    }}

    static void ModificaPartecipante()
    {
        Console.Write("Nome partecipante: ");
        string nome = Console.ReadLine();
        if (partecipanti.Contains(nome))
        {
            Console.Write("Nuovo nome: ");
            string nuovoNome = Console.ReadLine();
            int indice = partecipanti.IndexOf(nome);
            partecipanti[indice] = nuovoNome;
            Console.WriteLine("Il partecipante è stato modificato nella lista");
            SalvaPartecipanti();
        }
        else
        {
            Console.WriteLine("Il partecipante non è presente nella lista");
        }
    }

    static void NumeroPartecipanti()
    {
        Console.WriteLine($"Numero partecipanti: {partecipanti.Count}");
    }

    static void DividiPartecipantiInSquadre()
    {
        int split = partecipanti.Count / 2;
        List<string> squadra1 = partecipanti.GetRange(0, split);
        List<string> squadra2 = partecipanti.GetRange(split, partecipanti.Count - split);
        Console.WriteLine("Squadra 1:");
        foreach (string partecipante in squadra1)
        {
            Console.WriteLine(partecipante);
        }
        Console.WriteLine("Squadra 2:");
        foreach (string partecipante in squadra2)
        {
            Console.WriteLine(partecipante);
        }
    }

    static void DividiPartecipantiInSquadreConRandom()
    {
        List<string> tempPartecipanti = new List<string>(partecipanti);
        List<string> squadra1Random = new List<string>();
        List<string> squadra2Random = new List<string>();
        Random random = new Random();
        while (tempPartecipanti.Count > 0)
        {
            int indice = random.Next(tempPartecipanti.Count);
            string partecipante = tempPartecipanti[indice];
            tempPartecipanti.RemoveAt(indice);
            if (squadra1Random.Count < squadra2Random.Count)
            {
                squadra1Random.Add(partecipante);
            }
            else
            {
                squadra2Random.Add(partecipante);
            }
        }

        Console.WriteLine("Squadra 1:");
        foreach (string partecipante in squadra1Random)
        {
            Console.WriteLine(partecipante);
        }
        Console.WriteLine("Squadra 2:");
        foreach (string partecipante in squadra2Random)
        {
            Console.WriteLine(partecipante);
        }
    }
}
