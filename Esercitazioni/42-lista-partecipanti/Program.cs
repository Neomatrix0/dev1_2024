// versione con console clear in modo da mantenere il menu nella stessa posizione dopo ogni scelta 

List<string> partecipanti = new List<string>();
string nome;
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
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            partecipanti.Add(nome);
            break;
        case 2:
            Console.WriteLine("Elenco partecipanti:");
            foreach (string partecipante in partecipanti)
            {
                Console.WriteLine(partecipante);
            }
            break;
        case 3:
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
            break;
        case 4:
            Console.Write("Nome partecipante: ");
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
        case 5:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                partecipanti.Remove(nome);
                Console.WriteLine("Il partecipante è stato eliminato dalla lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 6:
            Console.Write("Nome partecipante: ");
            nome = Console.ReadLine();
            if (partecipanti.Contains(nome))
            {
                Console.Write("Nuovo nome: ");
                string nuovoNome = Console.ReadLine();
                int indice = partecipanti.IndexOf(nome);
                partecipanti[indice] = nuovoNome;
                Console.WriteLine("Il partecipante è stato modificato nella lista");
            }
            else
            {
                Console.WriteLine("Il partecipante non è presente nella lista");
            }
            break;
        case 7:
            Console.WriteLine($"Numero partecipanti: {partecipanti.Count}");
            break;
        case 8:
            int split = partecipanti.Count / 2;
            List<string> squadra1 = partecipanti.GetRange(0, split);
            List<string> squadra2 = partecipanti.GetRange(split, partecipanti.Count);
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
            break;
        case 9:
            // crea le due squadre
            List<string> squadra1Random = new List<string>();
            List<string> squadra2Random = new List<string>();
            Random random = new Random();
            // sorteggia un nome alla volta ed assegnalo ad una delle due squadre
            while (partecipanti.Count > 0)
            {
                int indice = random.Next(partecipanti.Count);
                string partecipante = partecipanti[indice];
                partecipanti.RemoveAt(indice);
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
            partecipanti.Clear();
            break;
        case 10:
            Console.WriteLine("Arrivederci!");
            break;
        default:
            Console.WriteLine("Scelta non valida");
            break;
    }
    if (scelta != 8)
    {
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
    }
} while (scelta != 8);