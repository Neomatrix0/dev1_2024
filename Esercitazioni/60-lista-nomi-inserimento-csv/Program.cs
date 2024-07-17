// esercizi persistenza dati utilizzando csv 
// chiede all'utente nome,cognome,età andando a capo ogni volta

// in questo caso il file è nella stessa cartella del programma

string path = @"test.csv";
File.Create(path).Close();

while (true)
{
    Console.WriteLine("Inserisci nome,cognome,età uno sotto l'altro");
    string nome = Console.ReadLine();           // legge nome
    string cognome = Console.ReadLine();        // legge cognome
    string eta = Console.ReadLine();
    string[] lines = File.ReadAllLines(path);
    bool found = false;

    foreach (string line in lines)
    {
        if (line.Contains(nome) && line.Contains(cognome)) // per prendere solo il nome si può usare line.StartsWith(nome) dentro if
        {
            found = true;
            break;
        }
    }
    if (!found)
    {
        File.AppendAllText(path, nome + "," + cognome + "," + eta + "\n");
    }
    else
    {
        Console.WriteLine("Il nome è già presente nel file");
    }

    Console.WriteLine("Vuoi inserire un altro nome? (s/n)");
    string risposta = Console.ReadLine();
    if (risposta == "n")
    {
        break;

    }
}





//List<string> nomi = new List<string>(File.ReadAllLines(path));
// crea il file





/*

while (true)
{
    Console.WriteLine("Inserisci nome,cognome,età");
    string nome = Console.ReadLine();           // legge nome
    string cognome = Console.ReadLine();        // legge cognome
    string eta = Console.ReadLine();
    string dati = ($"{nome},{cognome},{eta}");
   

    if (nomi.Contains(dati))
    {

        Console.WriteLine("Nome già esistente");
    }
    else
    {

         File.AppendAllText(path, dati + "\n");

        Console.WriteLine("Vuoi inserire un altro nome? (s/n)");
        string risposta = Console.ReadLine();
        if (risposta == "n")
        {
            break;

        }

    }
*/

